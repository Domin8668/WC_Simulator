using MySql.Data.MySqlClient;
using System;

namespace WC_Simulator.DAL.Entities
{
    class Player
    {
        #region Properties

        public uint? Id_player { get; set; }

        public uint Id_team { get; set; }

        public string Name { get; set; }

        public PositionTypes Position { get; set; }

        public enum PositionTypes
        {
            Bramkarz,
            Obrońca,
            Pomocnik,
            Napastnik
        }

        #endregion


        #region Constructors

        //bardzo przydatny konstruktor tworzy obiekt na podstawie MySQLDataReader
        public Player(MySqlDataReader reader)
        {
            Id_player = uint.Parse(reader["id_player"].ToString());
            Id_team = uint.Parse(reader["id_team"].ToString());
            Name = reader["name"].ToString();
            Position = (PositionTypes)Enum.Parse(typeof(PositionTypes), reader["position"].ToString());
        }

        #endregion


        #region Methods

        public override string ToString()
        {
            return Position.ToString().PadRight(15) + Name;
        }

        #endregion
    }
}
