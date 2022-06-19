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
        private Tournament _currentTournament;
        private ObservableCollection<Single_group> _currentTournamentGroups;
        private ObservableCollection<Single_match> _currentTournamentMatches;

        private ObservableCollection<ObservableCollection<TeamInGroup>> _groupsTeams;
        private ObservableCollection<ObservableCollection<Single_match>> _groupsMatches;
        private ObservableCollection<ObservableCollection<Single_match>> _knockoutsMatches;

        private int _currentGroup;

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

            var teams = RepositoryTeams.LoadTeam();
            foreach (var t in teams)
            {
                AllTeams.Add(t);
            }

            var players = RepositoryPlayers.LoadPlayer();
            foreach (var p in players)
            {
                AllPlayers.Add(p);
            }

            PrepareEmptyGroupTeams();
            GroupsMatches = new ObservableCollection<ObservableCollection<Single_match>>();
            CurrentTournamentGroups = new ObservableCollection<Single_group>();
            CurrentTournamentMatches = new ObservableCollection<Single_match>();
        }

        #endregion


        #region Properties

        #region Entities collections

        public ObservableCollection<UserShort> AllUsersShort { get; set; } = new ObservableCollection<UserShort>();

        public ObservableCollection<User> AllUsers { get; set; } = new ObservableCollection<User>();

        public ObservableCollection<Player> AllPlayers { get; set; } = new ObservableCollection<Player>();

        public ObservableCollection<Team> AllTeams { get; set; } = new ObservableCollection<Team>();

        public ObservableCollection<Tournament> AllTournaments { get; set; } = new ObservableCollection<Tournament>();

        #endregion

        public ObservableCollection<string> SecurityQuestions { get; private set; } = new ObservableCollection<string>() {
            "Jak ma na nazwisko najlepszy napastnik?",
            "W jakim mieście się urodziłeś/łaś?",
            "Jaki był pierwszy koncert, na którym byłeś/łaś?",
            "Jakie było imię Twojego pierwszego zwierzątka?",
            "Jakie jest nazwisko panieńskie Twojej mamy?"};

        public uint[] Numbers { get; set; } = new uint[10]
        {
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9
        };

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

        public Tournament CurrentTournament
        {
            get { return _currentTournament; }
            set { _currentTournament = value; }
        }

        public ObservableCollection<Single_group> CurrentTournamentGroups
        {
            get { return _currentTournamentGroups; }
            set { _currentTournamentGroups = value; }
        }

        public ObservableCollection<Single_match> CurrentTournamentMatches
        {
            get { return _currentTournamentMatches; }
            set { _currentTournamentMatches = value; }
        }

        public int CurrentGroup
        {
            get { return _currentGroup; }
            set { _currentGroup = value; }
        }

        public ObservableCollection<ObservableCollection<Single_match>> GroupsMatches
        {
            get { return _groupsMatches; }
            set { _groupsMatches = value; }
        }

        public ObservableCollection<ObservableCollection<TeamInGroup>> GroupsTeams
        {
            get { return _groupsTeams; }
            set { _groupsTeams = value; }
        }

        public ObservableCollection<ObservableCollection<Single_match>> KnockoutsMatches
        {
            get { return _knockoutsMatches; }
            set { _knockoutsMatches = value; }
        }

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

        public void PrepareEmptyGroupTeams()
        {
            GroupsTeams = new ObservableCollection<ObservableCollection<TeamInGroup>>();
            for (int i = 0; i < 8; i++)
            {
                var this_group = new ObservableCollection<TeamInGroup>
                {
                    new TeamInGroup(AllTeams[i * 4], 0, 0, 0, 0),
                    new TeamInGroup(AllTeams[i * 4 + 1], 0, 0, 0, 0),
                    new TeamInGroup(AllTeams[i * 4 + 2], 0, 0, 0, 0),
                    new TeamInGroup(AllTeams[i * 4 + 3], 0, 0, 0, 0)
                };
                GroupsTeams.Add(this_group);
            }
        }

        public void CreateGroupMatches()
        {
            PrepareMatchesA();
            PrepareMatchesB();
            PrepareMatchesC();
            PrepareMatchesD();
            PrepareMatchesE();
            PrepareMatchesF();
            PrepareMatchesG();
            PrepareMatchesH();
        }

        public void PrepareMatchesA()
        {
            int i = 0 * 4;
            ObservableCollection<Single_match>  MatchesA = new ObservableCollection<Single_match>
            {
                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i], AllTeams[i + 1], 0, null, null),
                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i + 2], AllTeams[i + 3], 1, null, null),

                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i], AllTeams[i + 2], 17, null, null),
                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i + 3], AllTeams[i + 1], 18, null, null),

                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i + 3], AllTeams[i], 35, null, null),
                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i + 1], AllTeams[i + 2], 34, null, null)
            };
            GroupsMatches.Add(MatchesA);
        }

        public void PrepareMatchesB()
        {
            int i = 1 * 4;
            ObservableCollection<Single_match> MatchesB = new ObservableCollection<Single_match>
            {
                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i], AllTeams[i + 1], 2, null, null),
                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i + 2], AllTeams[i + 3], 3, null, null),

                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i], AllTeams[i + 2], 19, null, null),
                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i + 3], AllTeams[i + 1], 16, null, null),

                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i + 3], AllTeams[i], 32, null, null),
                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i + 1], AllTeams[i + 2], 33, null, null)
            };
            GroupsMatches.Add(MatchesB);
        }

        public void PrepareMatchesC()
        {
            int i = 2 * 4;
            ObservableCollection<Single_match> MatchesC = new ObservableCollection<Single_match>
            {
                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i], AllTeams[i + 1], 7, null, null),
                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i + 2], AllTeams[i + 3], 6, null, null),

                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i], AllTeams[i + 2], 23, null, null),
                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i + 3], AllTeams[i + 1], 21, null, null),

                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i + 3], AllTeams[i], 38, null, null),
                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i + 1], AllTeams[i + 2], 39, null, null)
            };
            GroupsMatches.Add(MatchesC);
        }

        public void PrepareMatchesD()
        {
            int i = 3 * 4;
            ObservableCollection<Single_match> MatchesD = new ObservableCollection<Single_match>
            {
                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i], AllTeams[i + 1], 4, null, null),
                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i + 2], AllTeams[i + 3], 5, null, null),

                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i], AllTeams[i + 2], 22, null, null),
                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i + 3], AllTeams[i + 1], 20, null, null),

                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i + 3], AllTeams[i], 36, null, null),
                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i + 1], AllTeams[i + 2], 37, null, null)
            };
            GroupsMatches.Add(MatchesD);
        }

        public void PrepareMatchesE()
        {
            int i = 4 * 4;
            ObservableCollection<Single_match> MatchesE = new ObservableCollection<Single_match>
            {
                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i], AllTeams[i + 1], 9, null, null),
                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i + 2], AllTeams[i + 3], 10, null, null),

                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i], AllTeams[i + 2], 27, null, null),
                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i + 3], AllTeams[i + 1], 24, null, null),

                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i + 3], AllTeams[i], 42, null, null),
                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i + 1], AllTeams[i + 2], 43, null, null)
            };
            GroupsMatches.Add(MatchesE);
        }

        public void PrepareMatchesF()
        {
            int i = 5 * 4;
            ObservableCollection<Single_match> MatchesF = new ObservableCollection<Single_match>
            {
                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i], AllTeams[i + 1], 8, null, null),
                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i + 2], AllTeams[i + 3], 11, null, null),

                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i], AllTeams[i + 2], 25, null, null),
                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i + 3], AllTeams[i + 1], 26, null, null),

                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i + 3], AllTeams[i], 40, null, null),
                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i + 1], AllTeams[i + 2], 41, null, null)
            };
            GroupsMatches.Add(MatchesF);
        }

        public void PrepareMatchesG()
        {
            int i = 6 * 4;
            ObservableCollection<Single_match> MatchesG = new ObservableCollection<Single_match>
            {
                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i], AllTeams[i + 1], 15, null, null),
                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i + 2], AllTeams[i + 3], 12, null, null),

                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i], AllTeams[i + 2], 30, null, null),
                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i + 3], AllTeams[i + 1], 28, null, null),

                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i + 3], AllTeams[i], 47, null, null),
                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i + 1], AllTeams[i + 2], 46, null, null)
            };
            GroupsMatches.Add(MatchesG);
        }

        public void PrepareMatchesH()
        {
            int i = 7 * 4;
            ObservableCollection<Single_match> MatchesH = new ObservableCollection<Single_match>
            {
                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i], AllTeams[i + 1], 14, null, null),
                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i + 2], AllTeams[i + 3], 13, null, null),

                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i], AllTeams[i + 2], 31, null, null),
                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i + 3], AllTeams[i + 1], 29, null, null),

                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i + 3], AllTeams[i], 45, null, null),
                new Single_match((uint)CurrentTournament.Id_tournament, AllTeams[i + 1], AllTeams[i + 2], 44, null, null)
            };
            GroupsMatches.Add(MatchesH);
        }

        public void PrepareEmptyKnockoutsMatches()
        {
            KnockoutsMatches = new ObservableCollection<ObservableCollection<Single_match>>();
            var oneEighthMatches = new ObservableCollection<Single_match>();
            var quarterMatches = new ObservableCollection<Single_match>();
            var semiMatches = new ObservableCollection<Single_match>();
            var finalMatches = new ObservableCollection<Single_match>();

            for (uint i = 48; i < 56; i++)
            {
                oneEighthMatches.Add(new Single_match(null, null, (uint)CurrentTournament.Id_tournament, string.Empty, string.Empty, string.Empty, string.Empty, i, null, null));
            }
            for (uint i = 56; i < 60; i++)
            {
                quarterMatches.Add(new Single_match(null, null, (uint)CurrentTournament.Id_tournament, string.Empty, string.Empty, string.Empty, string.Empty, i, null, null));
            }
            for (uint i = 60; i < 62; i++)
            {
                semiMatches.Add(new Single_match(null, null, (uint)CurrentTournament.Id_tournament, string.Empty, string.Empty, string.Empty, string.Empty, i, null, null));
            }
            for (uint i = 62; i < 64; i++)
            {
                finalMatches.Add(new Single_match(null, null, (uint)CurrentTournament.Id_tournament, string.Empty, string.Empty, string.Empty, string.Empty, i, null, null));
            }

            KnockoutsMatches.Add(oneEighthMatches);
            KnockoutsMatches.Add(quarterMatches);
            KnockoutsMatches.Add(semiMatches);
            KnockoutsMatches.Add(finalMatches);
        }

        public void JoinGroupsAndKnockouts()
        {
            foreach (var group in GroupsMatches)
            {
                foreach (var groupMatch in group)
                {
                    CurrentTournamentMatches.Add(groupMatch);
                }
            }
            foreach (var phase in KnockoutsMatches)
            {
                foreach (var knockoutMatch in phase)
                {
                    CurrentTournamentMatches.Add(knockoutMatch);
                }
            }
        }

        #endregion
    }
}
