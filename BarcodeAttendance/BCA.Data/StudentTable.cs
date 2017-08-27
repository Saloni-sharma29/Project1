using BCA.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCA.Data
{
    public class StudentTable
    {
        string connectionString;

        public StudentTable()
        {
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BCADatabase.mdf;Integrated Security=True";
        }

        public bool InsertStudent(StudentModel student)
        {
            using (SqlConnection studentConnection = new SqlConnection(connectionString))
            {
                studentConnection.Open();
                string command = "INSERT INTO Student(StudentId, StudentName, Course, Year, Picture) VALUES(@studentId, @studentName, @course, @year, @picture);";
                SqlCommand insertCommand = new SqlCommand(command, studentConnection);

                insertCommand.Parameters.AddWithValue("@studentName", student.StudentName);
                insertCommand.Parameters.AddWithValue("@studentId", student.StudentId);
                insertCommand.Parameters.AddWithValue("@course", student.Course);
                insertCommand.Parameters.AddWithValue("@year", student.Year);
                var val = student.ConvertImageToByteArray();
                if(val == null)
                    insertCommand.Parameters.AddWithValue("@picture", new byte[0]);
                else
                    insertCommand.Parameters.AddWithValue("@picture", val);

                int affected = insertCommand.ExecuteNonQuery();
                return affected > 0;
            }
        }

        public List<StudentModel> GetAllStudents()
        {
            List<StudentModel> students = new List<StudentModel>();
            using (SqlConnection studentConnection = new SqlConnection(connectionString))
            {
                studentConnection.Open();
                string command = "SELECT * FROM Student;";
                SqlCommand selectStudentsCommand = new SqlCommand(command, studentConnection);
                using(SqlDataReader studentReader = selectStudentsCommand.ExecuteReader())
                {
                    while (studentReader.Read())
                    {
                        StudentModel student = new StudentModel();
                        student.Id = (int)studentReader["Id"];
                        student.Course = studentReader["Course"].ToString();
                        student.StudentName = studentReader["StudentName"].ToString();
                        student.StudentId = (int)studentReader["StudentId"];
                        student.Year = (int)studentReader["Year"];
                        if(studentReader["Picture"] != System.DBNull.Value)
                        {
                            student.ConvertByteArrayToImage((byte[])studentReader["Picture"]);
                        }
                        

                        students.Add(student);

                    }
                }
            }
            
            return students;
        }

        public StudentModel GetStudent(int studentId)
        {
            StudentModel student = null;
            using (SqlConnection studentConnection = new SqlConnection(connectionString))
            {
                studentConnection.Open();
                string command = "SELECT * FROM Student WHERE Id = @studentId;";
                SqlCommand selectStudentsCommand = new SqlCommand(command, studentConnection);
                selectStudentsCommand.Parameters.AddWithValue("@studentId", studentId);
                SqlDataReader studentReader = selectStudentsCommand.ExecuteReader();
                
                while (studentReader.Read())
                {
                    student = new StudentModel();
                    student.Id = (int)studentReader["Id"];
                    student.Course = studentReader["Course"].ToString();
                    student.StudentName = studentReader["StudentName"].ToString();
                    student.StudentId = (int)studentReader["StudentId"];
                    student.Year = (int)studentReader["Year"];
                    if (studentReader["Picture"] != System.DBNull.Value)
                    {
                        student.ConvertByteArrayToImage((byte[])studentReader["Picture"]);
                    }
                }

            }
            return student;
        }

        public bool DeleteStudent(int studentId)
        {
            using(SqlConnection studentConnection = new SqlConnection(connectionString))
            {
                studentConnection.Open();
                string command = "DELETE FROM Student WHERE Id=@id";
                SqlCommand deleteCommand = new SqlCommand(command, studentConnection);
                deleteCommand.Parameters.AddWithValue("@id", studentId);
                int affected = deleteCommand.ExecuteNonQuery();
                return affected > 0;
            }
        }

        public bool UpdateStudent(StudentModel student)
        {
            using (SqlConnection studentConnection = new SqlConnection(connectionString))
            {
                studentConnection.Open();
                string command = "UPDATE Student SET Course=@course, StudentName=@studentName, StudentId=@studentId, Year=@year, Picture=@picture WHERE Id=@id;";
                SqlCommand updateCommand = new SqlCommand(command, studentConnection);

                updateCommand.Parameters.AddWithValue("@course", student.Course);
                updateCommand.Parameters.AddWithValue("@studentName", student.StudentName);
                updateCommand.Parameters.AddWithValue("@studentId", student.StudentId);
                updateCommand.Parameters.AddWithValue("@year", student.Year);
                var val = student.ConvertImageToByteArray();
                if (val == null)
                    updateCommand.Parameters.AddWithValue("@picture", new byte[0]);
                else
                    updateCommand.Parameters.AddWithValue("@picture", val);
                updateCommand.Parameters.AddWithValue("@id", student.Id);

                int affected = updateCommand.ExecuteNonQuery();
                return affected > 0;
            }
        }

    }
}
