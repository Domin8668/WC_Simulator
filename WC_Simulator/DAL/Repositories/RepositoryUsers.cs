using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WC_Simulator.DAL.Entities;

namespace WC_Simulator.DAL.Repositories
{
    class RepositoryUsers
    {
        #region QUERIES

        private const string ALL_USER = "SELECT * FROM `user`";

        #endregion


        #region CRUD

        public static List<User> LoadUser()
        {
            List<User> user = new List<User>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_USER, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    user.Add(new User(reader));
                connection.Close();
            }
            return user;
        }

        public static bool AddUser(User user)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand("INSERT INTO `user`(`login`, `password`, `creation_date`, `last_log_date`, `security_question`, `security_answer`) VALUES (@login, @password, @creation_date, @last_log_date, @security_question, @security_answer)", connection);
                connection.Open();
                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = user.Login;
                command.Parameters.Add("@password", MySqlDbType.Blob).Value = user.Password;
                command.Parameters.Add("@creation_date", MySqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                command.Parameters.Add("@last_log_date", MySqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                command.Parameters.Add("@security_question", MySqlDbType.VarChar).Value = user.Security_question;
                command.Parameters.Add("@security_answer", MySqlDbType.Blob).Value = user.Security_answer;
                var n = command.ExecuteNonQuery();
                if (n == 1) state = true;
                user.Id_user = (uint)command.LastInsertedId;
                connection.Close();
            }
            return state;
        }

        public static bool UpdateUserPassword(User user)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand("UPDATE User SET password=@password, last_log_date=@last_log_date WHERE login=@login", connection);
                connection.Open();
                command.Parameters.Add("@password", MySqlDbType.Blob).Value = user.Password;
                command.Parameters.Add("@last_log_date", MySqlDbType.DateTime).Value = user.Last_log_date.ToString("yyyy-MM-dd HH:mm:ss");
                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = user.Login;
                var n = command.ExecuteNonQuery();
                if (n == 1) state = true;
                connection.Close();
            }
            return state;
        }

        public static bool UpdateUserLastLogin(User user)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand("UPDATE User SET last_log_date=@last_log_date WHERE login=@login", connection);
                connection.Open();
                command.Parameters.Add("@last_log_date", MySqlDbType.DateTime).Value = user.Last_log_date.ToString("yyyy-MM-dd HH:mm:ss");
                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = user.Login;
                var n = command.ExecuteNonQuery();
                if (n == 1) state = true;
                connection.Close();
            }
            return state;
        }

        #endregion
    }
}
