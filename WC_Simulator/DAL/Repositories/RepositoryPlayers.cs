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
    class RepositoryPlayers
    {
        #region QUERIES
        private const string ALL_PLAYER = "SELECT * FROM `player`";
        private const string ADD_PLAYER = "INSERT INTO `player`(`id_player`, `id_team`, `name`, `position`) VALUES ";
        private const string DELETE_PLAYER = "DELETE FROM `player` WHERE id_player = ";
        //private const string UPDATE_PLAYER = "UPDATE `player` SET xx WHERE id_player = ";
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
