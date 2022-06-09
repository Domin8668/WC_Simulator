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
    class RepositoryTournaments
    {
        #region QUERIES
        private const string ALL_TOURNAMENT = "SELECT * FROM `tournament`";
        private const string ADD_TOURNAMENT = "INSERT INTO `tournament`(`id_tournament`, `id_user`) VALUES ";
        private const string DELETE_TOURNAMENT = "DELETE FROM `tournament` WHERE id_tournament = ";
        //private const string UPDATE_TOURNAMENT = "UPDATE `tournament` SET xx WHERE id_tournament = ";
        #endregion

        #region CRUD
        public static List<Tournament> LoadTournament()
        {
            List<Tournament> tournament = new List<Tournament>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_TOURNAMENT, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    tournament.Add(new Tournament(reader));
                connection.Close();
            }
            return tournament;
        }

        public static bool AddTournament(Tournament tournament)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ADD_TOURNAMENT} {tournament.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                state = true;
                tournament.Id_tournament = (uint)command.LastInsertedId;
                connection.Close();
            }
            return state;
        }

        public static bool UpdateTournament(Tournament tournament, uint idTournament)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string UPDATE_TOURNAMENT = $"UPDATE Tournament SET id_tournament='{tournament.Id_tournament}', id_user='{tournament.Id_user}'" +
                    $"WHERE id_tournament={idTournament}";

                MySqlCommand command = new MySqlCommand(UPDATE_TOURNAMENT, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) state = true;

                connection.Close();
            }
            return state;
        }

        public static bool DeleteTournament(Tournament tournament)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DELETE_TOURNAMENT} {tournament.Id_tournament}", connection);
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
