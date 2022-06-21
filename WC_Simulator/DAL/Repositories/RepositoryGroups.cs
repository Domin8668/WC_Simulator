using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WC_Simulator.DAL.Entities;

namespace WC_Simulator.DAL.Repositories
{

    class RepositoryGroups
    {
        #region QUERIES

        private const string ALL_GROUP = "SELECT * FROM `single_group` WHERE id_tournament = ";
        private const string ADD_GROUP = "INSERT INTO `single_group`(`id_group`, `id_first_pl_team`, `id_second_pl_team`, `id_tournament`, `letter`) VALUES ";
        private const string DELETE_GROUP = "DELETE FROM `single_group` WHERE id_group = ";

        private const string TEAMS_IN_GROUP = "SELECT * FROM `single_group` WHERE id_group = ";
        #endregion


        #region CRUD

        /// <summary>
        /// CRUD - create, read, update, delete
        /// </summary>
        /// <returns></returns>
        public static List<uint?> LoadTeamsInGroup(uint? IDgroup, uint IDtournament)
        {
            List<uint?> IDteams = new List<uint?>();
            IDgroup += 8 * (IDtournament - 1);
            using (var connection = DBConnection.Instance.Connection)
            {
                Console.WriteLine(TEAMS_IN_GROUP + $"{IDgroup}" + " and id_tournament=" + $"{IDtournament}");
                MySqlCommand command = new MySqlCommand(TEAMS_IN_GROUP + $"{IDgroup}" + " and id_tournament=" + $"{IDtournament}", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    IDteams.Add(new Single_group(reader).Id_first_pl_team);
                    IDteams.Add(new Single_group(reader).Id_second_pl_team);
                    IDteams.Add(new Single_group(reader).Id_second_pl_team);
                }
                connection.Close();
            }
            return IDteams;
        }

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
                MySqlCommand command = new MySqlCommand("UPDATE Single_group SET id_first_pl_team=@Id_first_pl_team, id_second_pl_team=@Id_second_pl_team WHERE id_group=@Id_group", connection);
                connection.Open();

                if (group.Id_first_pl_team == null)
                    command.Parameters.AddWithValue("@Id_first_pl_team", DBNull.Value);
                else
                    command.Parameters.Add("@Id_first_pl_team", MySqlDbType.UInt64).Value = group.Id_first_pl_team;

                if (group.Id_second_pl_team == null)
                    command.Parameters.AddWithValue("@Id_second_pl_team", DBNull.Value);
                else
                    command.Parameters.Add("@Id_second_pl_team", MySqlDbType.UInt64).Value = group.Id_second_pl_team;

                command.Parameters.Add("@Id_group", MySqlDbType.UInt64).Value = group.Id_group;
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
