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

        private ObservableCollection<Single_match> _matches16;
        private ObservableCollection<Single_match> _matchesQ;
        private ObservableCollection<Single_match> _matchesS;
        private ObservableCollection<Single_match> _matchesF;


        #endregion


        #region Constructor

        public KnockoutsViewModel(MainModel model, NavigationStore navigationStore)
        {
            Model = model;
            NavigationStore = navigationStore;
            Team Ph1 = new Team(0, "1A", "1A", "1A", 1, 1);
            Team Ph2 = new Team(0, "2B", "2B", "2B", 1, 1);

            Matches16 = new ObservableCollection<Single_match>() {
                new Single_match(1, Ph1, Ph2, 100, 1, 1),
            };
        }

        #endregion


        #region Properties

        public ObservableCollection<Single_match> Matches16
        {
            get { return _matches16; }
            set { _matches16 = value;
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
                    },
                    arg => true);
                }
                return _matchCommand;
            }
        }

        #endregion
    }
}
