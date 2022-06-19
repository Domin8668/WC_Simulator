using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WC_Simulator.DAL.Entities;

namespace WC_Simulator.DAL.Repositories
{
    
    class RepositoryPlayers
    {
        #region QUERIES

        private const string ALL_PLAYER = "SELECT * FROM `player`";
        
        #endregion


        #region CRUD

        public static List<Player> LoadPlayer()
        {
            List<Player> player = new List<Player>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_PLAYER, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    player.Add(new Player(reader));
                connection.Close();
            }
            return player;
        }

        #endregion
    }
}
