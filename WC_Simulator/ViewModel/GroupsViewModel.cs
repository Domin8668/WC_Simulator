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
using System.ComponentModel;

namespace WC_Simulator.ViewModel
{
    class GroupsViewModel : BaseViewModel
    {

        #region Variables

        private ObservableCollection<TeamInGroup> _teamsA;
        //private string _team2ShortName;
        private BindingList<string> _test;

        #endregion


        #region Constructor

        public GroupsViewModel(MainModel model, NavigationStore navigationStore)
        {
            Model = model;
            NavigationStore = navigationStore;

            _teamsA = new ObservableCollection<TeamInGroup>()
            {
                new TeamInGroup(1, "../../Resources/Flags/poland.png", "Poland", 3, 3, 3, 3),
                new TeamInGroup(2, "../../Resources/Flags/belgium.png", "Belgia", 3, 3, 3, 3),
                new TeamInGroup(3, "../../Resources/Flags/netherlands.png", "Holandia", 3, 3, 3, 3),
                new TeamInGroup(4, "../../Resources/Flags/wales.png", "Walia", 3, 3, 3, 3)
            };
            //Team2ShortName = "ARG";
            Test = new BindingList<string>()
            {
                "1",
                "2"
            };
        }

        #endregion


        #region Properties

        public ObservableCollection<TeamInGroup> TeamsA
        {
            get { return _teamsA; }
            set {
                _teamsA = value;
                OnPropertyChanged(nameof(TeamsA));
            }
        }

        //public string Team2ShortName
        //{
        //    get { return _team2ShortName; }
        //    set {
        //        _team2ShortName = value;
        //        OnPropertyChanged(nameof(Team2ShortName));
        //    }
        //}

        public BindingList<string> Test
        {
            get { return _test; }
            set
            {
                _test = value;
                OnPropertyChanged(nameof(Test));
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
