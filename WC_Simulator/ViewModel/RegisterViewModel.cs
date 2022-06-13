using WC_Simulator.ViewModel.BaseClasses;
using WC_Simulator.Model;
using System;
using WC_Simulator.DAL.Entities;
using WC_Simulator.Helpers.Stores;
using System.Windows.Input;
using System.Windows;
using WC_Simulator.Helpers.Hashing;
using System.Collections.ObjectModel;

namespace WC_Simulator.ViewModel
{
    internal class RegisterViewModel : BaseViewModel
    {
        #region Variables

        private User _currentUser;
        private MainModel _model;
        private NavigationStore _navigationStore;
        private string _username;
        private string _password;
        private string _repeatPassword;
        private ObservableCollection<string> _securityQuestions;
        private string _selectedSecurityQuestion;
        private string _securityAnswer;

        #endregion


        #region Constructor

        public RegisterViewModel(MainModel model, NavigationStore navigationStore)
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

        public string RepeatPassword
        {
            get { return _repeatPassword; }
            set
            {
                _repeatPassword = value;
                // test wpisywania hasła:
                Console.WriteLine($"Password: {RepeatPassword}");
                OnPropertyChanged(nameof(RepeatPassword));
            }
        }

        public ObservableCollection<string> SecurityQuestions
        {
            get { return _securityQuestions; }
            set { _securityQuestions = value; }
        }

        public string SelectedSecurityQuestion
        {
            get { return _selectedSecurityQuestion; }
            set { _selectedSecurityQuestion = value; }
        }

        public string SecurityAnswer
        {
            get { return _securityAnswer; }
            set { _securityAnswer = value; }
        }

        #endregion


        #region Commands

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

        private ICommand _register = null;

        public ICommand Register
        {
            get
            {
                if (_register == null)
                {
                    _register = new RelayCommand(arg =>
                    {
                        _navigationStore.CurrentViewModel = new RegisterViewModel(Model, _navigationStore);
                    },
                    arg => true);
                }
                return _register;
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