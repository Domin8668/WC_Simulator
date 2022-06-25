using MySql.Data.MySqlClient;
using System.Collections.Generic;
using WC_Simulator.DAL.Entities;

namespace WC_Simulator.DAL.Repositories
{

    class RepositoryTeams
    {
        #region QUERIES

        private const string ALL_TEAM = "SELECT * FROM `team`";

        #endregion


        #region CRUD

        public static List<Team> LoadTeam()
        {
            List<Team> team = new List<Team>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_TEAM, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    team.Add(new Team(reader));
                connection.Close();
            }
            return team;
        }

        #endregion
    }
}
