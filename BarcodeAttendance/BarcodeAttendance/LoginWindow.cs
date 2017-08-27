using BCA.Data;
using BCA.Data.Models;
using System;
using System.Windows.Forms;

namespace BarcodeAttendance
{
    public partial class LoginWindow : Form
    {
        UserTable userTable;
        MainWindow window;
        public LoginWindow()
        {
            InitializeComponent();
            window = new MainWindow(this);
            userTable = new UserTable();
        }
        

        private void LoginWindow_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUserName.Text;
            var password = txtPassword.Text;

            if(string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter username and password.");
                return;
            }

            UserModel user = userTable.GetUser(username);
            if(user == null || !user.Password.Equals(password))
            {
                MessageBox.Show("Incorrect Username or Password.");
                return;
            }
            
            window.Show();
 
            this.Hide();
            window.FormClosed += Window_FormClosed;
            
        }

        private void Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            window.Close();
            this.Close();
        }
    }
}
