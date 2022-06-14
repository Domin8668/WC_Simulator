using WC_Simulator.ViewModel.BaseClasses;
using WC_Simulator.Model;
using System;
using WC_Simulator.DAL.Entities;
using WC_Simulator.Helpers.Stores;
using System.Windows.Input;
using System.Windows;
using WC_Simulator.Helpers.Hashing;

namespace WC_Simulator.ViewModel
{
    internal class ResetPasswordViewModel : BaseViewModel
    {
        #region Variables

        private User _currentUser;
        private MainModel _model;
        private NavigationStore _navigationStore;
        private string _password;
        private string _username;

        #endregion


        #region Constructor

        public ResetPasswordViewModel(MainModel model, NavigationStore navigationStore)
        {
            _model = model;
            _navigationStore = navigationStore;
            _currentUser = new User();
        }

        #endregion


        #region Properties

        public User CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                // test wpisywania hasła:
                Console.WriteLine($"Password: {Password}");
                OnPropertyChanged(nameof(Password));
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                // test wpisywania loginu:
                Console.WriteLine($"Nazwa: {Username}");
                OnPropertyChanged(nameof(Username));
            }
        }

        #endregion


        #region Commands

        private ICommand _resetPassword = null;

        public ICommand ResetPassword
        {
            get
            {
                if (_resetPassword == null)
                {
                    _resetPassword = new RelayCommand(arg =>
                    {
                        _navigationStore.CurrentViewModel = new LoginViewModel(Model, _navigationStore);
                    },
                    arg => true);
                }
                return _resetPassword;
            }
        }

        private ICommand _return = null;

        public ICommand Return
        {
            get
            {
                if (_return == null)
                {
                    _return = new RelayCommand(arg =>
                    {
                        _navigationStore.CurrentViewModel = new LoginViewModel(Model, _navigationStore);
                    },
                    arg => true);
                }
                return _return;
            }
        }


        // barebone ICommand to copy:
        //private ICommand _login = null;


        //public ICommand Login
        //{
        //    get
        //    {
        //        if (_login == null)
        //        {
        //            _login = new RelayCommand(arg => {

        //            },
        //            arg => true);
        //        }
        //        return _login;
        //    }
        //}

        #endregion
    }
}