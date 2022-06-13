using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC_Simulator.DAL.Entities;
using WC_Simulator.ViewModel.BaseClasses;
using WC_Simulator.Model;
using WC_Simulator.Helpers.Stores;
using System.Collections.ObjectModel;

namespace WC_Simulator.ViewModel
{
    class GroupsViewModel : BaseViewModel
    {

        #region Variables

        private MainModel _model;
        private NavigationStore _navigationStore;

        private ObservableCollection<TeamInGroup> _teamsInGroup;
        #endregion


        #region Constructor

        public GroupsViewModel(MainModel model, NavigationStore navigationStore)
        {
            _model = model;
            _navigationStore = navigationStore;

            _teamsInGroup = new ObservableCollection<TeamInGroup>()
            {
                new TeamInGroup(1, "../../Resources/Flags/poland.png", "Poland", 3, 3, 3, 3)
            };
        }

        #endregion


        #region Properties

        public ObservableCollection<TeamInGroup> TeamsA
        {
            get { return _teamsInGroup; }
            set {
                _teamsInGroup = value;
                OnPropertyChanged(nameof(TeamsA));
            }
        }

        #endregion


        #region Commands

        // barebone ICommand to copy:
        //private ICommand _login = null;


        //public ICommand Login
        //{
        //    get
        //    {
        //        if (_login == null)
        //        {
        //            _login = new RelayCommand(arg => {

        //            },
        //            arg => true);
        //        }
        //        return _login;
        //    }
        //}

        #endregion

    }
}
