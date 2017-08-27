using BCA.Data;
using BCA.Data.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BarcodeAttendance
{
    public partial class TakeAttendance : Form
    {
        StudentTable studentTable;
        StudentModel currentStudent = null;
        readonly List<StudentModel> allStudents;
        AttendanceTable attendanceTable;

        public TakeAttendance()
        {
            InitializeComponent();

            studentTable = new StudentTable();
            attendanceTable = new AttendanceTable();

            this.Disposed += (s, e) => { qrWebcam.DisposeCamera(); };
            
            allStudents = studentTable.GetAllStudents();
            markAttendances();
        }

        private void markAttendances()
        {

            allStudents.ForEach((student) => {

                var attendance = new AttendanceModel() {
                    Date = DateTime.Now,
                    Status = false,
                    StudentId = student.StudentId
                };

                attendanceTable.InsertAttendance(attendance);
               
            });
        }
        
        private void TakeAttendance_Load(object sender, EventArgs e)
        {
            foreach (var camera in qrWebcam.CameraNames)
            {
                cmbSource.Items.Add(camera);
            }

            qrWebcam.QrDecoded += QrWebcam_QrDecoded;
        }

        private void QrWebcam_QrDecoded(object sender, string e)
        {
            int studentId = int.Parse(e);

            if (currentStudent != null && currentStudent.StudentId != studentId)
                currentStudent = null;

            if(currentStudent == null)
            {
                currentStudent = allStudents.Find((student) => student.StudentId == studentId);

                //lblCourse.Text = currentStudent.Course + " (" + currentStudent.Year + ")";
                //lblStudentID.Text = currentStudent.StudentId.ToString();
                //lblStudentName.Text = currentStudent.StudentName;
                //pbStudentPicture.Image = currentStudent.Picture;

                var attendance = attendanceTable.GetAttendance(currentStudent.StudentId, DateTime.Today);

                if (!attendance.Status)
                {
                    attendance.Status = true;
                    attendanceTable.UpdateAttendance(attendance);
                    MessageBox.Show("Attendance successfully made for " + currentStudent.StudentName);
                }
                else
                    MessageBox.Show("Attendance already made for " + currentStudent.StudentName);
            }


        }

        private void cmbSource_SelectedIndexChanged(object sender, EventArgs e)
        {

            qrWebcam.InitCamera(cmbSource.SelectedIndex);
        }
    }
}
