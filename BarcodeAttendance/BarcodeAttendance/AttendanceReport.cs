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
    public partial class AttendanceReport : Form
    {
        readonly List<StudentModel> students;
        readonly AttendanceTable attendanceTable;
        public AttendanceReport()
        {
            InitializeComponent();
            students = new StudentTable().GetAllStudents();
            attendanceTable = new AttendanceTable();
        }

        private void AttendanceReport_Load(object sender, EventArgs e)
        {
            cmbCourse.SelectedIndex = 0;
            cmbYear.SelectedIndex = 0;
            RefreshGrid(students);
        }

        private void RefreshGrid(List<StudentModel> _students)
        {
            dgAttendanceReport.Rows.Clear();
            _students.ForEach((student) => {

                int totalAttendance = attendanceTable.TotalAttendances(student.StudentId, dtFromDate.Value, dtToDate.Value);
                int totalPresentAttendance = attendanceTable.TotalPresentAttendances(student.StudentId, dtFromDate.Value, dtToDate.Value);
                float percentage = (float)((float)totalPresentAttendance / (float)totalAttendance) * 100;
                var studentCourse = string.Format("{0} ({1})", student.Course, student.Year);
                dgAttendanceReport.Rows.Add(student.StudentId, student.StudentName, studentCourse, totalAttendance, totalPresentAttendance, percentage);
            });
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            var _students = students;
            
            if(cmbCourse.SelectedIndex != 0)
            {
                var selectedCourse = cmbCourse.SelectedItem.ToString();
                _students = _students.FindAll((s) =>  s.Course.Equals(selectedCourse, StringComparison.OrdinalIgnoreCase) );
            }

            if(cmbYear.SelectedIndex != 0)
            {
                var selectedYear = cmbYear.SelectedIndex;
                _students = _students.FindAll((s) => s.Year == selectedYear);
            }

            RefreshGrid(_students);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = " Excel File (.xls)|*.xls";
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.Cancel)
                return;

            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "Attendance Report";
            // storing header part in Excel  
            for (int i = 1; i < dgAttendanceReport.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dgAttendanceReport.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dgAttendanceReport.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dgAttendanceReport.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dgAttendanceReport.Rows[i].Cells[j].Value.ToString();
                }
            }
            // save the application  
            workbook.SaveAs(saveFileDialog.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            app.Quit();
        }
    }
}
