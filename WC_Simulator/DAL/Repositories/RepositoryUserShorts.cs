using MySql.Data.MySqlClient;
using System.Collections.Generic;
using WC_Simulator.DAL.Entities;

namespace WC_Simulator.DAL.Repositories
{
    class RepositoryUserShorts
    {
        #region QUERIES

        private const string ALL_USERSHORT = "SELECT `login`, `password` FROM `user`";

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

        #endregion
    }
}
