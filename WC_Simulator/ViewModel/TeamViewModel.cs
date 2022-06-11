using System.Collections.ObjectModel;
using WC_Simulator.Model;
using WC_Simulator.ViewModel.BaseClasses;

namespace WC_Simulator.ViewModel
{
    internal class TeamViewModel : BaseViewModel
    {
        // niepotrzebne -> 
        #region Variables

        private MainModel _model;
        private string _teamname;
        private string _coach;
        private string _image;
        private ObservableCollection<string> _teamItems;

        #endregion

        #region Constructor

        public TeamViewModel(MainModel model)
        {
            Model = model;
        }

        public TeamViewModel(string teamname, string coachname, ObservableCollection<string> team)
        {
            _teamItems = team;
            _teamname = teamname;
            _coach = coachname;
            _image = $"../../Resources/Flags/{teamname.ToLower()}.png";
            
        }

        #endregion

        #region Properties

        public MainModel Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public string TeamName
        {
            get { return _teamname; }
            set { _teamname = value; }
        }

        public string Coach
        {
            get { return _coach; }
            set { _coach = value;
                OnPropertyChanged(nameof(Coach));
            }
        }

        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public ObservableCollection<string> TeamItems
        {
            get { return _teamItems; }
            set { _teamItems = value; }
        }



        #endregion

        #region Dependencies
        #endregion
    }
}
