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
    public partial class ManageUserWindow : Form
    {
        UserTable userTable;
        UserModel currentUser = null;
        public ManageUserWindow()
        {
            InitializeComponent();
            userTable = new UserTable();
        }

        private void ManageUserWindow_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            gdUser.Rows.Clear();
            var users = userTable.GetUsers();
            users.ForEach((user) =>
            {
                gdUser.Rows.Add(user.UserId, user.UserName, user.FullName);
            });
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!txtPassowrd.Text.Equals(txtConfirmPassword.Text))
            {
                MessageBox.Show("Password doesn't Match.");
                return;
            }

            currentUser = currentUser ?? new UserModel();
            currentUser.FullName = txtFullName.Text;
            currentUser.UserName = txtUsername.Text;
            currentUser.Password = txtPassowrd.Text;

            if (currentUser.UserId == 0)
            {
                userTable.InsertUser(currentUser);
                MessageBox.Show("User added successfully.");
            }

            else
            {
                currentUser = userTable.UpdateUser(currentUser);
                MessageBox.Show("User updated successfully.");
            }

            RefreshGrid();
        }

        private int GetSelectedId()
        {
            if (gdUser.SelectedRows.Count < 1)
                return -1;
            return (int)(gdUser.SelectedRows[0].Cells[0].Value ?? -1);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gdUser.SelectedRows == null)
            {
                MessageBox.Show("Please select an User.");
                return;
            }

            int selectedUser = GetSelectedId();
            if (selectedUser < 0)
            {
                MessageBox.Show("Please select an User.");
                return;
            }

            currentUser = userTable.GetUser(selectedUser);
            txtUsername.Text = currentUser.UserName;
            txtFullName.Text = currentUser.FullName;
            txtPassowrd.Text = currentUser.Password;
            txtConfirmPassword.Text = currentUser.Password;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            currentUser = new UserModel();
            txtUsername.Text = string.Empty;
            txtPassowrd.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            txtFullName.Text = string.Empty;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gdUser.SelectedRows == null)
            {
                MessageBox.Show("Please select an User.");
                return;
            }

            int selectedUser = GetSelectedId();
            if (selectedUser < 0)
            {
                MessageBox.Show("Please select an User.");
                return;
            }

            var deleted = userTable.DeleteUser(selectedUser);

            if(deleted)
            {
                MessageBox.Show("User Deleted Successfully.");
                gdUser.Rows.Remove(gdUser.SelectedRows[0]);
            }
            else
            {
                MessageBox.Show("Some Error Occured.");
            }
        }
    }
}
