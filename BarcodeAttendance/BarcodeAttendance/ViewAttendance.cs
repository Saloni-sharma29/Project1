using BCA.Data;
using BCA.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeAttendance
{
    public partial class ViewAttendance : Form
    {
        AttendanceTable attendanceTable;
        readonly List<StudentModel> students;
        public ViewAttendance()
        {
            InitializeComponent();
            attendanceTable = new AttendanceTable();
            students = new StudentTable().GetAllStudents();
        }

        private void ViewAttendance_Load(object sender, EventArgs e)
        {
            var attendances = attendanceTable.GetAttendances(DateTime.Now);
            UpdateGrid(attendances);
        }

        private void UpdateGrid(List<AttendanceModel> attendances)
        {
            dgAttendances.Rows.Clear();
            attendances.ForEach((att) =>
            {
                var student = students.Find((s) => s.StudentId == att.StudentId);
                dgAttendances.Rows.Add(student.StudentId, student.StudentName, student.Course, student.Year, att.Date, ((att.Status) ? "Present" : "Absent"));
            });
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            var studentId = maskedStudentId.Text;
            var fromDate = dtStartDate.Value;
            var toDate = dtEndDate.Value;

            if(string.IsNullOrEmpty(studentId) || string.IsNullOrWhiteSpace(studentId))
            {
                var attendances = attendanceTable.GetAttendances(fromDate, toDate);
                UpdateGrid(attendances);
            }
            else
            {
                int val;
                if(!int.TryParse(studentId, out val))
                {
                    MessageBox.Show("Please enter valid student ID.");
                    return;
                }
                var attendances = attendanceTable.GetAttendances(val, fromDate, toDate);
                UpdateGrid(attendances);
            }
        }
    }
}
