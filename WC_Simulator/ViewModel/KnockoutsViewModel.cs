using System.Collections.ObjectModel;
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
            PrepareMatches16();
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
        #endregion


        #region Methods

        //zeby zrobic z matchcodes trzeba dodac kolejna tabele
        public void PrepareMatches16()
        {
            var groups = new string[8] { "A", "B", "C", "D", "E", "F", "G", "H" };

            Matches16 = new ObservableCollection<Single_match>();

            for (int i = 0; i < groups.Length - 1; i++)
            {
                Team Ph1 = new Team(0, "1" + groups[i], "1" + groups[i], "1" + groups[i], 1, 1);
                Team Ph2 = new Team(0, "2" + groups[i + 1], "2" + groups[i + 1], "2" + groups[i + 1], 1, 1);
                Matches16.Add(new Single_match(1, Ph1, Ph2, 100, 1, 1));
            }

            for (int i = 0; i < groups.Length - 1; i++)
            {
                Team Ph1 = new Team(0, "1" + groups[i + 1], "1" + groups[i + 1], "1" + groups[i + 1], 1, 1);
                Team Ph2 = new Team(0, "2" + groups[i], "2" + groups[i], "2" + groups[i], 1, 1);
                Matches16.Add(new Single_match(1, Ph1, Ph2, 100, 1, 1));
            }


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
