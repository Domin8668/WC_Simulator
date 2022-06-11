using WC_Simulator.ViewModel.BaseClasses;
using WC_Simulator.Model;
using System.Windows;
using WC_Simulator.DAL.Entities;
using System;
using WC_Simulator.Helpers.Stores;

namespace WC_Simulator.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {
        #region Variables

        private MainModel _model;
        private NavigationStore _navigationStore;
        private TeamViewModel _teamVM;
        private ProfileViewModel _profileVM;
        private User _currentUser;

        #endregion

        #region Constructor

        public MainViewModel()
        {
            _model = new MainModel();
            _navigationStore = new NavigationStore();

            LoginViewModel login = new LoginViewModel(_model, _navigationStore);
            RegisterViewModel register = new RegisterViewModel(_model);
            ResetPasswordViewModel resetPassword = new ResetPasswordViewModel(_model);
            ProfileViewModel profile = new ProfileViewModel(_model);
            TeamViewModel team = new TeamViewModel(_model);

            _navigationStore.CurrentViewModel = login;
            _navigationStore.MenuVisibility = Visibility.Hidden;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _navigationStore.MenuVisibilityChanged += OnMenuVisibilityChanged;
        }

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

        public MainModel Model
        {
            get { return _model; }
            set { _model = value; }
        }

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

        public TeamViewModel TeamVM
        {
            get { return _teamVM; }
            set { _teamVM = value; }
        }
        public ProfileViewModel ProfileVM
        {
            get { return _profileVM; }
            set { _profileVM = value; }
        }

        public User CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        #endregion


        #region Commands

        #endregion
    }
}
