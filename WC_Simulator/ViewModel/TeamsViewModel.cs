using System.Collections.ObjectModel;
using WC_Simulator.DAL.Entities;
using WC_Simulator.Helpers.Stores;
using WC_Simulator.Model;
using WC_Simulator.ViewModel.BaseClasses;

namespace WC_Simulator.ViewModel
{
    class TeamsViewModel : BaseViewModel
    {
        #region Variables

        private ObservableCollection<TeamInTeams> _teams;
        private TeamInTeams _selectedTeam;

        #endregion


        #region Constructors

        public TeamsViewModel(MainModel model, NavigationStore navigationStore)
        {
            Model = model;
            NavigationStore = navigationStore;

            _teams = new ObservableCollection<TeamInTeams>();
            //group stage
            CalculateStats();
            //after group
            LoadTeamsInTeams();
            //after 1/8
            StatsForStage(0, "1/8 finału");
            //after 1/4
            StatsForStage(1, "1/4 finału");
            //after 1/2
            StatsForStage(2, "");
            //after finals
            StatsOfFinalStage();
            _selectedTeam = Teams[0];
        }

        #endregion


        #region Properties

        public ObservableCollection<TeamInTeams> Teams
        {
            get { return _teams; }
            set
            {
                _teams = value;
                OnPropertyChanged(nameof(_teams));
            }
        }

        public TeamInTeams SelectedTeam
        {
            get { return _selectedTeam; }
            set
            {
                _selectedTeam = value;
                OnPropertyChanged(nameof(SelectedTeam));
            }
        }

        #endregion


        #region Methods
        private void StatsOfFinalStage()
        {
                if (Model.KnockoutsMatches[3][0].Goals_first_team != null || Model.KnockoutsMatches[3][0].Goals_second_team != null)
                {
                    Teams[(int)Model.KnockoutsMatches[3][0].Id_first_team - 1].GF += (int)Model.KnockoutsMatches[3][0].Goals_first_team;
                    Teams[(int)Model.KnockoutsMatches[3][0].Id_first_team - 1].GA += (int)Model.KnockoutsMatches[3][0].Goals_second_team;
                    Teams[(int)Model.KnockoutsMatches[3][0].Id_first_team - 1].Matches += 1;
                    Teams[(int)Model.KnockoutsMatches[3][0].Id_second_team - 1].GF += (int)Model.KnockoutsMatches[3][0].Goals_second_team;
                    Teams[(int)Model.KnockoutsMatches[3][0].Id_second_team - 1].GA += (int)Model.KnockoutsMatches[3][0].Goals_first_team;
                    Teams[(int)Model.KnockoutsMatches[3][0].Id_second_team - 1].Matches += 1;
                    if ((int)Model.KnockoutsMatches[3][0].Goals_first_team > (int)Model.KnockoutsMatches[3][0].Goals_second_team)
                    {
                        Teams[(int)Model.KnockoutsMatches[3][0].Id_first_team - 1].Wins += 1;
                        Teams[(int)Model.KnockoutsMatches[3][0].Id_second_team - 1].Losses += 1;
                        Teams[(int)Model.KnockoutsMatches[3][0].Id_first_team - 1].Phase = "1 miejsce";
                        Teams[(int)Model.KnockoutsMatches[3][0].Id_second_team - 1].Phase = "2 miejsce";
                    }
                    else
                    {
                        Teams[(int)Model.KnockoutsMatches[3][0].Id_second_team - 1].Wins += 1;
                        Teams[(int)Model.KnockoutsMatches[3][0].Id_first_team - 1].Losses += 1;
                        Teams[(int)Model.KnockoutsMatches[3][0].Id_first_team - 1].Phase = "2 miejsce";
                        Teams[(int)Model.KnockoutsMatches[3][0].Id_second_team - 1].Phase = "1 miejsce";
                    }
                }
            if (Model.KnockoutsMatches[3][1].Goals_first_team != null || Model.KnockoutsMatches[3][1].Goals_second_team != null)
            {
                Teams[(int)Model.KnockoutsMatches[3][1].Id_first_team - 1].GF += (int)Model.KnockoutsMatches[3][1].Goals_first_team;
                Teams[(int)Model.KnockoutsMatches[3][1].Id_first_team - 1].GA += (int)Model.KnockoutsMatches[3][1].Goals_second_team;
                Teams[(int)Model.KnockoutsMatches[3][1].Id_first_team - 1].Matches += 1;
                Teams[(int)Model.KnockoutsMatches[3][1].Id_second_team - 1].GF += (int)Model.KnockoutsMatches[3][1].Goals_second_team;
                Teams[(int)Model.KnockoutsMatches[3][1].Id_second_team - 1].GA += (int)Model.KnockoutsMatches[3][1].Goals_first_team;
                Teams[(int)Model.KnockoutsMatches[3][1].Id_second_team - 1].Matches += 1;
                if ((int)Model.KnockoutsMatches[3][1].Goals_first_team > (int)Model.KnockoutsMatches[3][1].Goals_second_team)
                {
                    Teams[(int)Model.KnockoutsMatches[3][1].Id_first_team - 1].Wins += 1;
                    Teams[(int)Model.KnockoutsMatches[3][1].Id_second_team - 1].Losses += 1;
                    Teams[(int)Model.KnockoutsMatches[3][1].Id_first_team - 1].Phase = "3 miejsce";
                    Teams[(int)Model.KnockoutsMatches[3][1].Id_second_team - 1].Phase = "4 miejsce";
                }
                else
                {
                    Teams[(int)Model.KnockoutsMatches[3][1].Id_second_team - 1].Wins += 1;
                    Teams[(int)Model.KnockoutsMatches[3][1].Id_first_team - 1].Losses += 1;
                    Teams[(int)Model.KnockoutsMatches[3][1].Id_first_team - 1].Phase = "4 miejsce";
                    Teams[(int)Model.KnockoutsMatches[3][1].Id_second_team - 1].Phase = "3 miejsce";
                }
            }
        }

        private void StatsForStage(int phaseInt, string phaseString)
        {
            foreach (var match in Model.KnockoutsMatches[phaseInt])
            {
                if (match.Goals_first_team != null || match.Goals_second_team != null)
                {
                    Teams[(int)match.Id_first_team - 1].GF += (int)match.Goals_first_team;
                    Teams[(int)match.Id_first_team - 1].GA += (int)match.Goals_second_team;
                    Teams[(int)match.Id_first_team - 1].Matches += 1;
                    Teams[(int)match.Id_first_team - 1].Phase = phaseString;

                    Teams[(int)match.Id_second_team - 1].GF += (int)match.Goals_second_team;
                    Teams[(int)match.Id_second_team - 1].GA += (int)match.Goals_first_team;
                    Teams[(int)match.Id_second_team - 1].Matches += 1;
                    Teams[(int)match.Id_second_team - 1].Phase = phaseString;

                    if ((int)match.Goals_first_team > (int)match.Goals_second_team)
                    {
                        Teams[(int)match.Id_first_team - 1].Wins += 1;
                        Teams[(int)match.Id_second_team - 1].Losses += 1;
                    }
                    else
                    {
                        Teams[(int)match.Id_second_team - 1].Wins += 1;
                        Teams[(int)match.Id_first_team - 1].Losses += 1;
                    }
                }
            }
        }

        private void LoadTeamsInTeams()
        {
            foreach (var team in Model.AllTeams)
            {
                ObservableCollection<string> players = new ObservableCollection<string>();
                foreach (var player in Model.AllPlayers)
                {
                    if (player.Id_team == team.Id_team)
                    {
                        players.Add(player.ToString());
                    }
                }

                TeamInGroup tig = null;
                foreach (var group in Model.GroupsTeams)
                {
                    foreach (var teamInGroup in group)
                    {
                        if (teamInGroup.Country == team.Name)
                            tig = teamInGroup;
                    }
                }
                Teams.Add(new TeamInTeams(team, tig, players, "Faza grupowa"));
            }
        }

        public void CalculateStats()
        {
            for (int i = 0; i < Model.CurrentTournamentGroups.Count; i++)
            {
                foreach (var team in Model.GroupsTeams[i])
                {
                    team.GF = 0;
                    team.GA = 0;
                    team.Matches = 0;
                    team.Wins = 0;
                    team.Draws = 0;
                    team.Losses = 0;
                    team.Points = 0;
                    foreach (var match in Model.GroupsMatches[i])
                    {
                        if (match.Name_first == team.Country)
                        {
                            if (match.Goals_first_team != null || match.Goals_second_team != null)
                            {
                                team.Matches += 1;
                                team.GF += (int)match.Goals_first_team;
                                team.GA += (int)match.Goals_second_team;
                                var points = Points_for_match(match, 0);
                                if (points == 3)
                                    team.Wins += 1;
                                else if (points == 1)
                                    team.Draws += 1;
                                else
                                    team.Losses += 1;
                                team.Points += points;
                            }
                        }
                        else if (match.Name_second == team.Country)
                        {
                            if (match.Goals_first_team != null || match.Goals_second_team != null)
                            {
                                team.Matches += 1;
                                team.GF += (int)match.Goals_second_team;
                                team.GA += (int)match.Goals_first_team;
                                var points = Points_for_match(match, 1);
                                if (points == 3)
                                    team.Wins += 1;
                                else if (points == 1)
                                    team.Draws += 1;
                                else
                                    team.Losses += 1;
                                team.Points += points;
                            }
                        }
                    }
                }
            }
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

        #endregion
    }
}
