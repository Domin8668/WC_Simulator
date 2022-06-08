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
        #endregion

        #region Constructors
        public Tournament(MySqlDataReader reader)
        {
            Id_tournament = uint.Parse(reader["id_tournament"].ToString());
            Id_user = uint.Parse(reader["id_user"].ToString());
        }

        public Tournament(uint id_user)
        {
            Id_tournament = null;
            Id_user = id_user;
        }

        public Tournament(Tournament tournament)
        {
            Id_tournament = tournament.Id_tournament;
            Id_user = tournament.Id_user;
        }

        #endregion

        #region Methods

        // chyba nieużywane u nas
        //public override string ToString()
        //{
        //    return $"";
        //}

        public string ToInsert()
        {
            return $"('{Id_tournament}', '{Id_user}')";
        }
        public override bool Equals(object obj)
        {
            var tournament = obj as Tournament;
            if (tournament is null) return false;
            if (Id_tournament != tournament.Id_tournament) return false;
            if (Id_user != tournament.Id_user) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

    }
}
