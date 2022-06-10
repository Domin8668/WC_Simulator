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
        //public ObservableCollection<string> col = new ObservableCollection<string> { "twoja stara", "twoj stary" };
        //TeamVM = new TeamViewModel("Poland", "Michniewicz", col);

        #region Constructor

        public MainViewModel()
        {
            Model = new MainModel();
            LoginViewModel login = new LoginViewModel
            {
                Model = Model
            };
            RegisterViewModel register = new RegisterViewModel
            {
                Model = Model
            };
            ResetPasswordViewModel resetPassword = new ResetPasswordViewModel
            {
                Model = Model
            };
            byte[] password = new byte[32] {36,19,251,55,9,176,89,57,240,76,242,233,47,125,8,151,252,37,150,249,173,11,138,158,168,85,199,191,235,170,232,146};
            User_current = new User(1, "Robert Lewandowski", password , new DateTime(2020, 5, 20), new DateTime(2021, 6, 15), "Kto wygrał złotą piłke 2021?", "Messi");
            ProfileVM = new ProfileViewModel(User_current);
            CurrentViewModel = login;
            MenuVisibility = Visibility.Visible;
            MenuVisibility = Visibility.Hidden;
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
