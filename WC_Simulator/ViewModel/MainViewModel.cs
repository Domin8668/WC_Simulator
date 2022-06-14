using WC_Simulator.ViewModel.BaseClasses;
using WC_Simulator.Model;
using System.Windows;
using WC_Simulator.DAL.Entities;
using System;
using WC_Simulator.Helpers.Stores;
using System.Windows.Input;

namespace WC_Simulator.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {
        #region Variables

        //private MainModel Model;
        //private NavigationStore NavigationStore;

        #endregion


        #region Constructor

        public MainViewModel()
        {
            Model = new MainModel();
            NavigationStore = new NavigationStore();

            NavigationStore.CurrentViewModel = new LoginViewModel(Model, NavigationStore); ;
            NavigationStore.MenuVisibility = Visibility.Hidden;

            NavigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            NavigationStore.MenuVisibilityChanged += OnMenuVisibilityChanged;
        }

        #endregion


        #region Subscribers

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private void OnMenuVisibilityChanged()
        {
            OnPropertyChanged(nameof(MenuVisibility));
        }

        #endregion


        #region Properties

        public BaseViewModel CurrentViewModel
        {
            get { return NavigationStore.CurrentViewModel; }
            set { NavigationStore.CurrentViewModel = value; }
        }

        public Visibility MenuVisibility
        {
            get { return NavigationStore.MenuVisibility; }
            set { NavigationStore.MenuVisibility = value; }
        }

        #endregion


        #region Commands

        private ICommand _profile = null;

        public ICommand Profile
        {
            get
            {
                if (_profile == null)
                {
                    _profile = new RelayCommand(arg =>
                    {
                        NavigationStore.CurrentViewModel = new ProfileViewModel(Model, NavigationStore);
                    },
                    arg => true);
                }
                return _profile;
            }
        }

        private ICommand _teams = null;

        public ICommand Teams
        {
            get
            {
                if (_teams == null)
                {
                    _teams = new RelayCommand(arg =>
                    {
                        NavigationStore.CurrentViewModel = new TeamsViewModel(Model, NavigationStore);
                    },
                    arg => true);
                }
                return _teams;
            }
        }

        private ICommand _groups = null;

        public ICommand Groups
        {
            get
            {
                if (_groups == null)
                {
                    _groups = new RelayCommand(arg =>
                    {
                        NavigationStore.CurrentViewModel = new GroupsViewModel(Model, NavigationStore);
                    },
                    arg => true);
                }
                return _groups;
            }
        }

        private ICommand _knockouts = null;

        public ICommand Knockouts
        {
            get
            {
                if (_knockouts == null)
                {
                    _knockouts = new RelayCommand(arg =>
                    {
                        NavigationStore.CurrentViewModel = new KnockoutsViewModel(Model, NavigationStore);
                    },
                    arg => true);
                }
                return _knockouts;
            }
        }

        private ICommand _help = null;

        public ICommand Help
        {
            get
            {
                if (_help == null)
                {
                    _help = new RelayCommand(arg =>
                    {
                        NavigationStore.CurrentViewModel = new HelpViewModel(Model, NavigationStore);
                    },
                    arg => true);
                }
                return _help;
            }
        }

        private ICommand _newTournament = null;

        public ICommand NewTournament
        {
            get
            {
                if (_newTournament == null)
                {
                    _newTournament = new RelayCommand(arg =>
                    {
                        NavigationStore.CurrentViewModel = new CreateTourneyViewModel(Model, NavigationStore);
                    },
                    arg => true);
                }
                return _newTournament;
            }
        }

        #endregion
    }
}
