using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC_Simulator.DAL.Repositories
{
    using MySql.Data.MySqlClient;
    using WC_Simulator.DAL;
    using WC_Simulator.DAL.Entities;
    class RepositoryUserShorts
    {

        #region QUERIES
        private const string ALL_USERSHORT = "SELECT `login`, `password` FROM `user`";
        //private const string ADD_USER = "INSERT INTO `user`(`id_user`, `login`, `password`," +
        //    " `creation_date`, `last_log_date`, `security_question`, `security_answer`) VALUES ";
        //private const string DELETE_USER = "DELETE FROM `user` WHERE id_user = ";
        //private const string UPDATE_USER = "UPDATE `user` SET xx WHERE id_user = ";
        #endregion

        #region CRUD
        public static List<UserShort> LoadUserShort()
        {
            List<UserShort> userShort = new List<UserShort>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_USERSHORT, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    userShort.Add(new UserShort(reader));
                connection.Close();
            }
            return userShort;
        }

        //public static bool AddUser(User user)
        //{
        //    bool state = false;
        //    using (var connection = DBConnection.Instance.Connection)
        //    {
        //        MySqlCommand command = new MySqlCommand($"{ADD_USER} {user.ToInsert()}", connection);
        //        connection.Open();
        //        var id = command.ExecuteNonQuery();
        //        state = true;
        //        user.Id_user = (uint)command.LastInsertedId;
        //        connection.Close();
        //    }
        //    return state;
        //}

        //public static bool UpdateUser(User user, uint idUser)
        //{
        //    bool state = false;
        //    using (var connection = DBConnection.Instance.Connection)
        //    {
        //        string UPDATE_USER = $"UPDATE User SET id_user='{user.Id_user}', login='{user.Login}', password='{user.Password}'" +
        //            $"creation_date='{user.Creation_date}', last_log_date='{user.Last_log_date}', security_question='{user.Security_question}'" +
        //            $"WHERE id_user={idUser}";

        //        MySqlCommand command = new MySqlCommand(UPDATE_USER, connection);
        //        connection.Open();
        //        var n = command.ExecuteNonQuery();
        //        if (n == 1) state = true;

        //        connection.Close();
        //    }
        //    return state;
        //}

        //public static bool DeleteUser(User user)
        //{
        //    bool state = false;
        //    using (var connection = DBConnection.Instance.Connection)
        //    {
        //        MySqlCommand command = new MySqlCommand($"{DELETE_USER} {user.Id_user}", connection);
        //        connection.Open();
        //        var id = command.ExecuteNonQuery();
        //        state = true;
        //        connection.Close();
        //    }
        //    return state;
        //}
        #endregion

    }
}
