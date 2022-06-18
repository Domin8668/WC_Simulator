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
        private const string ALL_GROUP = "SELECT * FROM `single_group` WHERE id_tournament = ";
        private const string ADD_GROUP = "INSERT INTO `single_group`(`id_group`, `id_first_pl_team`, `id_second_pl_team`, `id_tournament`, `letter`) VALUES ";
        private const string DELETE_GROUP = "DELETE FROM `single_group` WHERE id_group = ";
        //private const string UPDATE_GROUP = "UPDATE `single_group` SET xx WHERE id_group = ";
        #endregion

        #region CRUD
        /// <summary>
        /// CRUD - create, read, update, delete
        /// </summary>
        /// <returns></returns>

        public static List<Single_group> LoadTournamentGroup(uint? tournament_id)
        {
            List<Single_group> group = new List<Single_group>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_GROUP + $"{tournament_id}", connection);
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

        public static bool UpdateGroup(Single_group group)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand("UPDATE Single_group SET id_first_pl_team=@Id_first_pl_team, id_second_pl_team=@Id_second_pl_team, WHERE id_group=@idGroup", connection);
                connection.Open();
                if (group.Id_first_pl_team == null)
                    command.Parameters.AddWithValue("@Id_first_pl_team", DBNull.Value);
                else
                    command.Parameters.Add("@Id_first_pl_team", MySqlDbType.UInt64).Value = group.Id_first_pl_team;

                if (group.Id_first_pl_team == null)
                    command.Parameters.AddWithValue("@Id_second_pl_team", DBNull.Value);
                else
                    command.Parameters.Add("@Id_second_pl_team", MySqlDbType.UInt64).Value = group.Id_second_pl_team;

                command.Parameters.Add("@idGroup", MySqlDbType.UInt64).Value = group.Id_first_pl_team;
                var n = command.ExecuteNonQuery();
                if (n == 1) state = true;
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

        public static bool AddTournamentGroups(Single_group group, uint tournament_id)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand("INSERT INTO `single_group`(`id_tournament`, `id_first_pl_team`, `id_second_pl_team`, `letter`) VALUES (@Id_tournament, @Id_first_pl_team, Id_second_pl_team, @Letter)", connection);
                connection.Open();
                command.Parameters.Add("@Id_tournament", MySqlDbType.UInt64).Value = tournament_id;

                if (group.Id_first_pl_team == null)
                    command.Parameters.AddWithValue("@Id_first_pl_team", DBNull.Value);
                else
                    command.Parameters.Add("@Id_first_pl_team", MySqlDbType.UInt64).Value = group.Id_first_pl_team;

                if (group.Id_first_pl_team == null)
                    command.Parameters.AddWithValue("@Id_second_pl_team", DBNull.Value);
                else
                    command.Parameters.Add("@Id_second_pl_team", MySqlDbType.UInt64).Value = group.Id_second_pl_team;

                command.Parameters.Add("@Letter", MySqlDbType.VarChar).Value = group.Letter;
                var n = command.ExecuteNonQuery();
                if (n == 1) state = true;
                group.Id_group = (uint)command.LastInsertedId;
                connection.Close();
            }
            return state;
        }

        #endregion
    }
}
