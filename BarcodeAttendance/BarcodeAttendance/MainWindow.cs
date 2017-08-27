using BarcodeAttendance;
using System;
using System.Windows.Forms;

namespace BarcodeAttendance
{
    public partial class MainWindow : Form
    {
        private LoginWindow loginWindow;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(LoginWindow loginWindow) : this()
        {
            this.loginWindow = loginWindow;
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent newStudent = new AddStudent();
            newStudent.MdiParent = this;
            newStudent.Show();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void takeAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TakeAttendance takeAttendance = new TakeAttendance();
            takeAttendance.MdiParent = this;
            takeAttendance.Show();
        }

        private void viewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var viewStudents = new ViewStudent();
            viewStudents.MdiParent = this;
            viewStudents.Show();
        }

        private void viewAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewAttendance viewAttendanceWindow = new ViewAttendance();
            viewAttendanceWindow.MdiParent = this;
            viewAttendanceWindow.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            loginWindow.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.loginWindow.Close();
        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageUserWindow manageUsersWindow = new ManageUserWindow();
            manageUsersWindow.MdiParent = this;
            manageUsersWindow.Show();
        }

        private void attendanceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttendanceReport attendanceReportWindow = new AttendanceReport();
            attendanceReportWindow.MdiParent = this;
            attendanceReportWindow.Show();
        }
    }
}
