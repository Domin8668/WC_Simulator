using System.Collections.ObjectModel;
using WC_Simulator.Helpers.Stores;
using WC_Simulator.Model;
using WC_Simulator.ViewModel.BaseClasses;

namespace WC_Simulator.ViewModel
{
    internal class MatchViewModel : BaseViewModel
    {
        #region Variables

        private MainModel _model;

        private string _coach1;
        private string _image1;
        private string _teamName1;
        private ObservableCollection<string> _team1;

        private string _coach2;
        private string _image2;
        private string _teamName2;
        private ObservableCollection<string> _team2;

        private string _date;
        private string _hour;
        private string _location;

        private string _referee;
        private string _teamGoals1;
        private string _teamGoals2;

        private NavigationStore _navigationStore;

        #endregion


        #region Constructor

        public MatchViewModel(MainModel model, NavigationStore navigationStore)
        {
            Model = model;
            NavigationStore = navigationStore;

            Location = "Moje serce";
            Referee = "Kruża";
            TeamGoals1 = "miliun";
            TeamGoals2 = "-2";
            Date = "Wczoraj";
            Hour = "15:00";

            TeamName1 = "PolskaHusaria";
            TeamName2 = "Szwaby";
            Image1 = $"../../Resources/Flags/poland.png";
            Image2 = $"../../Resources/Flags/germany.png";
            Coach1 = "Król Czesio";
            Coach2 = "Jakiś Random";
            Team1 = new ObservableCollection<string>() { "Lewy", "Cash" };
            Team2 = new ObservableCollection<string>() { "Gnabry", "Werner" };
            NavigationStore = navigationStore;

        }

        public MatchViewModel(string flag1, string team1, string res1, string flag2, string team2, string res2)
        {
            //T1ShortName = team1;
            //T1Result = res1;
            //T2FlagImg = $"../../Resources/Flags/{flag2.ToLower()}";
            //T2ShortName = team2;
            //T2Result = res2;
        }
        #endregion


        #region Properties
        //public MainModel Model
        //{
        //    get { return _model; }
        //    set { _model = value; }
        //}

        public string Coach1
        {
            get { return _coach1; }
            set { _coach1 = value; }
        }

        public string TeamName1
        {
            get { return _teamName1; }
            set { _teamName1 = value; }
        }

        public string Image1
        {
            get { return _image1; }
            set { _image1 = value; }
        }

        public ObservableCollection<string> Team1
        {
            get { return _team1; }
            set { _team1 = value; }
        }

        public string Coach2
        {
            get { return _coach2; }
            set { _coach2 = value; }
        }

        public string TeamName2
        {
            get { return _teamName2; }
            set { _teamName2 = value; }
        }

        public string Image2
        {
            get { return _image2; }
            set { _image2 = value; }
        }

        public ObservableCollection<string> Team2
        {
            get { return _team2; }
            set { _team2 = value; }
        }

        public string TeamGoals1
        {
            get { return _teamGoals1; }
            set { _teamGoals1 = value; }
        }

        public string TeamGoals2
        {
            get { return _teamGoals2; }
            set { _teamGoals2 = value; }
        }

        public string Referee
        {
            get { return _referee; }
            set { _referee = value; }
        }

        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string Hour
        {
            get { return _hour; }
            set { _hour = value; }
        }


        //public NavigationStore NavigationStore
        //{
        //    get { return _navigationStore; }
        //    set { _navigationStore = value; }
        //}


        #endregion
    }
}
