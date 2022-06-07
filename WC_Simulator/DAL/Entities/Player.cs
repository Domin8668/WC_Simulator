using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WC_Simulator.DAL.Entities
{
    class Player
    {

        #region Własności
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

        #region Konstruktory

        //bardzo przydatny konstruktor tworzy obiekt na podstawie MySQLDataReader
        public Player(MySqlDataReader reader)
        {
            Id_player = uint.Parse(reader["id_player"].ToString());
            Id_team = uint.Parse(reader["id_team"].ToString());
            Name = reader["name"].ToString();
            Position = (PositionTypes)Enum.Parse(typeof(PositionTypes),reader["position"].ToString());
        }

        //konstruktor tworzacy obiekt nie dodany jeszcze do bazy z id pustym
        public Player(uint id_team, string name, Enum position)
        {
            Id_player = null;
            Id_team = id_team;
            Name = name.Trim();
            Position = (PositionTypes)position;
        }

        public Player(Player player)
        {
            Id_player = player.Id_player;
            Id_team = player.Id_team;
            Name = player.Name;
            Position = player.Position;
        }

        #endregion

        #region Metody

        public override string ToString()
        {
            return $"Imię i nazwisko: {Name}, pozycja: {Position}";
        }

        //metoda generuje string dla INSERT TO (nazwisko, imie, wiek, miasto)
        public string ToInsert()
        {
            return $"('{Id_player}', '{Id_team}', {Name}, '{Position}')";
        }
        //dzięki przeciążeniu tej metody Contains w liście sprawdzi czy dany obiekt do niej należy
        public override bool Equals(object obj)
        {
            //nie porównujemy ID
            var player = obj as Player;
            if (player is null) return false;
            if (Id_team != player.Id_team) return false;
            if (Name.ToLower() != player.Name.ToLower()) return false;
            if (Position != player.Position) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

    }
}
