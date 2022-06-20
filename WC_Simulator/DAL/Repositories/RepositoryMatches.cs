using System.Collections.Generic;

namespace WC_Simulator.DAL.Repositories
{
    using MySql.Data.MySqlClient;
    using System;
    using WC_Simulator.DAL;
    using WC_Simulator.DAL.Entities;
    class RepositoryMatches
    {
        #region QUERIES

        private const string ALL_MATCH = "SELECT * FROM `single_match` where id_tournament = ";
        private const string ADD_MATCH = "INSERT INTO `single_match`(`id_first_team`, `id_second_team`," +
            " `id_tournament`, `abbr_first`, `abbr_second`, `name_first`, `name_second`, `match_code`, `goals_first_team`, `goals_second_team`) VALUES ";
        private const string DELETE_MATCH = "DELETE FROM `single_match` WHERE id_match = ";
        //private const string UPDATE_MATCH = "UPDATE `single_match` SET xx WHERE id_match = ";

        #endregion


        #region CRUD

        public static List<Single_match> LoadTournamentMatch(Tournament tournament)
        {
            List<Single_match> match = new List<Single_match>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_MATCH + tournament.Id_tournament.ToString(), connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    match.Add(new Single_match(reader));
                connection.Close();
            }
            return match;
        }

        //public static bool AddMatch(Single_match match)
        //{
        //    bool state = false;
        //    using (var connection = DBConnection.Instance.Connection)
        //    {
        //        MySqlCommand command = new MySqlCommand($"{ADD_MATCH} {match.ToInsert()}", connection);
        //        connection.Open();
        //        var id = command.ExecuteNonQuery();
        //        state = true;
        //        match.Id_match = (uint)command.LastInsertedId;
        //        connection.Close();
        //    }
        //    return state;
        //}

        public static bool UpdateMatch(Single_match match)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand("UPDATE Single_match SET id_first_team=@Id_first_team, id_second_team=@Id_second_team, abbr_first=@Abbr_first, abbr_second=@Abbr_second, name_first=@Name_first, name_second=@Name_second, match_code=@Match_code, goals_first_team=@Goals_first_team, goals_second_team=@Goals_second_team WHERE id_match=@Id_match", connection);
                connection.Open();

                if (match.Id_first_team == null)
                    command.Parameters.AddWithValue("@Id_first_team", DBNull.Value);
                else
                    command.Parameters.Add("@Id_first_team", MySqlDbType.UInt64).Value = match.Id_first_team;
                if (match.Id_second_team == null)
                    command.Parameters.AddWithValue("@Id_second_team", DBNull.Value);
                else
                    command.Parameters.Add("@Id_second_team", MySqlDbType.UInt64).Value = match.Id_second_team;

                command.Parameters.Add("@Id_tournament", MySqlDbType.UInt64).Value = match.Id_tournament;

                if (match.Short_first == null)
                    command.Parameters.AddWithValue("@Abbr_first", DBNull.Value);
                else
                    command.Parameters.Add("@Abbr_first", MySqlDbType.VarChar).Value = match.Short_first;
                if (match.Short_second == null)
                    command.Parameters.AddWithValue("@Abbr_second", DBNull.Value);
                else
                    command.Parameters.Add("@Abbr_second", MySqlDbType.VarChar).Value = match.Short_second;

                if (match.Name_first == null)
                    command.Parameters.AddWithValue("@Name_first", DBNull.Value);
                else
                    command.Parameters.Add("@Name_first", MySqlDbType.VarChar).Value = match.Name_first;
                if (match.Name_second == null)
                    command.Parameters.AddWithValue("@Name_second", DBNull.Value);
                else
                    command.Parameters.Add("@Name_second", MySqlDbType.VarChar).Value = match.Name_second;

                command.Parameters.Add("@Match_code", MySqlDbType.UInt64).Value = match.Match_code;

                if (match.Goals_first_team == null)
                    command.Parameters.AddWithValue("@Goals_first_team", DBNull.Value);
                else
                    command.Parameters.Add("@Goals_first_team", MySqlDbType.UInt64).Value = match.Goals_first_team;
                if (match.Goals_second_team == null)
                    command.Parameters.AddWithValue("@Goals_second_team", DBNull.Value);
                else
                    command.Parameters.Add("@Goals_second_team", MySqlDbType.UInt64).Value = match.Goals_second_team;

                command.Parameters.Add("@Id_match", MySqlDbType.UInt64).Value = match.Id_match;

                var n = command.ExecuteNonQuery();
                if (n == 1) state = true;

                connection.Close();
            }
            return state;
        }

        public static bool DeleteMatch(Single_match match)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DELETE_MATCH} {match.Id_match}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                state = true;
                connection.Close();
            }
            return state;
        }

        internal static bool AddTournamentMatch(Single_match match)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand("INSERT INTO `single_match`(`id_first_team`, `id_second_team`, `id_tournament`, `abbr_first`, `abbr_second`, `name_first`, `name_second`, `match_code`, `goals_first_team`, `goals_second_team`) VALUES (@Id_first_team, @Id_second_team, @Id_tournament, @Abbr_first, @Abbr_second, @Name_first, @Name_second, @Match_code, @Goals_first_team, @Goals_second_team)", connection);
                connection.Open();


                if (match.Id_first_team == null)
                    command.Parameters.AddWithValue("@Id_first_team", DBNull.Value);
                else
                    command.Parameters.Add("@Id_first_team", MySqlDbType.UInt64).Value = match.Id_first_team;
                if (match.Id_second_team == null)
                    command.Parameters.AddWithValue("@Id_second_team", DBNull.Value);
                else
                    command.Parameters.Add("@Id_second_team", MySqlDbType.UInt64).Value = match.Id_second_team;

                command.Parameters.Add("@Id_tournament", MySqlDbType.UInt64).Value = match.Id_tournament;

                if (match.Short_first == null)
                    command.Parameters.AddWithValue("@Abbr_first", DBNull.Value);
                else
                    command.Parameters.Add("@Abbr_first", MySqlDbType.VarChar).Value = match.Short_first;
                if (match.Short_second == null)
                    command.Parameters.AddWithValue("@Abbr_second", DBNull.Value);
                else
                    command.Parameters.Add("@Abbr_second", MySqlDbType.VarChar).Value = match.Short_second;

                if (match.Name_first == null)
                    command.Parameters.AddWithValue("@Name_first", DBNull.Value);
                else
                    command.Parameters.Add("@Name_first", MySqlDbType.VarChar).Value = match.Name_first;
                if (match.Name_second == null)
                    command.Parameters.AddWithValue("@Name_second", DBNull.Value);
                else
                    command.Parameters.Add("@Name_second", MySqlDbType.VarChar).Value = match.Name_second;

                command.Parameters.Add("@Match_code", MySqlDbType.UInt64).Value = match.Match_code;

                if (match.Goals_first_team == null)
                    command.Parameters.AddWithValue("@Goals_first_team", DBNull.Value);
                else
                    command.Parameters.Add("@Goals_first_team", MySqlDbType.UInt64).Value = match.Goals_first_team;
                if (match.Goals_second_team == null)
                    command.Parameters.AddWithValue("@Goals_second_team", DBNull.Value);
                else
                    command.Parameters.Add("@Goals_second_team", MySqlDbType.UInt64).Value = match.Goals_second_team;

                var n = command.ExecuteNonQuery();
                if (n == 1) state = true;
                match.Id_match = (uint)command.LastInsertedId;
                connection.Close();
            }
            return state;            
        }

        #endregion
    }
}
