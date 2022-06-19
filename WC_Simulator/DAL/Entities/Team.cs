using MySql.Data.MySqlClient;

namespace WC_Simulator.DAL.Entities
{
    public class Team
    {
        #region Properties

        public int Id_team { get; set; }

        public int Group_letter { get; set; }

        public string Name { get; set; }

        public string Short_name { get; set; }

        public string Coach { get; set; }

        public float Def_factor { get; set; }

        public float Att_factor { get; set; }

        #endregion


        #region Constructors

        public Team(MySqlDataReader reader)
        {
            Id_team = int.Parse(reader["id_team"].ToString());
            var letter = reader["group_letter"].ToString();
            switch (letter)
            {
                case "A":
                    Group_letter = 1;
                    break;
                case "B":
                    Group_letter = 2;
                    break;
                case "C":
                    Group_letter = 3;
                    break;
                case "D":
                    Group_letter = 4;
                    break;
                case "E":
                    Group_letter = 5;
                    break;
                case "F":
                    Group_letter = 6;
                    break;
                case "G":
                    Group_letter = 7;
                    break;
                case "H":
                    Group_letter = 8;
                    break;
                default:
                    Group_letter = 1;
                    break;
            }

            Name = reader["name"].ToString();
            Short_name = reader["short_name"].ToString();
            Coach = reader["coach"].ToString();
            Def_factor = float.Parse(reader["def_factor"].ToString());
            Att_factor = float.Parse(reader["att_factor"].ToString());
        }

        public Team(int group_letter, string name, string short_name, string coach, float def_factor, float att_factor)
        {
            Group_letter = group_letter;
            Name = name;
            Short_name = short_name;
            Coach = coach;
            Def_factor = def_factor;
            Att_factor = att_factor;
        }

        public Team(Team team)
        {
            Id_team =  team.Id_team;
            Group_letter = team.Group_letter;
            Name = team.Name;
            Short_name = team.Short_name;
            Coach = team.Coach;
            Def_factor = team.Def_factor;
            Att_factor = team.Att_factor;
        }

        #endregion


        #region Methods

        public override string ToString()
        {
            return Name;
        }

        public string ToInsert()
        {
            return $"('{Id_team}', '{Group_letter}', '{Name}', '{Short_name}', '{Coach}', '{Def_factor}', '{Att_factor}')";
        }

        public override bool Equals(object obj)
        {
            var team = obj as Team;
            if (team is null) return false;
            if (Id_team != team.Id_team) return false;
            if (Group_letter != team.Group_letter) return false;
            if (Name.ToLower() != team.Name.ToLower()) return false;
            if (Short_name.ToLower() != team.Short_name.ToLower()) return false;
            if (Coach.ToLower() != team.Coach.ToLower()) return false;
            if (Def_factor != team.Def_factor) return false;
            if (Att_factor != team.Att_factor) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}
