using MySql.Data.MySqlClient;
using System;

namespace WC_Simulator.DAL.Entities
{
    class Single_group
    {
        #region Properties

        public uint? Id_group { get; set; }

        public uint? Id_first_pl_team { get; set; }

        public uint? Id_second_pl_team { get; set; }

        public uint Id_tournament { get; set; }

        public Alphabet Letter { get; set; }

        public enum Alphabet
        {
            A,
            B,
            C,
            D,
            E,
            F,
            G,
            H
        }

        #endregion


        #region Constructors

        public Single_group(MySqlDataReader reader)
        {
            Id_group = uint.Parse(reader["id_group"].ToString());
            if (Convert.IsDBNull(reader["id_first_pl_team"]))
                Id_first_pl_team = null;
            else
                Id_first_pl_team = uint.Parse(reader["id_first_pl_team"].ToString());
            if (Convert.IsDBNull(reader["id_second_pl_team"]))
                Id_second_pl_team = null;
            else
                Id_second_pl_team = uint.Parse(reader["id_second_pl_team"].ToString());
            Id_tournament = uint.Parse(reader["id_tournament"].ToString());
            Letter = (Alphabet)Enum.Parse(typeof(Alphabet), reader["letter"].ToString());
        }

        public Single_group(uint? id_first_pl_team, uint? id_second_pl_team, uint id_tournament, Enum letter)
        {
            Id_group = null;
            Id_first_pl_team = id_first_pl_team;
            Id_second_pl_team = id_second_pl_team;
            Id_tournament = id_tournament;
            Letter = (Alphabet)letter;
        }

        #endregion


        #region Methods

        public override string ToString()
        {
            return $"Grupa: {Letter}";
        }

        public string ToInsert()
        {
            return $"('{Id_group}', '{Id_first_pl_team}', {Id_second_pl_team}, '{Id_tournament}', '{Letter}')";
        }

        #endregion
    }
}
