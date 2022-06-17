using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    class KnockoutsViewModel : BaseViewModel
    {
        #region Variables

        private ObservableCollection<Single_match> _matches = new ObservableCollection<Single_match>();

        #endregion


        #region Constructor

        public KnockoutsViewModel(MainModel model, NavigationStore navigationStore)
        {
            Model = model;
            NavigationStore = navigationStore;
            Matches = new ObservableCollection<Single_match>() {
                new Single_match(1, 2, 1, "POL", "ARG", "Polska", "Argentyna", 1, 1, 2),
            };
        }

        #endregion


        #region Properties

        public ObservableCollection<Single_match> Matches
        {
            get { return _matches; }
            set { _matches = value;
                OnPropertyChanged(nameof(Matches));
            }
        }

        #endregion


        #region Methods

        public void PrepareMatches()
        {

        }

        #endregion


        #region Commands

        private ICommand _matchCommand = null;

        public ICommand MatchCommand
        {
            get
            {
                if (_matchCommand == null)
                {
                    _matchCommand = new RelayCommand(arg =>
                    {
                        NavigationStore.CurrentViewModel = new MatchViewModel(Model, NavigationStore);
                        //Console.WriteLine(Matches[0].Goals_first_team);
                        //Console.WriteLine(Matches[0].Goals_second_team);
                    },
                    arg => true);
                }
                return _matchCommand;
            }
        }

        #endregion
    }
}
