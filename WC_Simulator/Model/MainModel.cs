using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WC_Simulator.DAL.Entities;
using WC_Simulator.DAL.Repositories;

namespace WC_Simulator.Model
{
    class MainModel
    {
        /// <summary>
        /// Mechanizm w Modelu zapewnia możliwość wykonywania operacji na obiektach z automatycznym
        /// aktualizowaniem ich odpowiedników w bazie danych. Edycja np. Playera powoduje aktualizację
        /// bazy danych oraz aktualizuje obiekt tego Playera w kolekcji obiektów.
        /// </summary>


        #region Variables

        private UserShort _currentUserShort;
        private User _currentUser;

        #endregion


        #region Constructor

        public MainModel()
        {
            _currentUserShort = new UserShort();
            _currentUser = new User();

            //pobranie danych z bazy do kolekcji za pomocą Repozytoriów

            var usersshort = RepositoryUserShorts.LoadUserShort();
            foreach (var us in usersshort)
            {
                AllUsersShort.Add(us);
                Console.WriteLine(us.Login);
            }

            var groups = RepositoryGroups.LoadGroup();
            foreach (var g in groups)
            {
                AllGroups.Add(g);
                Console.WriteLine(g.Letter);
            }
            //var matches = RepositoryMatches.LoadMatch();
            //foreach (var m in matches)
            //    AllMatches.Add(m);
            //var players = RepositoryPlayers.LoadPlayer();
            //foreach (var p in players)
            //    AllPlayers.Add(p);
            //var teams = RepositoryTeams.LoadTeam();
            //foreach (var t in teams)
            //    AllTeams.Add(t);
        }

        #endregion


        #region Properties

        // kolekcje obiektów poszczególnych zbiorów encji

        public ObservableCollection<UserShort> AllUsersShort { get; set; } = new ObservableCollection<UserShort>();

        public ObservableCollection<Player> AllPlayers { get; set; } = new ObservableCollection<Player>();

        public ObservableCollection<Single_group> AllGroups { get; set; } = new ObservableCollection<Single_group>();

        public ObservableCollection<Single_match> AllMatches { get; set; } = new ObservableCollection<Single_match>();

        public ObservableCollection<Team> AllTeams { get; set; } = new ObservableCollection<Team>();

        public ObservableCollection<Tournament> AllTournaments { get; set; } = new ObservableCollection<Tournament>();

        public User CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        public UserShort CurrentUserShort
        {
            get { return _currentUserShort; }
            set { _currentUserShort = value; }
        }

        #endregion


        #region Methods

        internal bool CheckLogin()
        {

            return false;
        }
        
        internal void ValidateUser()
        {
            throw new NotImplementedException();
        }

        internal void LoadUserTournaments()
        {
            var tournament = RepositoryTournaments.LoadTournament();
            foreach (var t in tournament)
                AllTournaments.Add(t);
        }

        #endregion
    }
}
