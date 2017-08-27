using BCA.Data;
using BCA.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace BarcodeAttendance
{

    public partial class ViewStudent : Form
    {
        StudentTable studentTable;
        public ViewStudent()
        {
            InitializeComponent();
            studentTable = new StudentTable();
        }

        private void ViewStudent_Load(object sender, EventArgs e)
        {

            gridStudents.DataSource = studentTable.GetAllStudents();
            gridStudents.Refresh();

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            var students = studentTable.GetAllStudents();
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                var folderPath = folderBrowser.SelectedPath;
                BarcodeWriter writer = new BarcodeWriter();
                writer.Format = BarcodeFormat.QR_CODE;
                foreach (var student in students)
                {
                    var image = writer.Write(student.StudentId.ToString());
                    var filename = student.StudentId + "-" + student.StudentName + ".jpg";
                    image.Save(Path.Combine(folderPath, filename));

                }

            }

        }

        private void mskStudentId_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(mskStudentId.Text) || string.IsNullOrWhiteSpace(mskStudentId.Text) )
            {
                MessageBox.Show("Please Enter valid student Id.");
                return;
            }
            StudentModel student = studentTable.GetStudent(int.Parse(mskStudentId.Text));

            var list = new List<StudentModel>();
            list.Add(student);

            gridStudents.DataSource = list;
            gridStudents.Refresh();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedId = getSelectedId();
            if(selectedId < 0)
            {
                MessageBox.Show("Please select a student record.");
                return;
            }

            if(studentTable.DeleteStudent(selectedId))
            {
                MessageBox.Show("Record successfully deleted.");
            }
        }

        private int getSelectedId()
        {
            if (gridStudents.SelectedRows.Count < 1)
                return -1;
            return (int)(gridStudents.SelectedRows[0].Cells[0].Value ?? -1);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var selectedId = getSelectedId();
            if (selectedId < 0)
            {
                MessageBox.Show("Please select a student record.");
                return;
            }

            var student = studentTable.GetStudent(selectedId);
            AddStudent addStudentWindow = new AddStudent(student);
            addStudentWindow.MdiParent = this.MdiParent;
            addStudentWindow.Show();

        }
    }
}
