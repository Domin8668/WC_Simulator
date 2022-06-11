using WC_Simulator.Model;

namespace WC_Simulator.ViewModel
{
    internal class MatchViewModel
    {
        #region Variables

        private MainModel _model;
        private string _t1FlagImg;
        private string _t1ShortName;
        private string _t1Result;

        private string _t2FlagImg;
        private string _t2ShortName;
        private string _t2Result;

        #endregion


        #region Constructor

        public MatchViewModel(MainModel model)
        {
            Model = model;
        }
        public MatchViewModel()
        {
            
        }

        public MatchViewModel(string flag1, string team1, string res1, string flag2, string team2, string res2)
        {
            T1FlagImg = $"../../Resources/Flags/{flag1.ToLower()}";
            T1ShortName = team1;
            T1Result = res1;
            T2FlagImg = $"../../Resources/Flags/{flag2.ToLower()}";
            T2ShortName = team2;
            T2Result = res2;
        }
        #endregion


        #region Properties
        public MainModel Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public string T1FlagImg
        {
            get { return _t1FlagImg; }
            set { _t1FlagImg = value; }
        }

        public string T1ShortName
        {
            get { return _t1ShortName; }
            set { _t1ShortName = value; }
        }

        public string T1Result
        {
            get { return _t1Result; }
            set { _t1Result = value; }
        }

        public string T2FlagImg
        {
            get { return _t2FlagImg; }
            set { _t2FlagImg = value; }
        }

        public string T2ShortName
        {
            get { return _t2ShortName; }
            set { _t2ShortName = value; }
        }

        public string T2Result
        {
            get { return _t2Result; }
            set { _t2Result = value; }
        }

        #endregion
    }
}
