using MySql.Data.MySqlClient;
using System;

namespace WC_Simulator.DAL.Entities
{
    class Single_match
    {
        #region Properties

        public uint? Id_match { get; set; }

        public uint? Id_first_team { get; set; }

        public uint? Id_second_team { get; set; }

        public uint Id_tournament { get; set; }

        public string Short_first { get; set; }

        public string Short_second { get; set; }

        public string Name_first { get; set; }

        public string Name_second { get; set; }

        public string Flag_first { get; set; }

        public string Flag_second { get; set; }

        public uint Match_code { get; set; }

        public uint? Goals_first_team { get; set; }

        public uint? Goals_second_team { get; set; }

        #endregion


        #region Constructors

        public Single_match(MySqlDataReader reader)
        {
            Id_match = uint.Parse(reader["id_match"].ToString());

            if (Convert.IsDBNull(reader["id_first_team"]))
                Id_first_team = null;
            else
                Id_first_team = uint.Parse(reader["id_first_team"].ToString());
            if (Convert.IsDBNull(reader["id_second_team"]))
                Id_second_team = null;
            else
                Id_second_team = uint.Parse(reader["id_second_team"].ToString());

            Id_tournament = uint.Parse(reader["id_tournament"].ToString());
            Short_first = reader["abbr_first"].ToString();
            Short_second = reader["abbr_second"].ToString();
            Name_first = reader["name_first"].ToString();
            Name_second = reader["name_second"].ToString();

            if (Convert.IsDBNull(reader["name_first"]))
                Flag_first = $"../../Resources/Flags/placeholder.png";
            else
                Flag_first = $"../../Resources/Flags/{Name_first.Split(' ')[0]}.png";
            if (Convert.IsDBNull(reader["name_second"]))
                Flag_second = $"../../Resources/Flags/placeholder.png";
            else
                Flag_second = $"../../Resources/Flags/{Name_second.Split(' ')[0]}.png";

            Match_code = uint.Parse(reader["match_code"].ToString());

            if (Convert.IsDBNull(reader["goals_first_team"]))
                Goals_first_team = null;
            else
                Goals_first_team = uint.Parse(reader["goals_first_team"].ToString());
            if (Convert.IsDBNull(reader["goals_second_team"]))
                Goals_second_team = null;
            else
                Goals_second_team = uint.Parse(reader["goals_second_team"].ToString());
        }

        public Single_match(uint? id_first_team, uint? id_second_team, uint id_tournament, string short_first, string short_second, string name_first, string name_second, uint match_code, uint? goals_first_team, uint? goals_second_team)
        {
            Id_match = null;
            Id_first_team = id_first_team;
            Id_second_team = id_second_team;
            Id_tournament = id_tournament;
            Short_first = short_first.Trim();
            Short_second = short_second.Trim();
            Name_first = name_first.Trim();
            Name_second = name_second.Trim();
            Flag_first = $"../../Resources/Flags/{Name_first.Split(' ')[0]}.png";
            Flag_second = $"../../Resources/Flags/{Name_second.Split(' ')[0]}.png";

            if (name_first == string.Empty)
                Flag_first = "../../Resources/Flags/placeholder.png";
            else if (name_first[0] == '1' || name_first[0] == '2')
                Flag_first = "../../Resources/Flags/placeholder.png";

            if (name_second == string.Empty)
                Flag_second = "../../Resources/Flags/placeholder.png";
            else if (name_second[0] == '1' || name_second[0] == '2')
                Flag_second = "../../Resources/Flags/placeholder.png";
            Match_code = match_code;
            Goals_first_team = goals_first_team;
            Goals_second_team = goals_second_team;
        }

        public Single_match(uint id_tournament, Team team1, Team team2 , uint match_code, uint? goals_first_team, uint? goals_second_team)
        {
            Id_match = null;
            Id_tournament = id_tournament;
            Short_first = team1.Short_name.Trim();
            Short_second = team2.Short_name.Trim();
            Name_first = team1.Name.Trim();
            Name_second = team2.Name.Trim();
            Flag_first = $"../../Resources/Flags/{Name_first.Split(' ')[0]}.png";
            Flag_second = $"../../Resources/Flags/{Name_second.Split(' ')[0]}.png";
            if(team1.Name[0]== '1' || team1.Name[0]== '2')
                Flag_first = "../../Resources/Flags/placeholder.png";
            if (team2.Name[0] == '1' || team2.Name[0] == '2')
                Flag_second = "../../Resources/Flags/placeholder.png";
            Match_code = match_code;
            Goals_first_team = goals_first_team;
            Goals_second_team = goals_second_team;
        }

        public Single_match(Single_match match)
        {
            Id_match = match.Id_match;
            Id_first_team = match.Id_first_team;
            Id_second_team = match.Id_second_team;
            Id_tournament = match.Id_tournament;
            Short_first = match.Short_first;
            Short_second = match.Short_second;
            Name_first = match.Name_first;
            Name_second = match.Name_second;
            Match_code = match.Match_code;
            Flag_first = match.Flag_first;
            Flag_second = match.Flag_second;
            Goals_first_team = match.Goals_first_team;
            Goals_second_team = match.Goals_second_team;
        }

        #endregion


        #region Methods

        public override string ToString()
        {
            return $"Bramki w meczu: {Goals_first_team} : {Goals_second_team}";
        }

        //public string ToInsert()
        //{
        //    return $"('{Id_first_team}', {Id_second_team}, '{Id_tournament}', '{Short_first}', '{Short_second}', '{Name_first}', '{Name_second}', '{Match_code}', '{if (Goals_first_team == null) }', '{Goals_second_team}')";
        //}

        public override bool Equals(object obj)
        {
            if (!(obj is Single_match match)) return false;
            if (Id_match != match.Id_match) return false;
            if (Id_first_team != match.Id_first_team) return false;
            if (Id_second_team != match.Id_second_team) return false;
            if (Id_tournament != match.Id_tournament) return false;
            if (Short_first.ToLower() != match.Short_first.ToLower()) return false;
            if (Short_second.ToLower() != match.Short_second.ToLower()) return false;
            if (Name_first.ToLower() != match.Name_first.ToLower()) return false;
            if (Name_second.ToLower() != match.Name_second.ToLower()) return false;
            if (Match_code != match.Match_code) return false;
            if (Goals_first_team != match.Goals_first_team) return false;
            if (Goals_second_team != match.Goals_second_team) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}
