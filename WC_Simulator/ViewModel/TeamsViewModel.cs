using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
            LoadTeamsInTeams();
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

        #endregion
    }
}
