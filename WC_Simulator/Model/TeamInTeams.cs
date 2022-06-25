using System.Collections.ObjectModel;
using WC_Simulator.DAL.Entities;

namespace WC_Simulator.Model
{
    public class TeamInTeams
    {
        #region Variables

        private int _teamId;
        private string _image;
        private string _country;

        private int _matches;
        private int _wins;
        private int _losses;
        private int _draws;
        private int _points;
        private int _gf;
        private int _ga;

        private string _coach;
        private string _phase;

        private ObservableCollection<string> _players;

        #endregion


        #region Constructor

        public TeamInTeams(Team team, TeamInGroup teamInGroup, ObservableCollection<string> players, string phase)
        {
            _teamId = team.Id_team;
            _image = $"../../Resources/Flags/{team.Name.Split(' ')[0]}.png";
            _country = team.Name;

            _coach = team.Coach;
            _players = players;

            _matches = teamInGroup.Matches;
            _points = teamInGroup.Points;
            _wins = teamInGroup.Wins;
            _draws = teamInGroup.Draws;
            _losses = teamInGroup.Losses;
            _gf = teamInGroup.GF;
            _ga = teamInGroup.GA;
            _phase = phase;
        }

        #endregion


        #region Properties

        public int Draws
        {
            get { return _draws; }
            set { _draws = value; }
        }

        public int Wins
        {
            get { return _wins; }
            set { _wins = value; }
        }

        public int Losses
        {
            get { return _losses; }
            set { _losses = value; }
        }

        public ObservableCollection<string> Players
        {
            get { return _players; }
            set { _players = value; }
        }

        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public string Phase
        {
            get { return _phase; }
            set { _phase = value; }
        }

        public string Coach
        {
            get { return _coach; }
            set { _coach = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public int Matches
        {
            get { return _matches; }
            set { _matches = value; }
        }

        public int Points
        {
            get { return _points; }
            set { _points = value; }
        }

        public int TeamId
        {
            get { return _teamId; }
            set { _teamId = value; }
        }

        public int GF
        {
            get { return _gf; }
            set { _gf = value; }
        }

        public int GA
        {
            get { return _ga; }
            set { _ga = value; }
        }

        #endregion


        #region Methods

        public override string ToString()
        {
            return Country;
        }

        #endregion
    }
}
