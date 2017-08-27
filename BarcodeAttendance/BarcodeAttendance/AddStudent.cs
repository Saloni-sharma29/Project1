using System;
using System.Windows.Forms;
using BCA.Data;
using BCA.Data.Models;
using System.Drawing;

namespace BarcodeAttendance
{
    public partial class AddStudent : Form
    {
        StudentTable studentTable;
        StudentModel currentStudent = null;
        public AddStudent()
        {
            InitializeComponent();
            studentTable = new StudentTable();
        }

        public AddStudent(StudentModel openStudent) : this()
        {
            currentStudent = openStudent;

        }

        private void AddStudent_Load(object sender, EventArgs e)
        {
            cmbCourse.SelectedIndex = 0;

            if (currentStudent != null)
            {
                txtName.Text = currentStudent.StudentName;
                cmbCourse.SelectedItem = currentStudent.Course;
                maskedStdId.Text = currentStudent.StudentId.ToString();
                switch (currentStudent.Year)
                {
                    case 1:
                        rbFirst.Checked = true;
                        break;
                    case 2:
                        rbSecond.Checked = true;
                        break;
                    case 3:
                        rbThird.Checked = true;
                        break;
                    case 4:
                        rbFour.Checked = true;
                        break;
                }
                pbStudentImage.Image = currentStudent.Picture;
                pbStudentImage.SizeMode = PictureBoxSizeMode.Zoom;
                lblTitle.Text = "Edit Student";
                this.Text = "Edit Student : " + currentStudent.StudentName;
                btnAdd.Text = "Update";
            }
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            resetForm();

        }

        private void resetForm()
        {
            txtName.Text = string.Empty;
            cmbCourse.Text = string.Empty;
            maskedStdId.Text = string.Empty;
            rbFirst.Checked = false;
            rbSecond.Checked = false;
            rbThird.Checked = false;
            rbFour.Checked = false;
            pbStudentImage.Image = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            currentStudent = currentStudent ?? new StudentModel();
            currentStudent.StudentId = int.Parse(maskedStdId.Text);
            currentStudent.StudentName = txtName.Text;
            currentStudent.Course = cmbCourse.SelectedItem.ToString();
            currentStudent.Picture = pbStudentImage.Image;


            if (rbFirst.Checked)
                currentStudent.Year = 1;

            if (rbSecond.Checked)
                currentStudent.Year = 2;
            if (rbThird.Checked)
                currentStudent.Year = 3;
            if (rbFour.Checked)
                currentStudent.Year = 4;

            bool updated = false;

            if(currentStudent.Id == 0)
            {
                updated = studentTable.InsertStudent(currentStudent);
            }
            else
            {
                updated = studentTable.UpdateStudent(currentStudent);
            }

            if (updated)
            {
                MessageBox.Show(" Information Added successfully...");
                resetForm();
            }
            else
            {
                MessageBox.Show("Some Error Occurred.");
            }


        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openImage = new OpenFileDialog();
            openImage.Filter = "jpeg|*.jpg|bmp|*.bmp";
            if (openImage.ShowDialog() == DialogResult.OK)
            {
                pbStudentImage.Image = Image.FromFile(openImage.FileName);
                pbStudentImage.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
    }
}
