using BCA.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCA.Data
{
    public class AttendanceTable
    {
        string connectionString;
        public AttendanceTable()
        {
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BCADatabase.mdf;Integrated Security=True";
        }

        public bool InsertAttendance(AttendanceModel attendance)
        {
            using (SqlConnection attendanceConnection = new SqlConnection(connectionString))
            {
                attendanceConnection.Open();

                string command = "INSERT INTO Attendance(StudentId, Status, Date) VALUES(@studentId, @status, @date);";
                SqlCommand insertCommand = new SqlCommand(command, attendanceConnection);
                insertCommand.Parameters.AddWithValue("@studentId", attendance.StudentId);
                insertCommand.Parameters.AddWithValue("@status", attendance.Status);
                insertCommand.Parameters.AddWithValue("@date", attendance.Date.Date);
                int inserted = insertCommand.ExecuteNonQuery();
                return inserted > 0;

            }
        }

        public bool UpdateAttendance(AttendanceModel attendance)
        {
            using (SqlConnection attendanceConnection = new SqlConnection(connectionString))
            {
                attendanceConnection.Open();

                string command = "UPDATE Attendance SET StudentId = @studentId, Status=@status, Date=@date WHERE AttendanceId = @id;";
                SqlCommand updateCommand = new SqlCommand(command, attendanceConnection);
                updateCommand.Parameters.AddWithValue("@studentId", attendance.StudentId);
                updateCommand.Parameters.AddWithValue("@status", attendance.Status);
                updateCommand.Parameters.AddWithValue("@date", attendance.Date.Date);
                updateCommand.Parameters.AddWithValue("@id", attendance.AttendanceId);
                int updated = updateCommand.ExecuteNonQuery();
                return updated > 0;


            }
        }

        public List<AttendanceModel> GetAttendances()
        {
            List<AttendanceModel> attendances = new List<AttendanceModel>();
            using (SqlConnection attendanceConnection = new SqlConnection(connectionString))
            {
                attendanceConnection.Open();

                string command = "SELECT * FROM Attendance";
                SqlCommand selectCommand = new SqlCommand(command, attendanceConnection);

                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var attendance = new AttendanceModel();
                        attendance.AttendanceId = reader.GetInt32(0);
                        attendance.StudentId = reader.GetInt32(1);
                        attendance.Status = reader.GetBoolean(2);
                        attendance.Date = reader.GetDateTime(3);

                        attendances.Add(attendance);
                    }
                }

            }

            return attendances;
        }

        public List<AttendanceModel> GetAttendances(int studentId)
        {
            List<AttendanceModel> attendances = new List<AttendanceModel>();
            using (SqlConnection attendanceConnection = new SqlConnection(connectionString))
            {
                attendanceConnection.Open();

                string command = "SELECT * FROM Attendance WHERE StudentId=@studentId;";
                SqlCommand selectCommand = new SqlCommand(command, attendanceConnection);
                selectCommand.Parameters.AddWithValue("@studentId", studentId);

                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var attendance = new AttendanceModel();
                        attendance.AttendanceId = reader.GetInt32(0);
                        attendance.StudentId = reader.GetInt32(1);
                        attendance.Status = reader.GetBoolean(2);
                        attendance.Date = reader.GetDateTime(3);

                        attendances.Add(attendance);
                    }
                }

            }

            return attendances;
        }

        public List<AttendanceModel> GetAttendances(int studentId, DateTime fromDate, DateTime toDate)
        {
            List<AttendanceModel> attendances = new List<AttendanceModel>();
            using (SqlConnection attendanceConnection = new SqlConnection(connectionString))
            {
                attendanceConnection.Open();

                string command = "SELECT * FROM Attendance WHERE StudentId = @studentId AND Date BETWEEN @fromDate AND @toDate;";
                SqlCommand selectCommand = new SqlCommand(command, attendanceConnection);
                selectCommand.Parameters.AddWithValue("@studentId", studentId);
                selectCommand.Parameters.AddWithValue("@fromDate", fromDate.Date);
                selectCommand.Parameters.AddWithValue("@toDate", toDate.Date);
                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var attendance = new AttendanceModel();
                        attendance.AttendanceId = reader.GetInt32(0);
                        attendance.StudentId = reader.GetInt32(1);
                        attendance.Status = reader.GetBoolean(2);
                        attendance.Date = reader.GetDateTime(3);

                        attendances.Add(attendance);
                    }
                }

            }

            return attendances;
        }

        public List<AttendanceModel> GetAttendances(DateTime today)
        {
            List<AttendanceModel> attendances = new List<AttendanceModel>();
            using (SqlConnection attendanceConnection = new SqlConnection(connectionString))
            {
                attendanceConnection.Open();

                string command = "SELECT * FROM Attendance WHERE Date = @date;";
                SqlCommand selectCommand = new SqlCommand(command, attendanceConnection);

                selectCommand.Parameters.AddWithValue("@date", today.Date);

                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var attendance = new AttendanceModel();
                        attendance.AttendanceId = reader.GetInt32(0);
                        attendance.StudentId = reader.GetInt32(1);
                        attendance.Status = reader.GetBoolean(2);
                        attendance.Date = reader.GetDateTime(3);

                        attendances.Add(attendance);
                    }
                }

            }

            return attendances;
        }

        public List<AttendanceModel> GetAttendances(DateTime fromDate, DateTime toDate)
        {
            List<AttendanceModel> attendances = new List<AttendanceModel>();
            using (SqlConnection attendanceConnection = new SqlConnection(connectionString))
            {
                attendanceConnection.Open();

                string command = "SELECT * FROM Attendance WHERE Date BETWEEN @fromDate AND @toDate;";
                SqlCommand selectCommand = new SqlCommand(command, attendanceConnection);

                selectCommand.Parameters.AddWithValue("@fromDate", fromDate.Date);
                selectCommand.Parameters.AddWithValue("@toDate", toDate.Date);
                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var attendance = new AttendanceModel();
                        attendance.AttendanceId = reader.GetInt32(0);
                        attendance.StudentId = reader.GetInt32(1);
                        attendance.Status = reader.GetBoolean(2);
                        attendance.Date = reader.GetDateTime(3);

                        attendances.Add(attendance);
                    }
                }

            }

            return attendances;
        }

        public AttendanceModel GetAttendance(int attendanceId)
        {

            AttendanceModel attendance = null;
            using (SqlConnection attendanceConnection = new SqlConnection(connectionString))
            {
                attendanceConnection.Open();

                string command = "SELECT * FROM Attendance WHERE AttendanceId = @attendanceId;";
                SqlCommand selectCommand = new SqlCommand(command, attendanceConnection);
                selectCommand.Parameters.AddWithValue("@attendanceId", attendanceId);
                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        attendance = new AttendanceModel();
                        attendance.AttendanceId = reader.GetInt32(0);
                        attendance.StudentId = reader.GetInt32(1);
                        attendance.Status = reader.GetBoolean(2);
                        attendance.Date = reader.GetDateTime(3);


                    }
                }

            }

            return attendance;
        }

        public AttendanceModel GetAttendance(int studentId, DateTime attendanceDate)
        {
            AttendanceModel attendance = null;
            using (SqlConnection attendanceConnection = new SqlConnection(connectionString))
            {
                attendanceConnection.Open();

                string command = "SELECT * FROM Attendance WHERE StudentId = @studentId AND Date = @date;";
                SqlCommand selectCommand = new SqlCommand(command, attendanceConnection);
                selectCommand.Parameters.AddWithValue("@studentID", studentId);
                selectCommand.Parameters.AddWithValue("@date", attendanceDate.Date);
                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        attendance = new AttendanceModel();
                        attendance.AttendanceId = reader.GetInt32(0);
                        attendance.StudentId = reader.GetInt32(1);
                        attendance.Status = reader.GetBoolean(2);
                        attendance.Date = reader.GetDateTime(3);


                    }
                }

            }

            return attendance;
        }

        public int TotalAttendances(int studentId, DateTime startDate, DateTime endDate)
        {
            int total = 0;
            using (SqlConnection attendanceConnection = new SqlConnection(connectionString))
            {
                attendanceConnection.Open();

                string command = "SELECT COUNT(*) FROM Attendance WHERE StudentId = @studentId AND Date BETWEEN @startDate AND @endDate;";
                SqlCommand selectCommand = new SqlCommand(command, attendanceConnection);
                selectCommand.Parameters.AddWithValue("@studentID", studentId);
                selectCommand.Parameters.AddWithValue("@startDate", startDate.Date);
                selectCommand.Parameters.AddWithValue("@endDate", endDate.Date);

                total=  (int)selectCommand.ExecuteScalar();

            }
            return total;
        }
        public int TotalPresentAttendances(int studentId, DateTime startDate, DateTime endDate)
        {
            int total = 0;
            using (SqlConnection attendanceConnection = new SqlConnection(connectionString))
            {
                attendanceConnection.Open();

                string command = "SELECT COUNT(*) FROM Attendance WHERE StudentId = @studentId AND Date BETWEEN @startDate AND @endDate AND Status = @status;";
                SqlCommand selectCommand = new SqlCommand(command, attendanceConnection);
                selectCommand.Parameters.AddWithValue("@studentID", studentId);
                selectCommand.Parameters.AddWithValue("@startDate", startDate.Date);
                selectCommand.Parameters.AddWithValue("@status", true);
                selectCommand.Parameters.AddWithValue("@endDate", endDate.Date);

                total = (int)selectCommand.ExecuteScalar();

            }
            return total;
        }
    }
}
