using WC_Simulator.ViewModel.BaseClasses;
using WC_Simulator.Model;
using System.Windows;
using WC_Simulator.DAL.Entities;
using System;

namespace WC_Simulator.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {
        #region Variables

        private MainModel _model;
        private BaseViewModel _currentViewModel;
        private Visibility _menuVisibility;
        private TeamViewModel _teamVM;
        private ProfileViewModel _profileVM;
        private User _user_current;

        #endregion

        #region Constructor

        public MainViewModel()
        {
            Model = new MainModel();
            LoginViewModel login = new LoginViewModel(Model);
            RegisterViewModel register = new RegisterViewModel(Model);
            ResetPasswordViewModel resetPassword = new ResetPasswordViewModel(Model);
            ProfileViewModel profile = new ProfileViewModel(Model);
            TeamViewModel team = new TeamViewModel(Model);

            CurrentViewModel = profile;
            MenuVisibility = Visibility.Visible;
            //MenuVisibility = Visibility.Hidden;
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
            get { return _currentViewModel; }
            set { _currentViewModel = value; }
        }

        public Visibility MenuVisibility
        {
            get { return _menuVisibility; }
            set { _menuVisibility = value; }
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

        public User User_current
        {
            get { return _user_current; }
            set { _user_current = value; }
        }

        #endregion


        #region Commands

        #endregion
    }
}
