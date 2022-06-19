using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC_Simulator.DAL.Entities;
using WC_Simulator.DAL.Repositories;
using System.Windows.Input;
using WC_Simulator.Helpers.Stores;
using WC_Simulator.Model;
using WC_Simulator.ViewModel.BaseClasses;
using System.Collections.ObjectModel;

namespace WC_Simulator.ViewModel
{
    class CreateTourneyViewModel : BaseViewModel
    {
        #region Variables

        private string _newTourney;
        private double _newTourneyBorder;
        private string _newTourneyWarning;

        #endregion


        #region Constructor

        public CreateTourneyViewModel(MainModel model, NavigationStore navigationStore)
        {
            Model = model;
            NavigationStore = navigationStore;
            NewTourneyWarning = string.Empty;
        }

        #endregion


        #region Properties

        public string NewTourney
        {
            get { return _newTourney; }
            set
            {
                _newTourney = value;
                if (_newTourney == string.Empty)
                {
                    NewTourneyBorder = 1;
                    NewTourneyWarning = "Nazwa turnieju nie może zostać pusta!";
                }
                else
                {
                    NewTourneyBorder = 0;
                    NewTourneyWarning = string.Empty;
                }
                OnPropertyChanged(NewTourney);
            }
        }

        public double NewTourneyBorder
        {
            get { return _newTourneyBorder; }
            set
            {
                _newTourneyBorder = value;
                OnPropertyChanged(nameof(NewTourneyBorder));
            }
        }

        public string NewTourneyWarning
        {
            get { return _newTourneyWarning; }
            set
            {
                _newTourneyWarning = value;
                OnPropertyChanged(nameof(NewTourneyWarning));
            }
        }

        #endregion


        #region Commands

        private ICommand _addTourney = null;

        public ICommand AddTourney
        {
            get
            {
                if (_addTourney == null)
                {
                    _addTourney = new RelayCommand(arg =>
                    {
                        var tourney = new Tournament(uint.Parse(Model.CurrentUser.Id_user.ToString()), NewTourney.ToString());

                        if(Model.AddUserTournament(tourney))
                        {
                            NewTourney = string.Empty;
                            NewTourneyBorder = 0;
                            NewTourneyWarning = string.Empty;
                            Model.CurrentTournament = tourney;
                            Model.CurrentTournamentGroups = new ObservableCollection<Single_group>();
                            foreach (var letter in Enum.GetValues(typeof(Single_group.Alphabet)))
                            {
                                var group = new Single_group(null, null, (uint)Model.CurrentTournament.Id_tournament, (Enum)letter);
                                Model.CurrentTournamentGroups.Add(group);
                                RepositoryGroups.AddTournamentGroups(group, (uint)Model.CurrentTournament.Id_tournament);
                                // TODO: tworzenie meczów w bazie
                            }
                            NavigationStore.CurrentViewModel = new GroupsViewModel(Model, NavigationStore);
                        }
                    },
                    arg => true);
                }
                return _addTourney;
            }
        }

        #endregion
    }
}
