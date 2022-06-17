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
        private ObservableCollection<TeamInGroup> _teamsB;
        private ObservableCollection<TeamInGroup> _teamsC;
        private ObservableCollection<TeamInGroup> _teamsD;
        private ObservableCollection<TeamInGroup> _teamsE;
        private ObservableCollection<TeamInGroup> _teamsF;
        private ObservableCollection<TeamInGroup> _teamsG;
        private ObservableCollection<TeamInGroup> _teamsH;

        private Schedule _scheduleInfo;

        private BindingList<Single_match> _matches;


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
            _teamsB = new ObservableCollection<TeamInGroup>();
            _teamsC = new ObservableCollection<TeamInGroup>();
            _teamsD = new ObservableCollection<TeamInGroup>();
            _teamsE = new ObservableCollection<TeamInGroup>();
            _teamsF = new ObservableCollection<TeamInGroup>();
            _teamsF = new ObservableCollection<TeamInGroup>();
            _teamsG = new ObservableCollection<TeamInGroup>();
            _teamsH = new ObservableCollection<TeamInGroup>();



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

        public ObservableCollection<TeamInGroup> TeamsB
        {
            get { return _teamsB; }
            set
            {
                _teamsB = value;
                OnPropertyChanged(nameof(TeamsB));
            }
        }

        public ObservableCollection<TeamInGroup> TeamsC
        {
            get { return _teamsC; }
            set
            {
                _teamsC = value;
                OnPropertyChanged(nameof(TeamsC));
            }
        }

        public ObservableCollection<TeamInGroup> TeamsD
        {
            get { return _teamsD; }
            set
            {
                _teamsD = value;
                OnPropertyChanged(nameof(TeamsD));
            }
        }

        public ObservableCollection<TeamInGroup> TeamsE
        {
            get { return _teamsE; }
            set
            {
                _teamsE = value;
                OnPropertyChanged(nameof(TeamsE));
            }
        }

        public ObservableCollection<TeamInGroup> TeamsF
        {
            get { return _teamsF; }
            set
            {
                _teamsF = value;
                OnPropertyChanged(nameof(TeamsF));
            }
        }

        public ObservableCollection<TeamInGroup> TeamsG
        {
            get { return _teamsG; }
            set
            {
                _teamsG = value;
                OnPropertyChanged(nameof(TeamsG));
            }
        }

        public ObservableCollection<TeamInGroup> TeamsH
        {
            get { return _teamsH; }
            set
            {
                _teamsH = value;
                OnPropertyChanged(nameof(TeamsH));
            }
        }

        public Schedule ScheduleInfo
        {
            get { return _scheduleInfo; }
            set
            {
                _scheduleInfo = value;
                OnPropertyChanged(nameof(Schedule));
            }
        }

        public BindingList<Single_match> Matches
        {
            get { return _matches; }
            set
            {
                _matches = value;
                OnPropertyChanged(nameof(Matches));
            }
        }



        #endregion

        #region Methods

        public void Prepare_Matches()
        {
            Matches.Clear();
            Matches[0] = new Single_match(3, 4, 1, (uint)ScheduleInfo.FinalSchedule[0].MatchCode, 1, 2);
            Matches[1] = new Single_match(1, 2, 1, (uint)ScheduleInfo.FinalSchedule[1].MatchCode, 2, 1);

            Matches[2] = new Single_match(1, 2, 1, (uint)ScheduleInfo.FinalSchedule[1].MatchCode, 2, 1);
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
