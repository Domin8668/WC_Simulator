using System.Collections.ObjectModel;

namespace WC_Simulator.Model
{
    public class TeamInTeams
    {
        #region Variables

        private string _image;
        private string _country;

        private int _matches;
        private int _wins;
        private int _losses;
        private int _draws;
        private int _points;

        private string _coach;
        private string _phase;

        private ObservableCollection<string> _players;

        #endregion


        #region Constructor

        public TeamInTeams(int wins, int losses ,int draws, string image, string country, string coach,  int matches, int points, ObservableCollection<string> players, string phase)
        {
            _image = image;
            _country = country;

            _losses = losses;
            _wins = wins;
            _draws = draws;
            _matches = matches;
            _points = points;
            _phase = phase;
            _coach = coach;
            _players = players;
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

        #endregion

        public override string ToString()
        {
            return "test";
        }
    }
}
