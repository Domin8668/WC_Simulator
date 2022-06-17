using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WC_Simulator.DAL.Entities;
using WC_Simulator.DAL.Repositories;
using WC_Simulator.Helpers.Hashing;

namespace WC_Simulator.Model
{
    class MainModel
    {
        /// <summary>
        /// Mechanizm w Modelu zapewnia możliwość wykonywania operacji na obiektach z automatycznym
        /// aktualizowaniem ich odpowiedników w bazie danych. Edycja np. Usera powoduje aktualizację
        /// bazy danych oraz aktualizuje obiekt tego Usera w kolekcji obiektów.
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

            // pobranie danych z bazy do kolekcji za pomocą Repozytoriów

            var usersshort = RepositoryUserShorts.LoadUserShort();
            foreach (var us in usersshort)
            {
                AllUsersShort.Add(us);
            }

            var users = RepositoryUsers.LoadUser();
            foreach (var u in users)
            {
                AllUsers.Add(u);
            }

            var groups = RepositoryGroups.LoadGroup();
            foreach (var g in groups)
            {
                AllGroups.Add(g);
            }

            //var tourneys = RepositoryTournaments.LoadTournament();
            //foreach (var t in tourneys)
            //{
            //    AllTournaments.Add(t);
            //}

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

        public ObservableCollection<User> AllUsers { get; set; } = new ObservableCollection<User>();

        public ObservableCollection<Player> AllPlayers { get; set; } = new ObservableCollection<Player>();

        public ObservableCollection<Single_group> AllGroups { get; set; } = new ObservableCollection<Single_group>();

        public ObservableCollection<Single_match> AllMatches { get; set; } = new ObservableCollection<Single_match>();

        public ObservableCollection<Team> AllTeams { get; set; } = new ObservableCollection<Team>();

        public ObservableCollection<Tournament> AllTournaments { get; set; } = new ObservableCollection<Tournament>();
        public ObservableCollection<string> SecurityQuestions { get; private set; } = new ObservableCollection<string>() {
            "Jak ma na nazwisko najlepszy napastnik?",
            "W jakim mieście się urodziłeś/łaś?",
            "Jaki był pierwszy koncert, na którym byłeś/łaś?",
            "Jakie było imię Twojego pierwszego zwierzątka?",
            "Jakie jest nazwisko panieńskie Twojej mamy?"};

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

        public uint[] Numbers { get; set; } = new uint[10]
        {
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9
        };

        #endregion


        #region Methods

        internal bool CheckLogin()
        {
            foreach (var us in AllUsersShort)
            {
                if (CurrentUserShort.Login == us.Login)
                    return true;
            }
            return false;
        }
        
        internal bool ValidateUserShort()
        {
            foreach (var us in AllUsersShort)
            {
                if (CurrentUserShort.Login == us.Login && new SHA256Hashing().MatchHashes(CurrentUserShort.Password, us.Password))
                {
                    return true;
                }
            }
            return false;
        }

        internal bool ValidateAnswer(string login, byte[] answer)
        {
            foreach (var u in AllUsers)
            {
                if (login == u.Login && new SHA256Hashing().MatchHashes(answer, u.Security_answer))
                {
                    return true;
                }
            }
            return false;
        }

        internal void UpdateCurrentUser()
        {
            if (CurrentUserShort != null)
            {
                foreach (var u in AllUsers)
                {
                    if (u.Login == CurrentUserShort.Login)
                    {
                        CurrentUser = u;
                        CurrentUser.Last_log_date = DateTime.Now;
                        u.Last_log_date = CurrentUser.Last_log_date;
                        RepositoryUsers.UpdateUserLastLogin(CurrentUser);
                        return;
                    }
                }
            }
        }

        internal void UpdateCurrentUserPassword()
        {
            if (CurrentUser != null)
            {
                foreach (var us in AllUsersShort)
                {
                    if (us.Login == CurrentUserShort.Login)
                    {
                        us.Password = CurrentUserShort.Password;
                    }
                }
                foreach (var u in AllUsers)
                {
                    if (u.Login == CurrentUser.Login)
                    {
                        CurrentUser = u;
                        CurrentUser.Password = CurrentUserShort.Password;
                        u.Password = CurrentUserShort.Password;
                        CurrentUser.Last_log_date = DateTime.Now;
                        u.Last_log_date = CurrentUser.Last_log_date;
                        RepositoryUsers.UpdateUserPassword(CurrentUser);
                        return;
                    }
                }
            }
        }

        internal void UpdateCurrentUserShortPassword()
        {
            if (CurrentUserShort != null)
            {
                foreach (var us in AllUsersShort)
                {
                    if (us.Login == CurrentUserShort.Login)
                    {
                        us.Password = CurrentUserShort.Password;
                    }
                }
                foreach (var u in AllUsers)
                {
                    if (u.Login == CurrentUserShort.Login)
                    {
                        CurrentUser = u;
                        CurrentUser.Password = CurrentUserShort.Password;
                        u.Password = CurrentUserShort.Password;
                        CurrentUser.Last_log_date = DateTime.Now;
                        u.Last_log_date = CurrentUser.Last_log_date;
                        RepositoryUsers.UpdateUserPassword(CurrentUser);
                        return;
                    }
                }
            }
        }

        internal void LoadUserTournaments()
        {
            var tournament = RepositoryTournaments.LoadTournament();
            foreach (var t in tournament)
            {
                if (t.Id_user == CurrentUser.Id_user)
                {
                    AllTournaments.Add(t);
                    //Console.WriteLine(t);
                }
            }    
        }

        public bool AddUserTournament(Tournament tournament)
        {
            
            if (RepositoryTournaments.AddTournament(tournament))
            {
                AllTournaments.Add(tournament);
                return true;
            }
            return false;
        }
        #endregion
    }
}
