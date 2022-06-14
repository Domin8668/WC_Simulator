using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WC_Simulator.Helpers.Stores;
using WC_Simulator.Model;
using WC_Simulator.ViewModel.BaseClasses;

namespace WC_Simulator.ViewModel
{
    class TeamsViewModel : BaseViewModel
    {

        private ObservableCollection<TeamInTeams> _teams;
        private TeamInTeams _selectedTeam;


        public TeamsViewModel(MainModel model, NavigationStore navigationStore)
        {
            Model = model;
            NavigationStore = navigationStore;

            _teams = new ObservableCollection<TeamInTeams>()
            {
                new TeamInTeams(1,2,3, "../../Resources/Flags/wales.png", "Walia", "ktoś", 6, 4, new ObservableCollection<string> { "Bale", "Ramsey"}, "1/8 finału"),
                new TeamInTeams(1,2,3, "../../Resources/Flags/poland.png", "Polska", "Czesio", 6, 4, new ObservableCollection<string> { "Zieliński", "Krychowiak"}, "ćwierćfinał"),
                new TeamInTeams(1,2,3, "../../Resources/Flags/belgium.png", "Belgia", "Czesio", 6, 4, new ObservableCollection<string> { "De Bruyne", "Hazard"}, "Finał"),
                new TeamInTeams(1,2,3, "../../Resources/Flags/germany.png", "Niemcy", "Czesio", 6, 4, new ObservableCollection<string> { "Lewandowski", "Muller"}, "Mecz o 3 msc"),
                new TeamInTeams(1,2,3, "../../Resources/Flags/spain.png", "Hiszpania", "Czesio", 6, 4, new ObservableCollection<string> { "Torres", "Villa"}, "faza grupowa")
            };
            SelectedTeam = _teams.FirstOrDefault();
        }





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

    }
}
