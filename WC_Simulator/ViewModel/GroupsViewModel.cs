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


        //private Schedule _scheduleInfo;

        private ObservableCollection<Single_match> _matchesA;
        private ObservableCollection<Single_match> _matchesB;
        private ObservableCollection<Single_match> _matchesC;
        private ObservableCollection<Single_match> _matchesD;
        private ObservableCollection<Single_match> _matchesE;
        private ObservableCollection<Single_match> _matchesF;
        private ObservableCollection<Single_match> _matchesG;
        private ObservableCollection<Single_match> _matchesH;



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


            Prepare_Teams();
            PrepareMatchesA();
            PrepareMatchesB();
            PrepareMatchesC();
            PrepareMatchesD();  
            PrepareMatchesE();
            PrepareMatchesF();
            PrepareMatchesG();
            PrepareMatchesH();

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

        //public Schedule ScheduleInfo
        //{
        //    get { return _scheduleInfo; }
        //    set
        //    {
        //        _scheduleInfo = value;
        //        OnPropertyChanged(nameof(Schedule));
        //    }
        //}

        public ObservableCollection<Single_match> MatchesA
        {
            get { return _matchesA; }
            set
            {
                _matchesA = value;
                OnPropertyChanged(nameof(MatchesA));
            }
        }
        public ObservableCollection<Single_match> MatchesB
        {
            get { return _matchesB; }
            set
            {
                _matchesB = value;
                OnPropertyChanged(nameof(MatchesB));
            }
        }
        public ObservableCollection<Single_match> MatchesC
        {
            get { return _matchesC; }
            set
            {
                _matchesC = value;
                OnPropertyChanged(nameof(MatchesC));
            }
        }
        public ObservableCollection<Single_match> MatchesD
        {
            get { return _matchesD; }
            set
            {
                _matchesD = value;
                OnPropertyChanged(nameof(MatchesD));
            }
        }
        public ObservableCollection<Single_match> MatchesE
        {
            get { return _matchesE; }
            set
            {
                _matchesE = value;
                OnPropertyChanged(nameof(MatchesE));
            }
        }
        public ObservableCollection<Single_match> MatchesF
        {
            get { return _matchesF; }
            set
            {
                _matchesF = value;
                OnPropertyChanged(nameof(MatchesF));
            }
        }
        public ObservableCollection<Single_match> MatchesG
        {
            get { return _matchesG; }
            set
            {
                _matchesG = value;
                OnPropertyChanged(nameof(MatchesG));
            }
        }
        public ObservableCollection<Single_match> MatchesH
        {
            get { return _matchesH; }
            set
            {
                _matchesH = value;
                OnPropertyChanged(nameof(MatchesH));
            }
        }

        #endregion

        #region Methods

        public void Prepare_Teams()
        {
            AllTeams = new ObservableCollection<Team> {
            new Team(1, "Katar", "QAT", "Félix Sánchez Bas", (float)0.5, (float)0.5),
            new Team(1, "Ekwador", "ECU", "Gustavo Alfaro", (float)0.5, (float)0.5),
            new Team(1, "Senegal", "SEN", "Aliou Cissé", (float)0.5, (float)0.5),
            new Team(1, "Holandia", "NED", "Louis van Gaal", (float)0.5, (float)0.5),

            new Team(2, "Anglia", "ENG", "Gareth Southgate", (float)0.5, (float)0.5),
            new Team(2, "Iran", "IRN", "Dragan Skočić", (float)0.5, (float)0.5),
            new Team(2, "Stany Zjednoczone", "USA", "Gregg Berhalter", (float)0.5, (float)0.5),
            new Team(2, "Walia", "WAL", "Robert Page", (float)0.5, (float)0.5),

            new Team(3, "Argentyna", "ARG", "Lionel Scaloni", (float)0.5, (float)0.5),
            new Team(3, "Arabia Saudyjska", "KSA", "Hervé Renard", (float)0.5, (float)0.5),
            new Team(3, "Meksyk", "MEX", "Gerardo Martino", (float)0.5, (float)0.5),
            new Team(3, "Polska", "POL", "Czesław Michniewicz", (float)0.5, (float)0.5),

            new Team(4, "Francja", "FRA", "Didier Deschamps", (float)0.5, (float)0.5),
            new Team(4, "Australia", "AUS", "Graham Arnold", (float)0.5, (float)0.5),
            new Team(4, "Dania", "DEN", "Kasper Hjulmand", (float)0.5, (float)0.5),
            new Team(4, "Tunezja", "TUN", "Mondher Kebaier", (float)0.5, (float)0.5),

            new Team(5, "Hiszpania", "ESP", "Luis Enrique", (float)0.5, (float)0.5),
            new Team(5, "Kostaryka", "CRC", "Luis Fernando Suárez", (float)0.5, (float)0.5),
            new Team(5, "Niemcy", "GER", "Hans-Dieter Flick", (float)0.5, (float)0.5),
            new Team(5, "Japonia", "JPN", "Hajime Moriyasu", (float)0.5, (float)0.5),

            new Team(6, "Belgia", "BEL", "Roberto Martínez", (float)0.5, (float)0.5),
            new Team(6, "Kanada", "CAN", "John Herdman", (float)0.5, (float)0.5),
            new Team(6, "Maroko", "MAR", "Vahid Halilhodžić", (float)0.5, (float)0.5),
            new Team(6, "Chorwacja", "CRO", "Zlatko Dalić", (float)0.5, (float)0.5),

            new Team(7, "Brazylia", "BRA", "Tite", (float)0.5, (float)0.5),
            new Team(7, "Serbia", "SRB", "Dragan Stojković", (float)0.5, (float)0.5),
            new Team(7, "Szwajcaria", "SUI", "Murat Yakın", (float)0.5, (float)0.5),
            new Team(7, "Kamerun", "CMR", "Rigobert Song", (float)0.5, (float)0.5),

            new Team(8, "Portugalia", "POR", "Fernando Santos", (float)0.5, (float)0.5),
            new Team(8, "Ghana", "GHA", "Otto Addo", (float)0.5, (float)0.5),
            new Team(8, "Urugwaj", "URU", "Diego Alonso", (float)0.5, (float)0.5),
            new Team(8, "Korea Południowa", "KOR", "Paulo Bento", (float)0.5, (float)0.5)
            };
        }

        public void PrepareMatchesA()
        {
            int i = 0 * 4;
            MatchesA = new ObservableCollection<Single_match>();

            MatchesA.Add(new Single_match(1, AllTeams[i+2], AllTeams[i+3],  1, 0, 0));
            MatchesA.Add(new Single_match(1, AllTeams[i], AllTeams[i+1],  0, 0, 0));

            MatchesA.Add(new Single_match(1, AllTeams[i], AllTeams[i+2],  17, 0, 0));
            MatchesA.Add(new Single_match(1, AllTeams[i+3], AllTeams[i+1],  18, 0, 0));

            MatchesA.Add(new Single_match(1, AllTeams[i+1], AllTeams[i+2],  34, 0, 0));
            MatchesA.Add(new Single_match(1, AllTeams[i+3], AllTeams[i],  35, 0, 0));
        }

        public void PrepareMatchesB()
        {
            int i = 1 * 4;
            MatchesB = new ObservableCollection<Single_match>();

            MatchesB.Add(new Single_match(1, AllTeams[i], AllTeams[i + 1], 0, 0, 0));
            MatchesB.Add(new Single_match(1, AllTeams[i + 2], AllTeams[i + 3], 1, 0, 0));

            MatchesB.Add(new Single_match(1, AllTeams[i + 3], AllTeams[i + 1], 18, 0, 0));
            MatchesB.Add(new Single_match(1, AllTeams[i], AllTeams[i + 2], 17, 0, 0));

            MatchesB.Add(new Single_match(1, AllTeams[i + 3], AllTeams[i], 35, 0, 0));
            MatchesB.Add(new Single_match(1, AllTeams[i + 1], AllTeams[i + 2], 34, 0, 0));
        }

        public void PrepareMatchesC()
        {
            int i = 2 * 4;
            MatchesC = new ObservableCollection<Single_match>();

            MatchesC.Add(new Single_match(1, AllTeams[i], AllTeams[i + 1], 0, 0, 0));
            MatchesC.Add(new Single_match(1, AllTeams[i + 2], AllTeams[i + 3], 1, 0, 0));

            MatchesC.Add(new Single_match(1, AllTeams[i + 3], AllTeams[i + 1], 18, 0, 0));
            MatchesC.Add(new Single_match(1, AllTeams[i], AllTeams[i + 2], 17, 0, 0));

            MatchesC.Add(new Single_match(1, AllTeams[i + 3], AllTeams[i], 35, 0, 0));
            MatchesC.Add(new Single_match(1, AllTeams[i + 1], AllTeams[i + 2], 34, 0, 0));
        }

        public void PrepareMatchesD()
        {
            int i = 3 * 4;
            MatchesD = new ObservableCollection<Single_match>();

            MatchesD.Add(new Single_match(1, AllTeams[i + 2], AllTeams[i + 3], 1, 0, 0));
            MatchesD.Add(new Single_match(1, AllTeams[i], AllTeams[i + 1], 0, 0, 0));

            MatchesD.Add(new Single_match(1, AllTeams[i + 3], AllTeams[i + 1], 18, 0, 0));
            MatchesD.Add(new Single_match(1, AllTeams[i], AllTeams[i + 2], 17, 0, 0));

            MatchesD.Add(new Single_match(1, AllTeams[i + 1], AllTeams[i + 2], 34, 0, 0));
            MatchesD.Add(new Single_match(1, AllTeams[i + 3], AllTeams[i], 35, 0, 0));

        }


        public void PrepareMatchesE()
        {
            int i = 4 * 4;
            MatchesE = new ObservableCollection<Single_match>();

            MatchesE.Add(new Single_match(1, AllTeams[i + 2], AllTeams[i + 3], 1, 0, 0));
            MatchesE.Add(new Single_match(1, AllTeams[i], AllTeams[i + 1], 0, 0, 0));

            MatchesE.Add(new Single_match(1, AllTeams[i + 3], AllTeams[i + 1], 18, 0, 0));
            MatchesE.Add(new Single_match(1, AllTeams[i], AllTeams[i + 2], 17, 0, 0));

            MatchesE.Add(new Single_match(1, AllTeams[i + 3], AllTeams[i], 35, 0, 0));
            MatchesE.Add(new Single_match(1, AllTeams[i + 1], AllTeams[i + 2], 34, 0, 0));
        }

        public void PrepareMatchesF()
        {
            int i = 5 * 4;
            MatchesF = new ObservableCollection<Single_match>();

            MatchesF.Add(new Single_match(1, AllTeams[i + 2], AllTeams[i + 3], 1, 0, 0));
            MatchesF.Add(new Single_match(1, AllTeams[i], AllTeams[i + 1], 0, 0, 0));

            MatchesF.Add(new Single_match(1, AllTeams[i], AllTeams[i + 2], 17, 0, 0));
            MatchesF.Add(new Single_match(1, AllTeams[i + 3], AllTeams[i + 1], 18, 0, 0));


            MatchesF.Add(new Single_match(1, AllTeams[i + 3], AllTeams[i],  35, 0, 0));
            MatchesF.Add(new Single_match(1, AllTeams[i + 1], AllTeams[i + 2], 34, 0, 0));
        }
        public void PrepareMatchesG()
        {
            int i = 6 * 4;
            MatchesG = new ObservableCollection<Single_match>();

            MatchesG.Add(new Single_match(1, AllTeams[i + 2], AllTeams[i + 3], 1, 0, 0));
            MatchesG.Add(new Single_match(1, AllTeams[i], AllTeams[i + 1],  0, 0, 0));

            MatchesG.Add(new Single_match(1, AllTeams[i + 3], AllTeams[i + 1], 18, 0, 0));
            MatchesG.Add(new Single_match(1, AllTeams[i], AllTeams[i + 2], 17, 0, 0));

            MatchesG.Add(new Single_match(1, AllTeams[i + 1], AllTeams[i + 2], 34, 0, 0));
            MatchesG.Add(new Single_match(1, AllTeams[i + 3], AllTeams[i], 35, 0, 0));

        }
        public void PrepareMatchesH()
        {
            int i = 7 * 4;
            MatchesH = new ObservableCollection<Single_match>();

            MatchesH.Add(new Single_match(1, AllTeams[i + 2], AllTeams[i + 3], 1, 0, 0));
            MatchesH.Add(new Single_match(1, AllTeams[i], AllTeams[i + 1], 0, 0, 0));

            MatchesH.Add(new Single_match(1, AllTeams[i + 3], AllTeams[i + 1], 18, 0, 0));
            MatchesH.Add(new Single_match(1, AllTeams[i], AllTeams[i + 2], 17, 0, 0));

            MatchesH.Add(new Single_match(1, AllTeams[i + 1], AllTeams[i + 2], 34, 0, 0));
            MatchesH.Add(new Single_match(1, AllTeams[i + 3], AllTeams[i], 35, 0, 0));

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
