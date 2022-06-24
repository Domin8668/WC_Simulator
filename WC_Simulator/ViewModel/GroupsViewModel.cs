using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WC_Simulator.DAL.Entities;
using WC_Simulator.DAL.Repositories;
using WC_Simulator.Helpers.Stores;
using WC_Simulator.Model;
using WC_Simulator.ViewModel.BaseClasses;

namespace WC_Simulator.ViewModel
{
    class GroupsViewModel : BaseViewModel
    {
        #region Variables

        //private ObservableCollection<TeamInGroup> _teamsA;
        //private ObservableCollection<TeamInGroup> _teamsB;
        //private ObservableCollection<TeamInGroup> _teamsC;
        //private ObservableCollection<TeamInGroup> _teamsD;
        //private ObservableCollection<TeamInGroup> _teamsE;
        //private ObservableCollection<TeamInGroup> _teamsF;
        //private ObservableCollection<TeamInGroup> _teamsG;
        //private ObservableCollection<TeamInGroup> _teamsH;

        //private ObservableCollection<ObservableCollection<TeamInGroup>> _groupsTeams;
        //private ObservableCollection<ObservableCollection<Single_match>> _groupsMatches;

        //private int _currentGroup;

        //private ObservableCollection<Team> _allTeams;

        //private Schedule _scheduleInfo;

        //private ObservableCollection<Single_match> _matchesA;
        //private ObservableCollection<Single_match> _matchesB;
        //private ObservableCollection<Single_match> _matchesC;
        //private ObservableCollection<Single_match> _matchesD;
        //private ObservableCollection<Single_match> _matchesE;
        //private ObservableCollection<Single_match> _matchesF;
        //private ObservableCollection<Single_match> _matchesG;
        //private ObservableCollection<Single_match> _matchesH;
        #endregion


        #region Constructor

        public GroupsViewModel(MainModel model, NavigationStore navigationStore)
        {
            Model = model;
            NavigationStore = navigationStore;

            Model.CurrentGroup = 0;
            Model.PreviousGroup = 0;
            if (Model.GroupsMatches.Count == 8)
                CheckStandings.Execute(null);

            //NavigationStore.CurrentTournamentChanged += OnCurrentTournamentChanged;
        }

        #endregion


        #region Subscribers

        //private void OnCurrentTournamentChanged()
        //{
        //    OnPropertyChanged(nameof(Model.GroupsMatches));
        //    OnPropertyChanged(nameof(Model.GroupsTeams));
        //}

        #endregion


        #region Properties



        #endregion


        #region Methods

        public ObservableCollection<TeamInGroup> PrepareStanding(ObservableCollection<Single_match> groupMatches, int group)
        {
            // matches gf ga points
            var goalsfor = new int[4] { 0, 0, 0, 0 };
            var goalsagainst = new int[4] { 0, 0, 0, 0 };
            var points = new int[4] { 0, 0, 0, 0 };
            //1
            goalsfor[0] = (int)groupMatches[0].Goals_first_team + (int)groupMatches[2].Goals_first_team + (int)groupMatches[4].Goals_second_team;
            goalsagainst[0] = (int)groupMatches[0].Goals_second_team + (int)groupMatches[2].Goals_second_team + (int)groupMatches[4].Goals_first_team;
            points[0] = Points_for_match(groupMatches[0], 0) + Points_for_match(groupMatches[2], 0) + Points_for_match(groupMatches[4], 1);
            //2
            goalsfor[1] = (int)groupMatches[0].Goals_second_team + (int)groupMatches[3].Goals_second_team + (int)groupMatches[5].Goals_first_team;
            goalsagainst[1] = (int)groupMatches[0].Goals_first_team + (int)groupMatches[3].Goals_first_team + (int)groupMatches[5].Goals_second_team;
            points[1] = Points_for_match(groupMatches[0], 1) + Points_for_match(groupMatches[3], 1) + Points_for_match(groupMatches[5], 0);
            //3
            goalsfor[2] = (int)groupMatches[1].Goals_first_team + (int)groupMatches[2].Goals_second_team + (int)groupMatches[5].Goals_second_team;
            goalsagainst[2] = (int)groupMatches[1].Goals_second_team + (int)groupMatches[2].Goals_first_team + (int)groupMatches[5].Goals_first_team;
            points[2] = Points_for_match(groupMatches[1], 0) + Points_for_match(groupMatches[2], 1) + Points_for_match(groupMatches[5], 1);
            //4
            goalsfor[3] = (int)groupMatches[1].Goals_second_team + (int)groupMatches[3].Goals_first_team + (int)groupMatches[4].Goals_first_team;
            goalsagainst[3] = (int)groupMatches[1].Goals_first_team + (int)groupMatches[3].Goals_second_team + (int)groupMatches[4].Goals_second_team;
            points[3] = Points_for_match(groupMatches[1], 1) + Points_for_match(groupMatches[3], 0) + Points_for_match(groupMatches[4], 0);

            var teams_list = new List<TeamInGroup>
            {
                new TeamInGroup(Model.AllTeams[group * 4], 3, goalsfor[0], goalsagainst[0], points[0]),
                new TeamInGroup(Model.AllTeams[group * 4 + 1], 3, goalsfor[1], goalsagainst[1], points[1]),
                new TeamInGroup(Model.AllTeams[group * 4 + 2], 3, goalsfor[2], goalsagainst[2], points[2]),
                new TeamInGroup(Model.AllTeams[group * 4 + 3], 3, goalsfor[3], goalsagainst[3], points[3])
            };

            teams_list = teams_list.Select(p => p).OrderByDescending(p => p.Points).ThenByDescending(p => Math.Abs(p.GF - p.GA)).ThenByDescending(p => p.GF).ToList();

            for (int i = 0; i < teams_list.Count; i++)
            {
                teams_list[i].Position = (i + 1).ToString() + ".";
            }


            return new ObservableCollection<TeamInGroup>(teams_list);

        }

        public int Points_for_match(Single_match match, int who)
        {
            int goalsfirst = (int)match.Goals_first_team;
            int goalssecond = (int)match.Goals_second_team;

            if (goalsfirst == goalssecond)
            {
                return 1;
            }
            else if (goalsfirst > goalssecond)
            {
                if (who == 0)
                {
                    return 3;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                if (who == 0)
                {
                    return 0;
                }
                else
                {
                    return 3;
                }
            }


        }

        public void CalculateStats()
        {
            foreach (var team in Model.GroupsTeams[Model.CurrentGroup])
            {
                foreach (var match in Model.GroupsMatches[Model.CurrentGroup])
                {
                    if (match.Name_first == team.Country)
                    {
                        var points = Points_for_match(match, 0);
                        if (points == 3)
                            team.Wins += 1;
                        else if (points == 1)
                            team.Draws += 1;
                        else
                            team.Losses += 1;
                    }
                    else if (match.Name_second == team.Country)
                    {
                        var points = Points_for_match(match, 1);
                        if (points == 3)
                            team.Wins += 1;
                        else if (points == 1)
                            team.Draws += 1;
                        else
                            team.Losses += 1;
                    }
                }
            }
        }

        public void UpdateGroupInDB(int group)
        {
            RepositoryMatches.UpdateMatch(Model.GroupsMatches[group][0]);
            RepositoryMatches.UpdateMatch(Model.GroupsMatches[group][1]);
            RepositoryMatches.UpdateMatch(Model.GroupsMatches[group][2]);
            RepositoryMatches.UpdateMatch(Model.GroupsMatches[group][3]);
            RepositoryMatches.UpdateMatch(Model.GroupsMatches[group][4]);
            RepositoryMatches.UpdateMatch(Model.GroupsMatches[group][5]);
        }

        #endregion


        #region Commands

        private ICommand _checkStandings = null;

        public ICommand CheckStandings
        {
            get
            {
                if (_checkStandings == null)
                {
                    _checkStandings = new RelayCommand(arg =>
                    {
                        bool check = true;
                        if (Model.GroupsMatches.Count == 8)
                        {
                            foreach (var x in Model.GroupsMatches[Model.CurrentGroup])
                            {
                                if (x.Goals_first_team == null || x.Goals_second_team == null)
                                {
                                    check = false;
                                    break;
                                }
                            }
                            if (check)
                            {
                                Model.GroupsTeams[Model.CurrentGroup] = PrepareStanding(Model.GroupsMatches[Model.CurrentGroup], Model.CurrentGroup);
                                CalculateStats();
                                Model.CurrentTournamentGroups[Model.CurrentGroup].Id_first_pl_team = (uint?)Model.GroupsTeams[Model.CurrentGroup][0].Id;
                                Model.CurrentTournamentGroups[Model.CurrentGroup].Id_second_pl_team = (uint?)Model.GroupsTeams[Model.CurrentGroup][1].Id;
                                RepositoryGroups.UpdateGroup(Model.CurrentTournamentGroups[Model.CurrentGroup]);
                                UpdateGroupInDB(Model.CurrentGroup);
                            }
                        }
                    },
                    arg => true);
                }
                return _checkStandings;
            }
        }

        private ICommand _groupSelectionChanged = null;

        public ICommand GroupSelectionChanged
        {
            get
            {
                if (_groupSelectionChanged == null)
                {
                    _groupSelectionChanged = new RelayCommand(arg =>
                    {
                        if (Model.GroupsMatches.Count == 8)
                        {
                            UpdateGroupInDB(Model.PreviousGroup);
                            Model.PreviousGroup = Model.CurrentGroup;
                            CheckStandings.Execute(null);
                        }
                    },
                    arg => true);
                }
                return _groupSelectionChanged;
            }
        }

        #endregion
    }
}
