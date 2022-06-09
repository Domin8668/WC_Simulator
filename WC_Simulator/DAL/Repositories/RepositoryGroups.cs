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
    class RepositoryGroups
    {
        #region QUERIES
        private const string ALL_GROUP = "SELECT * FROM `single_group`";
        private const string ADD_GROUP = "INSERT INTO `single_group`(`id_group`, `id_first_pl_team`, `id_second_pl_team`, `id_tournament`, `letter`) VALUES ";
        private const string DELETE_GROUP = "DELETE FROM `single_group` WHERE id_group = ";
        //private const string UPDATE_GROUP = "UPDATE `single_group` SET xx WHERE id_group = ";
        #endregion

        #region CRUD
        /// <summary>
        /// CRUD - create, read, update, delete
        /// </summary>
        /// <returns></returns>

        public static List<Single_group> LoadGroup()
        {
            List<Single_group> group = new List<Single_group>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_GROUP, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    group.Add(new Single_group(reader));
                connection.Close();
            }
            return group;
        }

        public static bool AddGroup(Single_group group)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ADD_GROUP} {group.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                state = true;
                group.Id_group = (uint)command.LastInsertedId;
                connection.Close();
            }
            return state;
        }

        public static bool UpdateGroup(Single_group group, uint idGroup)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string UPDATE_GROUP = $"UPDATE Single_group SET id_group='{group.Id_group}', id_first_pl_team='{group.Id_first_pl_team}', " +
                    $"id_second_pl_team={group.Id_second_pl_team}, id_tournament='{group.Id_tournament}', letter='{group.Letter}' WHERE id_group={idGroup}";

                MySqlCommand command = new MySqlCommand(UPDATE_GROUP, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) state = true;

                connection.Close();
            }
            return state;
        }

        public static bool DeleteGroup(Single_group group)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DELETE_GROUP} {group.Id_group}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                state = true;
                connection.Close();
            }
            return state;
        }
        #endregion
    }
}
