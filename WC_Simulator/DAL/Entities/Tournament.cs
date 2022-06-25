using MySql.Data.MySqlClient;

namespace WC_Simulator.DAL.Entities
{
    class Tournament
    {
        #region Properties

        public uint? Id_tournament { get; set; }

        public uint Id_user { get; set; }

        public string Tourney_name { get; set; }

        #endregion


        #region Constructors

        public Tournament(MySqlDataReader reader)
        {
            Id_tournament = uint.Parse(reader["id_tournament"].ToString());
            Id_user = uint.Parse(reader["id_user"].ToString());
            Tourney_name = reader["t_name"].ToString();
        }

        public Tournament(uint id_user, string t_name)
        {
            Id_tournament = null;
            Id_user = id_user;
            Tourney_name = t_name;
        }

        #endregion


        #region Methods

        public override string ToString()
        {
            return Tourney_name;
        }

        public string ToInsert()
        {
            return $"('{Id_user}', '{Tourney_name}')";
        }

        #endregion
    }
}
