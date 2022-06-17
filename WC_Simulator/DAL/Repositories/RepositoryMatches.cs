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
    class RepositoryMatches
    {
        #region QUERIES
        private const string ALL_MATCH = "SELECT * FROM `single_match`";
        private const string ADD_MATCH = "INSERT INTO `single_match`(`id_match`, `id_first_team`, `id_second_team`," +
            " `id_tournament`, `abbr_first`, `abbr_second`, `name_first`, `name_second`, `match_code`, `goals_first_team`, `goals_second_team`) VALUES ";
        private const string DELETE_MATCH = "DELETE FROM `single_match` WHERE id_match = ";
        //private const string UPDATE_MATCH = "UPDATE `single_match` SET xx WHERE id_match = ";
        #endregion

        #region CRUD
        public static List<Single_match> LoadMatch()
        {
            List<Single_match> match = new List<Single_match>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_MATCH, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    match.Add(new Single_match(reader));
                connection.Close();
            }
            return match;
        }

        public static bool AddMatch(Single_match match)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ADD_MATCH} {match.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                state = true;
                match.Id_match = (uint)command.LastInsertedId;
                connection.Close();
            }
            return state;
        }

        public static bool UpdateMatch(Single_match match, uint idMatch)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string UPDATE_MATCH = $"UPDATE Single_match SET id_match='{match.Id_match}', id_first_team='{match.Id_first_team}', " +
                    $"id_second_team={match.Id_second_team}, id_tournament='{match.Id_tournament}', abbr_first='{match.Short_first}', " +
                    $"abbr_second='{match.Short_second}', name_first='{match.Name_first}', name_second='{match.Name_second}', " +
                    $"match_code='{match.Match_code}', goals_first_team='{match.Goals_first_team}', goals_second_team='{match.Goals_second_team}' WHERE id_match={idMatch}";

                MySqlCommand command = new MySqlCommand(UPDATE_MATCH, connection);
                connection.Open();
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
        #endregion
    }
}
