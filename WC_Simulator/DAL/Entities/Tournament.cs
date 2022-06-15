using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WC_Simulator.DAL.Entities
{
    class Tournament
    {

        #region Properties
        public uint? Id_tournament { get; set; }
        public uint Id_user { get; set; }
        public string T_name { get; set; }
        #endregion

        #region Constructors
        public Tournament(MySqlDataReader reader)
        {
            Id_tournament = uint.Parse(reader["id_tournament"].ToString());
            Id_user = uint.Parse(reader["id_user"].ToString());
            T_name = reader["t_name"].ToString();
        }

        public Tournament(uint id_user, string t_name)
        {
            Id_tournament = null;
            Id_user = id_user;
            T_name = t_name;
        }

        public Tournament(Tournament tournament)
        {
            Id_tournament = tournament.Id_tournament;
            Id_user = tournament.Id_user;
            T_name = tournament.T_name;
        }

        #endregion

        #region Methods


        public override string ToString()
        {
            return T_name;
        }

        public string ToInsert()
        {
            return $"('{Id_tournament}', '{Id_user}', '{T_name}')";
        }

        public override bool Equals(object obj)
        {
            var tournament = obj as Tournament;
            if (tournament is null) return false;
            if (Id_tournament != tournament.Id_tournament) return false;
            if (Id_user != tournament.Id_user) return false;
            if (T_name.ToLower() != tournament.T_name.ToLower()) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

    }
}
