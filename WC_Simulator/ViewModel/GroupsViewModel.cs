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

        private ObservableCollection<Team> _allTeams;


        private Schedule _scheduleInfo;

        private ObservableCollection<Single_match> _matches;


        #endregion


        #region Constructor

        public GroupsViewModel(MainModel model, NavigationStore navigationStore)
        {
            Model = model;
            NavigationStore = navigationStore;

            _teamsA = new ObservableCollection<TeamInGroup>()
            {
                new TeamInGroup(1, "../../Resources/Flags/polska.png", "Poland", 3, 3, 3, 3),
                new TeamInGroup(2, "../../Resources/Flags/belgia.png", "Belgia", 3, 3, 3, 3),
                new TeamInGroup(3, "../../Resources/Flags/holadnia.png", "Holandia", 3, 3, 3, 3),
                new TeamInGroup(4, "../../Resources/Flags/walia.png", "Walia", 3, 3, 3, 3)
            };
            _teamsB = new ObservableCollection<TeamInGroup>();
            _teamsC = new ObservableCollection<TeamInGroup>();
            _teamsD = new ObservableCollection<TeamInGroup>();
            _teamsE = new ObservableCollection<TeamInGroup>();
            _teamsF = new ObservableCollection<TeamInGroup>();
            _teamsF = new ObservableCollection<TeamInGroup>();
            _teamsG = new ObservableCollection<TeamInGroup>();
            _teamsH = new ObservableCollection<TeamInGroup>();


            AllTeams = new ObservableCollection<Team> { new Team(1, 1, "Senegal", "SEN", "Aliou Cissé", (float)0.5, (float)0.5), new Team(2, 1, "Holandia", "NED", "Louis van Gaal", (float)0.5, (float)0.5) };
            //AllTeams.Add(new Team(1, "Senegal", "SEN", "Aliou Cissé", (float)0.5, (float)0.5));
            //AllTeams.Add(new Team(1, "Holandia", "NED", "Louis van Gaal", (float)0.5, (float)0.5));
            Matches = new ObservableCollection<Single_match> { new Single_match(AllTeams[0], AllTeams[1], 1, 1, 0, 0) };
        }

        #endregion


        #region Properties

        public ObservableCollection<Team> AllTeams
        {
            get { return _allTeams; }
            set
            {
                _allTeams = value;
                OnPropertyChanged(nameof(AllTeams));
            }
        }


        public ObservableCollection<TeamInGroup> TeamsA
        {
            get { return _teamsA; }
            set
            {
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

        public ObservableCollection<Single_match> Matches
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
