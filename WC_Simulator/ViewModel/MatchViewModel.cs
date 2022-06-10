using WC_Simulator.Model;

namespace WC_Simulator.ViewModel
{
    internal class MatchViewModel
    {
        #region Variables

        private string _flag_img;
        private string _team_short_name;
        private string _result;

        #endregion


        #region Constructor

        public MatchViewModel()
        {

        }

        public MatchViewModel(string flag, string team, string res)
        {
            _flag_img = $"../../Resources/Flags/{flag.ToLower()}";
            _team_short_name = team;
            _result = res;
        }
        #endregion


        #region Properties

        public string Flag_img
        {
            get { return _flag_img; }
            set { _flag_img = value; }
        }

        public string Team_short_name
        {
            get { return _team_short_name; }
            set { _team_short_name = value; }
        }

        public string Result
        {
            get { return _result; }
            set { _result = value; }
        }

        #endregion
    }
}
