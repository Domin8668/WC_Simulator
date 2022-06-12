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

        private MainModel _model;
        private NavigationStore _navigationStore;
        private User _currentUser;

        #endregion

        #region Constructor

        public MainViewModel()
        {
            _model = new MainModel();
            _navigationStore = new NavigationStore();

            //LoginViewModel login = new LoginViewModel(_model, _navigationStore);
            //RegisterViewModel register = new RegisterViewModel(_model, _navigationStore);
            //ResetPasswordViewModel resetPassword = new ResetPasswordViewModel(_model, _navigationStore);
            //ProfileViewModel profile = new ProfileViewModel(_model, _navigationStore);
            //TeamViewModel team = new TeamViewModel(_model);
            //GroupsViewModel groups = new GroupsViewModel(_model, _navigationStore);
            //CurrentViewModel = groups;

            _navigationStore.CurrentViewModel = new LoginViewModel(_model, _navigationStore); ;
            _navigationStore.MenuVisibility = Visibility.Hidden;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _navigationStore.MenuVisibilityChanged += OnMenuVisibilityChanged;
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

        //public MainModel Model
        //{
        //    get { return _model; }
        //    set { _model = value; }
        //}

        public BaseViewModel CurrentViewModel
        {
            get { return _navigationStore.CurrentViewModel; }
            set { _navigationStore.CurrentViewModel = value; }
        }

        public Visibility MenuVisibility
        {
            get { return _navigationStore.MenuVisibility; }
            set { _navigationStore.MenuVisibility = value; }
        }

        public User CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
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
                        _navigationStore.CurrentViewModel = new ProfileViewModel(_model, _navigationStore);
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
                        //_navigationStore.CurrentViewModel = new TeamsViewModel(_model, _navigationStore);
                    },
                    arg => true);
                }
                return _teams;
            }
        }

        private ICommand _schedule = null;

        public ICommand Schedule
        {
            get
            {
                if (_schedule == null)
                {
                    _schedule = new RelayCommand(arg =>
                    {
                        //_navigationStore.CurrentViewModel = new ScheduleViewModel(_model, _navigationStore);
                    },
                    arg => true);
                }
                return _schedule;
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
                        //_navigationStore.CurrentViewModel = new GroupsViewModel(_model, _navigationStore);
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
                        //_navigationStore.CurrentViewModel = new KnockoutsViewModel(_model, _navigationStore);
                    },
                    arg => true);
                }
                return _knockouts;
            }
        }

        private ICommand _table = null;

        public ICommand Table
        {
            get
            {
                if (_table == null)
                {
                    _table = new RelayCommand(arg =>
                    {
                        //_navigationStore.CurrentViewModel = new TableViewModel(_model, _navigationStore);
                    },
                    arg => true);
                }
                return _table;
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
                        //_navigationStore.CurrentViewModel = new HelpViewModel(_model, _navigationStore);
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
                        //_navigationStore.CurrentViewModel = new NewTournamentViewModel(_model, _navigationStore);
                    },
                    arg => true);
                }
                return _newTournament;
            }
        }

        #endregion
    }
}
