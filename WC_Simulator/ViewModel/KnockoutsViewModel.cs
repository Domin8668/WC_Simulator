﻿using System.Collections.Generic;
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
        private bool _enabled18;


        #endregion


        #region Constructor

        public KnockoutsViewModel(MainModel model, NavigationStore navigationStore)
        {
            Model = model;
            NavigationStore = navigationStore;
            if (IfAllMatchesPossible())
            {
                RealTeamsRoundOf16();  
            }
            else
            {
                PreparePlaceHolders();
            }

            Enabled18 = IfAllMatchesPossible();
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

        public bool Enabled18
        {
            get { return _enabled18; }
            set
            {
                _enabled18 = value;
                OnPropertyChanged(nameof(Enabled18));
            }
        }

        #endregion


        #region Methods

        //zeby zrobic z matchcodes trzeba dodac kolejna tabele
        public void PreparePlaceHolders()
        {
            var groups = new string[8] { "A", "B", "C", "D", "E", "F", "G", "H" };

            Matches16 = new ObservableCollection<Single_match>();

            for (int i = 0; i < 4; i++)
            {
                Team Ph1 = new Team(0, "1" + groups[i * 2], "1" + groups[i * 2], "1" + groups[i * 2], 1, 1);
                Team Ph2 = new Team(0, "2" + groups[i * 2 + 1], "2" + groups[i * 2 + 1], "2" + groups[i * 2 + 1], 1, 1);
                Matches16.Add(new Single_match((uint)Model.CurrentTournament.Id_tournament, Ph1, Ph2, 100, null, null));
            }

            for (int i = 0; i < 4; i++)
            {
                Team Ph1 = new Team(0, "1" + groups[i * 2 + 1], "1" + groups[i * 2 + 1], "1" + groups[i * 2 + 1], 1, 1);
                Team Ph2 = new Team(0, "2" + groups[i * 2], "2" + groups[i * 2], "2" + groups[i * 2], 1, 1);
                Matches16.Add(new Single_match((uint)Model.CurrentTournament.Id_tournament, Ph1, Ph2, 100, null, null));
            }
        }

        public bool IfAllMatchesPossible()
        {
            var teamIdFromGroupWinnersAndRunnersUp = new List<List<uint?>>();
            bool check = true;
            for (int i = 0; i < 8; i++)
            {
                teamIdFromGroupWinnersAndRunnersUp.Add(RepositoryGroups.LoadTeamsInGroup((uint)i + 1, (uint)Model.CurrentTournament.Id_tournament));
                if (teamIdFromGroupWinnersAndRunnersUp[i][0] == null || teamIdFromGroupWinnersAndRunnersUp[i][1] == null)
                {
                    check = false;
                    break;
                }
            }
            return check;
        }


        //zeby zrobic z matchcodes trzeba dodac kolejna tabele
        public void RealTeamsRoundOf16()
        {
            Matches16 = new ObservableCollection<Single_match>();
            var teamIdFromGroupWinnersAndRunnersUp = new List<List<uint?>>();
            for (int i = 1; i < 9; i++)
            {
                teamIdFromGroupWinnersAndRunnersUp.Add(RepositoryGroups.LoadTeamsInGroup((uint)i, (uint)Model.CurrentTournament.Id_tournament));
            }
            //pierwsze 4 ćwierćfinały

            Team Ph1 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[0][0]-1];
            Team Ph2 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[1][1]-1];
            Matches16.Add(new Single_match((uint)Model.CurrentTournament.Id_tournament, Ph1, Ph2, 100, null, null));
            Model.KnockoutsMatches[0][0] = Matches16[0];
            RepositoryMatches.UpdateMatch(Model.KnockoutsMatches[0][0]);

            Ph1 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[2][0] - 1];
            Ph2 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[3][1] - 1];
            Matches16.Add(new Single_match((uint)Model.CurrentTournament.Id_tournament, Ph1, Ph2, 100, null, null));
            Model.KnockoutsMatches[0][1] = Matches16[1];
            RepositoryMatches.UpdateMatch(Model.KnockoutsMatches[0][1]);

            Ph1 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[4][0] - 1];
            Ph2 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[5][1] - 1];
            Matches16.Add(new Single_match((uint)Model.CurrentTournament.Id_tournament, Ph1, Ph2, 100, null, null));
            Model.KnockoutsMatches[0][0] = Matches16[0];
            RepositoryMatches.UpdateMatch(Model.KnockoutsMatches[0][0]);


            Ph1 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[6][0] - 1];
            Ph2 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[7][1] - 1];
            Matches16.Add(new Single_match((uint)Model.CurrentTournament.Id_tournament, Ph1, Ph2, 100, null, null));
            Model.KnockoutsMatches[0][0] = Matches16[0];
            RepositoryMatches.UpdateMatch(Model.KnockoutsMatches[0][0]);

            Ph1 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[1][0] - 1];
            Ph2 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[0][1] - 1];
            Matches16.Add(new Single_match((uint)Model.CurrentTournament.Id_tournament, Ph1, Ph2, 100, null, null));
            Model.KnockoutsMatches[0][0] = Matches16[0];
            RepositoryMatches.UpdateMatch(Model.KnockoutsMatches[0][0]);

            Ph1 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[3][0] - 1];
            Ph2 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[2][1] - 1];
            Matches16.Add(new Single_match((uint)Model.CurrentTournament.Id_tournament, Ph1, Ph2, 100, null, null));
            Model.KnockoutsMatches[0][0] = Matches16[0];
            RepositoryMatches.UpdateMatch(Model.KnockoutsMatches[0][0]);

            Ph1 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[5][0] - 1];
            Ph2 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[4][1] - 1];
            Matches16.Add(new Single_match((uint)Model.CurrentTournament.Id_tournament, Ph1, Ph2, 100, null, null));
            Model.KnockoutsMatches[0][0] = Matches16[0];
            RepositoryMatches.UpdateMatch(Model.KnockoutsMatches[0][0]);

            Ph1 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[7][0] - 1];
            Ph2 = Model.AllTeams[(int)teamIdFromGroupWinnersAndRunnersUp[6][1] - 1];
            Matches16.Add(new Single_match((uint)Model.CurrentTournament.Id_tournament, Ph1, Ph2, 100, null, null));

        }

        #endregion


        #region Commands

        //private ICommand _checkRoundOf16 = null;

        //public ICommand CheckRoundOf16
        //{
        //    get
        //    {
        //        if (_checkRoundOf16 == null)
        //        {
        //            _checkRoundOf16 = new RelayCommand(arg =>
        //            {
        //                bool check = true;
        //                foreach (var x in Model.GroupsMatches[Model.CurrentGroup])
        //                {
        //                    if (x.Goals_first_team == null || x.Goals_second_team == null)
        //                    {
        //                        check = false;
        //                        break;
        //                    }
        //                }
        //                if (check)
        //                {
        //                    Model.CurrentTournamentGroups[Model.CurrentGroup].Id_first_pl_team = (uint?)Model.GroupsTeams[Model.CurrentGroup][0].Id;
        //                    Model.CurrentTournamentGroups[Model.CurrentGroup].Id_second_pl_team = (uint?)Model.GroupsTeams[Model.CurrentGroup][1].Id;
        //                    RepositoryGroups.UpdateGroup(Model.CurrentTournamentGroups[Model.CurrentGroup]);
        //                }
        //            },
        //            arg => true);
        //        }
        //        return _checkRoundOf16;
        //    }
        //}

        #endregion
    }
}
