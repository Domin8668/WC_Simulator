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
                        _navigationStore.CurrentViewModel = new ProfileViewModel(_model, _navigationStore); ;
                        _navigationStore.MenuVisibility = Visibility.Hidden;
                    },
                    arg => true);
                }
                return _profile;
            }
        }

        #endregion
    }
}
