using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using BCA.Data.Models;

namespace BCA.Data
{
    public class UserTable
    {
        string connectionString;
        public UserTable()
        {
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BCADatabase.mdf;Integrated Security=True";
        }

        public bool InsertUser(UserModel user)
        {
            using (SqlConnection userTableConnection = new SqlConnection(connectionString))
            {
                userTableConnection.Open();
                string command = "INSERT INTO AdminUser(Username, Password, FullName) VALUES(@username, @password, @fullname);";
                SqlCommand insertCommand = new SqlCommand(command, userTableConnection);
                insertCommand.Parameters.AddWithValue("@username", user.UserName);
                insertCommand.Parameters.AddWithValue("@password", user.Password);
                insertCommand.Parameters.AddWithValue("@fullname", user.FullName);
                int affected = insertCommand.ExecuteNonQuery();
                return affected > 0;
            }
        }

        public UserModel UpdateUser(UserModel user)
        {
            using (SqlConnection userTableConnection = new SqlConnection(connectionString))
            {
                userTableConnection.Open();

                string command = "UPDATE AdminUser SET Username=@username, Password=@password, FullName = @fullname WHERE Id=@id";
                SqlCommand updateCommand = new SqlCommand(command, userTableConnection);
                updateCommand.Parameters.AddWithValue("@username", user.UserName);
                updateCommand.Parameters.AddWithValue("@password", user.Password);
                updateCommand.Parameters.AddWithValue("@fullname", user.FullName);
                updateCommand.Parameters.AddWithValue("@id", user.UserId);
                updateCommand.ExecuteNonQuery();
                return GetUser(user.UserId);
            }
        }

        public List<UserModel> GetUsers()
        {
            List<UserModel> users = new List<UserModel>();
            using (SqlConnection userTableConnection = new SqlConnection(connectionString))
            {
                userTableConnection.Open();
                string command = "SELECT * FROM AdminUser";
                SqlCommand selectCommand = new SqlCommand(command, userTableConnection);
                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        var user = new UserModel();
                        user.UserId = reader.GetInt32(0);
                        user.UserName = reader.GetString(1);
                        user.Password = reader.GetString(2);
                        user.FullName = reader.GetString(3);
                        users.Add(user);
                    }
                }
            }

            return users;
        }

        public UserModel GetUser(int userId)
        {
            UserModel user = null;
            using (SqlConnection userTableConnection = new SqlConnection(connectionString))
            {
                userTableConnection.Open();
                string command = "SELECT * FROM AdminUser WHERE Id=@id;";
                SqlCommand selectCommand = new SqlCommand(command, userTableConnection);
                selectCommand.Parameters.AddWithValue("@id", userId);
                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        user = new UserModel();
                        user.UserId = reader.GetInt32(0);
                        user.UserName = reader.GetString(1);
                        user.Password = reader.GetString(2);
                        user.FullName = reader.GetString(3);

                    }
                }
            }
            return user;
        }

        public UserModel GetUser(string username)
        {
            UserModel user = null;
            using (SqlConnection userTableConnection = new SqlConnection(connectionString))
            {
                userTableConnection.Open();
                string command = "SELECT * FROM AdminUser WHERE Username=@username;";
                SqlCommand selectCommand = new SqlCommand(command, userTableConnection);
                selectCommand.Parameters.AddWithValue("@username", username);
                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        user = new UserModel();
                        user.UserId = reader.GetInt32(0);
                        user.UserName = reader.GetString(1);
                        user.Password = reader.GetString(2);
                        user.FullName = reader.GetString(3);

                    }
                }
            }
            return user;
        }
        
        public bool DeleteUser(int userId)
        {
            using (SqlConnection userTableConnection = new SqlConnection(connectionString))
            {
                userTableConnection.Open();
                string command = "DELETE FROM AdminUser WHERE Id=@id;";
                SqlCommand deleteCommand = new SqlCommand(command, userTableConnection);
                deleteCommand.Parameters.AddWithValue("@id", userId);
                int deletedRows = deleteCommand.ExecuteNonQuery();
                return deletedRows > 0;
            }

        }

    }
}
