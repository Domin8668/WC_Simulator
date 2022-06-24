using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WC_Simulator.DAL.Entities;
using WC_Simulator.DAL.Repositories;
using WC_Simulator.Helpers.Stores;
using WC_Simulator.Model;
using WC_Simulator.ViewModel.BaseClasses;

namespace WC_Simulator.ViewModel
{
    class KnockoutsViewModel : BaseViewModel
    {
        #region Variables

        private ObservableCollection<Single_match> _matches16;
        private ObservableCollection<Single_match> _matchesQ;
        private ObservableCollection<Single_match> _matchesS;
        private ObservableCollection<Single_match> _matchesF;
        private bool _enabledR16;
        private bool _enabledQ;
        private bool _enabledS;
        private bool _enabledF;


        #endregion


        #region Constructor

        public KnockoutsViewModel(MainModel model, NavigationStore navigationStore)
        {
            Model = model;
            NavigationStore = navigationStore;

            EnabledR16 = false;
            EnabledQ = false;
            EnabledS = false;
            EnabledF = false;

            //sprawdzanie gdzie mozna a gdzie nie mozna comboboxow uzyc
            if (IfAllMatchesR16Possible())
            {
                RealTeamsRoundOf16();
                EnabledR16 = true;
            }
            else
            {
                PreparePlaceHolders();
            }
            if (IfAllMatchesQSFPossible(0))
            {
                PrepareMatchesQ();
                EnabledQ = true;
                if (IfAllMatchesQSFPossible(1))
                {
                    PrepareMatchesS();
                    EnabledS = true;
                    if (IfAllMatchesQSFPossible(2))
                    {
                        PrepareMatchesF();
                        EnabledF = true;
                    }
                }
            }

            //NavigationStore.CurrentTournamentChanged += OnCurrentTournamentChanged;
        }

        #endregion


        #region Properties

        public ObservableCollection<Single_match> Matches16
        {
            get { return _matches16; }
            set
            {
                _matches16 = value;
                OnPropertyChanged(nameof(Matches16));
            }
        }

        public ObservableCollection<Single_match> MatchesQ
        {
            get { return _matchesQ; }
            set
            {
                _matchesQ = value;
                OnPropertyChanged(nameof(MatchesQ));
            }
        }

        public ObservableCollection<Single_match> MatchesS
        {
            get { return _matchesS; }
            set
            {
                _matchesS = value;
                OnPropertyChanged(nameof(MatchesS));
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

        public bool EnabledR16
        {
            get { return _enabledR16; }
            set
            {
                _enabledR16 = value;
                OnPropertyChanged(nameof(EnabledR16));
            }
        }
        public bool EnabledS
        {
            get { return _enabledS; }
            set
            {
                _enabledS = value;
                OnPropertyChanged(nameof(EnabledS));
            }
        }
        public bool EnabledQ
        {
            get { return _enabledQ; }
            set
            {
                _enabledQ = value;
                OnPropertyChanged(nameof(EnabledQ));
            }
        }
        public bool EnabledF
        {
            get { return _enabledF; }
            set
            {
                _enabledF = value;
                OnPropertyChanged(nameof(EnabledF));
            }
        }

        #endregion


        #region Subscribers

        ////private void OnCurrentTournamentChanged()
        ////{
        ////    OnPropertyChanged(nameof(Model.KnockoutsMatches));
        ////    OnPropertyChanged(nameof(Model.GroupsTeams));
        ////}

        #endregion


        #region Methods


        public bool IfAllMatchesR16Possible()
        {
            var teamIdFromGroupWinnersAndRunnersUp = new List<List<uint?>>();
            bool check = true;
            for (int i = 0; i < 8; i++)
            {
                var temp = RepositoryGroups.LoadTeamsInGroup((uint)i + 1, (uint)Model.CurrentTournament.Id_tournament);
                teamIdFromGroupWinnersAndRunnersUp.Add(temp);
                if (teamIdFromGroupWinnersAndRunnersUp[i][0] == null || teamIdFromGroupWinnersAndRunnersUp[i][1] == null)
                {
                    check = false;
                    break;
                }
            }
            return check;
        }
        public bool IfAllMatchesQSFPossible(int phase)
        {
            bool check = true;
            foreach (var x in Model.KnockoutsMatches[phase])
            {
                if (x.Goals_first_team == null || x.Goals_second_team == null || x.Goals_second_team == x.Goals_first_team)
                {
                    check = false;
                    break;
                }
            }
            return check;
        }

        public void PreparePlaceHolders()
        {
            var groups = new string[8] { "A", "B", "C", "D", "E", "F", "G", "H" };

            Matches16 = new ObservableCollection<Single_match>();

            for (int i = 0; i < 4; i++)
            {
                Team Ph1 = new Team(0, "1" + groups[i * 2], "1" + groups[i * 2], "1" + groups[i * 2], 1, 1);
                Team Ph2 = new Team(0, "2" + groups[i * 2 + 1], "2" + groups[i * 2 + 1], "2" + groups[i * 2 + 1], 1, 1);
                Matches16.Add(new Single_match((uint)Model.CurrentTournament.Id_tournament, Ph1, Ph2, 100, null, null));
                Model.KnockoutsMatches[0][i] = new Single_match(Model.KnockoutsMatches[0][i].Id_match, (uint)Model.CurrentTournament.Id_tournament, Ph1, Ph2, 100, null, null);
            }

            for (int i = 0; i < 4; i++)
            {
                Team Ph1 = new Team(0, "1" + groups[i * 2 + 1], "1" + groups[i * 2 + 1], "1" + groups[i * 2 + 1], 1, 1);
                Team Ph2 = new Team(0, "2" + groups[i * 2], "2" + groups[i * 2], "2" + groups[i * 2], 1, 1);
                Model.KnockoutsMatches[0][i + 4] = new Single_match(Model.KnockoutsMatches[0][i + 4].Id_match, (uint)Model.CurrentTournament.Id_tournament, Ph1, Ph2, 100, null, null);
            }
        }
        public void RealTeamsRoundOf16()
        {
            //zeby zrobic z matchcodes trzeba dodac kolejna tabele
            Matches16 = new ObservableCollection<Single_match>();
            var teamIdFromGroupWinnersAndRunnersUp = new List<List<uint?>>();
            for (int i = 1; i < 9; i++)
            {
                teamIdFromGroupWinnersAndRunnersUp.Add(RepositoryGroups.LoadTeamsInGroup((uint)i, (uint)Model.CurrentTournament.Id_tournament));
            }
            //pierwsze 4 ćwierćfinały
            Team Ph1, Ph2;
            for (int i = 0; i < 4; i++)
            {
                Ph1 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[i * 2][0] - 1];
                Ph2 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[i * 2 + 1][1] - 1];
                Model.KnockoutsMatches[0][i] = new Single_match(Model.KnockoutsMatches[0][i].Id_match, (uint)Model.CurrentTournament.Id_tournament, Ph1, Ph2, 100, Model.KnockoutsMatches[0][i].Goals_first_team, Model.KnockoutsMatches[0][i].Goals_second_team);
            }

            for (int i = 0; i < 4; i++)
            {
                Ph1 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[i * 2 + 1][0] - 1];
                Ph2 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[i * 2][1] - 1];
                Model.KnockoutsMatches[0][i + 4] = new Single_match(Model.KnockoutsMatches[0][i + 4].Id_match, (uint)Model.CurrentTournament.Id_tournament, Ph1, Ph2, 100, Model.KnockoutsMatches[0][i + 4].Goals_first_team, Model.KnockoutsMatches[0][i + 4].Goals_second_team);
            }


            //Team Ph1 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[0][0]-1];
            //Team Ph2 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[1][1]-1];
            //Model.KnockoutsMatches[0][0] = new Single_match(Model.KnockoutsMatches[0][0].Id_match, (uint)Model.CurrentTournament.Id_tournament, Ph1, Ph2, 100, Model.KnockoutsMatches[0][0].Goals_first_team, Model.KnockoutsMatches[0][0].Goals_second_team);
            ////Matches16.Add(new Single_match(Model.KnockoutsMatches[0][0].Id_match, (uint)Model.CurrentTournament.Id_tournament, Ph1, Ph2, 100, Model.KnockoutsMatches[0][0].Goals_first_team, Model.KnockoutsMatches[0][0].Goals_second_team));

            //Ph1 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[2][0] - 1];
            //Ph2 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[3][1] - 1];
            //Matches16.Add(new Single_match(Model.KnockoutsMatches[0][1].Id_match, (uint)Model.CurrentTournament.Id_tournament, Ph1, Ph2, 100, Model.KnockoutsMatches[0][1].Goals_first_team, Model.KnockoutsMatches[0][1].Goals_second_team));

            //Ph1 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[4][0] - 1];
            //Ph2 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[5][1] - 1];
            //Matches16.Add(new Single_match(Model.KnockoutsMatches[0][2].Id_match, (uint)Model.CurrentTournament.Id_tournament, Ph1, Ph2, 100, Model.KnockoutsMatches[0][2].Goals_first_team, Model.KnockoutsMatches[0][2].Goals_second_team));

            //Ph1 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[6][0] - 1];
            //Ph2 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[7][1] - 1];
            //Matches16.Add(new Single_match(Model.KnockoutsMatches[0][3].Id_match, (uint)Model.CurrentTournament.Id_tournament, Ph1, Ph2, 100, Model.KnockoutsMatches[0][3].Goals_first_team, Model.KnockoutsMatches[0][3].Goals_second_team));

            //Ph1 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[1][0] - 1];
            //Ph2 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[0][1] - 1];
            //Matches16.Add(new Single_match(Model.KnockoutsMatches[0][4].Id_match, (uint)Model.CurrentTournament.Id_tournament, Ph1, Ph2, 100, Model.KnockoutsMatches[0][4].Goals_first_team, Model.KnockoutsMatches[0][4].Goals_second_team));

            //Ph1 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[3][0] - 1];
            //Ph2 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[2][1] - 1];
            //Matches16.Add(new Single_match(Model.KnockoutsMatches[0][5].Id_match, (uint)Model.CurrentTournament.Id_tournament, Ph1, Ph2, 100, Model.KnockoutsMatches[0][5].Goals_first_team, Model.KnockoutsMatches[0][5].Goals_second_team));

            //Ph1 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[5][0] - 1];
            //Ph2 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[4][1] - 1];
            //Matches16.Add(new Single_match(Model.KnockoutsMatches[0][6].Id_match, (uint)Model.CurrentTournament.Id_tournament, Ph1, Ph2, 100, Model.KnockoutsMatches[0][6].Goals_first_team, Model.KnockoutsMatches[0][6].Goals_second_team));

            //Ph1 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[7][0] - 1];
            //Ph2 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[6][1] - 1];
            //Matches16.Add(new Single_match(Model.KnockoutsMatches[0][7].Id_match, (uint)Model.CurrentTournament.Id_tournament, Ph1, Ph2, 100, Model.KnockoutsMatches[0][7].Goals_first_team, Model.KnockoutsMatches[0][7].Goals_second_team));
        }
        public void PrepareMatchesQ()
        {
            //if (Matches16.Count == 8)
            //{
                for (int i = 0; i < 4; i++)
                {
                    Model.KnockoutsMatches[1][i] = new Single_match(Model.KnockoutsMatches[1][i].Id_match, (uint)Model.CurrentTournament.Id_tournament, WhichTeamWins(Model.KnockoutsMatches[0][i * 2]),
                    WhichTeamWins(Model.KnockoutsMatches[0][i * 2 + 1]), 100, Model.KnockoutsMatches[1][i].Goals_first_team, Model.KnockoutsMatches[1][i].Goals_second_team);
                }



                //MatchesQ.Add(new Single_match(Model.KnockoutsMatches[1][0].Id_match, (uint)Model.CurrentTournament.Id_tournament, WhichTeamWins(Matches16[0]),
                //    WhichTeamWins(Matches16[1]), 100, Model.KnockoutsMatches[1][0].Goals_first_team, Model.KnockoutsMatches[1][0].Goals_second_team));

                //MatchesQ.Add(new Single_match(Model.KnockoutsMatches[1][1].Id_match, (uint)Model.CurrentTournament.Id_tournament, WhichTeamWins(Matches16[2]),
                //    WhichTeamWins(Matches16[3]), 100, Model.KnockoutsMatches[1][1].Goals_first_team, Model.KnockoutsMatches[1][1].Goals_second_team));

                //MatchesQ.Add(new Single_match(Model.KnockoutsMatches[1][2].Id_match, (uint)Model.CurrentTournament.Id_tournament, WhichTeamWins(Matches16[4]),
                //    WhichTeamWins(Matches16[5]), 100, Model.KnockoutsMatches[1][2].Goals_first_team, Model.KnockoutsMatches[1][2].Goals_second_team));

                //MatchesQ.Add(new Single_match(Model.KnockoutsMatches[1][3].Id_match, (uint)Model.CurrentTournament.Id_tournament, WhichTeamWins(Matches16[6]),
            //    //    WhichTeamWins(Matches16[7]), 100, Model.KnockoutsMatches[1][3].Goals_first_team, Model.KnockoutsMatches[1][3].Goals_second_team));
            //}
        }

        public void PrepareMatchesS()
        {
            //if (MatchesQ.Count == 4)
            //{
                Model.KnockoutsMatches[2][0] = new Single_match(Model.KnockoutsMatches[2][0].Id_match, (uint)Model.CurrentTournament.Id_tournament, WhichTeamWins(Model.KnockoutsMatches[1][0]),
                    WhichTeamWins(Model.KnockoutsMatches[1][1]), 100, Model.KnockoutsMatches[2][0].Goals_first_team, Model.KnockoutsMatches[2][0].Goals_second_team);

                Model.KnockoutsMatches[2][1] = new Single_match(Model.KnockoutsMatches[2][1].Id_match, (uint)Model.CurrentTournament.Id_tournament, WhichTeamWins(Model.KnockoutsMatches[1][2]),
                    WhichTeamWins(Model.KnockoutsMatches[1][3]), 100, Model.KnockoutsMatches[2][1].Goals_first_team, Model.KnockoutsMatches[2][1].Goals_second_team);
            //}
        }

        public void PrepareMatchesF()
        {
            //if (MatchesS.Count == 2)
            //{
                Model.KnockoutsMatches[3][0] = new Single_match(Model.KnockoutsMatches[3][0].Id_match, (uint)Model.CurrentTournament.Id_tournament, WhichTeamWins(Model.KnockoutsMatches[2][0]),
                    WhichTeamWins(Model.KnockoutsMatches[2][1]), 100, Model.KnockoutsMatches[3][0].Goals_first_team, Model.KnockoutsMatches[3][0].Goals_second_team);

                Model.KnockoutsMatches[3][1] = new Single_match(Model.KnockoutsMatches[3][1].Id_match, (uint)Model.CurrentTournament.Id_tournament, WhichTeamLoses(Model.KnockoutsMatches[2][0]),
                    WhichTeamLoses(Model.KnockoutsMatches[2][1]), 100, Model.KnockoutsMatches[3][1].Goals_first_team, Model.KnockoutsMatches[3][1].Goals_second_team);
            //}
        }

        public Team WhichTeamWins(Single_match match)
        {
            if (match.Goals_first_team > match.Goals_second_team)
                return Model.AllTeams[(int)match.Id_first_team - 1];
            else
                return Model.AllTeams[(int)match.Id_second_team - 1];
        }

        public Team WhichTeamLoses(Single_match match)
        {
            if (match.Goals_first_team < match.Goals_second_team)
                return Model.AllTeams[(int)match.Id_first_team - 1];
            else
                return Model.AllTeams[(int)match.Id_second_team - 1];
        }


        //private void UpdateRoundof16()
        //{
        //    if (Matches16.Count == 8)
        //    {
        //        Model.KnockoutsMatches[0][0] = Matches16[0];
        //        RepositoryMatches.UpdateMatch(Model.KnockoutsMatches[0][0]);

        //        Model.KnockoutsMatches[0][1] = Matches16[1];
        //        RepositoryMatches.UpdateMatch(Model.KnockoutsMatches[0][1]);

        //        Model.KnockoutsMatches[0][2] = Matches16[2];
        //        RepositoryMatches.UpdateMatch(Model.KnockoutsMatches[0][2]);

        //        Model.KnockoutsMatches[0][3] = Matches16[3];
        //        RepositoryMatches.UpdateMatch(Model.KnockoutsMatches[0][3]);

        //        Model.KnockoutsMatches[0][4] = Matches16[4];
        //        RepositoryMatches.UpdateMatch(Model.KnockoutsMatches[0][4]);

        //        Model.KnockoutsMatches[0][5] = Matches16[5];
        //        RepositoryMatches.UpdateMatch(Model.KnockoutsMatches[0][5]);

        //        Model.KnockoutsMatches[0][6] = Matches16[6];
        //        RepositoryMatches.UpdateMatch(Model.KnockoutsMatches[0][6]);

        //        Model.KnockoutsMatches[0][7] = Matches16[7];
        //        RepositoryMatches.UpdateMatch(Model.KnockoutsMatches[0][7]);
        //    }
        //}
        public void UpdateRound(int phase)
        {
            //if (MatchesQ.Count == 4)
            //{
                for (int i = 0; i < Model.KnockoutsMatches[phase].Count; i++)
                {
                    RepositoryMatches.UpdateMatch(Model.KnockoutsMatches[phase][i]);
                //}
            }
        }
        //public void UpdateSemifinals()
        //{
        //    if (MatchesS.Count == 2)
        //    {
        //        Model.KnockoutsMatches[2][0] = MatchesS[0];
        //        RepositoryMatches.UpdateMatch(Model.KnockoutsMatches[2][0]);

        //        Model.KnockoutsMatches[2][1] = MatchesS[1];
        //        RepositoryMatches.UpdateMatch(Model.KnockoutsMatches[2][1]);
        //    }
        //}
        //public void UpdateFinals()
        //{
        //    if (MatchesF.Count == 2)
        //    {
        //        Model.KnockoutsMatches[3][0] = MatchesF[0];
        //        RepositoryMatches.UpdateMatch(Model.KnockoutsMatches[3][0]);

        //        Model.KnockoutsMatches[3][1] = MatchesF[1];
        //        RepositoryMatches.UpdateMatch(Model.KnockoutsMatches[3][1]);
        //    }
        //}

        #endregion


        #region Commands

        private ICommand _checkRound = null;
        public ICommand CheckRound
        {
            get
            {
                if (_checkRound == null)
                {
                    _checkRound = new RelayCommand(arg =>
                    {
                        //bool check = true;
                        //foreach (var x in Model.KnockoutsMatches[0])
                        //{
                        //    if (x.Goals_first_team == null || x.Goals_second_team == null || x.Goals_second_team == x.Goals_first_team)
                        //    {
                        //        check = false;
                        //        break;
                        //    }
                        //}
                        if (IfAllMatchesQSFPossible(0))
                        {
                            UpdateRound(0);
                            EnabledQ = true;
                            PrepareMatchesQ();
                        }
                    },
                    arg => true)
                    {

                    };
                }
                return _checkRound;
            }
        }

        private ICommand _checkQ = null;
        public ICommand CheckQ
        {
            get
            {
                if (_checkQ == null)
                {
                    _checkQ = new RelayCommand(arg =>
                    {
                        //bool check = true;
                        //foreach (var x in Model.KnockoutsMatches[1])
                        //{
                        //    if (x.Goals_first_team == null || x.Goals_second_team == null || x.Goals_second_team == x.Goals_first_team)
                        //    {
                        //        check = false;
                        //        break;
                        //    }
                        //}
                        if (IfAllMatchesQSFPossible(1))
                        {
                            UpdateRound(1);
                            EnabledS = true;
                            PrepareMatchesS();
                        }
                    },
                    arg => true);
                }
                return _checkQ;
            }
        }

        private ICommand _checkS = null;
        public ICommand CheckS
        {
            get
            {
                if (_checkS == null)
                {
                    _checkS = new RelayCommand(arg =>
                    {
                        //bool check = true;
                        //foreach (var x in Model.KnockoutsMatches[2])
                        //{
                        //    if (x.Goals_first_team == null || x.Goals_second_team == null || x.Goals_second_team == x.Goals_first_team)
                        //    {
                        //        check = false;
                        //        break;
                        //    }
                        //}
                        if (IfAllMatchesQSFPossible(2))
                        {
                            UpdateRound(2);
                            EnabledF = true;
                            PrepareMatchesF();
                        }
                    },
                    arg => true);
                }
                return _checkS;
            }
        }

        private ICommand _checkF = null;
        public ICommand CheckF
        {
            get
            {
                if (_checkF == null)
                {
                    _checkF = new RelayCommand(arg =>
                    {
                        //bool check = true;
                        //foreach (var x in Model.KnockoutsMatches[3])
                        //{
                        //    if (x.Goals_first_team == null || x.Goals_second_team == null || x.Goals_second_team == x.Goals_first_team)
                        //    {
                        //        check = false;
                        //        break;
                        //    }
                        //}
                        if (IfAllMatchesQSFPossible(3))
                        {
                            UpdateRound(3);
                            //NavigationStore.CurrentViewModel = new MessageViewModel(Model, NavigationStore, this, Visibility.Visible, $"Mistrzem Świata jest:{WhichTeamWins(Model.KnockoutsMatches[3][0]).Name}");
                        }
                    },
                    arg => true);
                }
                return _checkF;
            }
        }



        #endregion
    }
}
