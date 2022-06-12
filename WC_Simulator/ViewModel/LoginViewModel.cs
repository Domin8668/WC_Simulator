using WC_Simulator.DAL.Entities;
using WC_Simulator.ViewModel.BaseClasses;
using WC_Simulator.Model;
using System;
using WC_Simulator.Helpers.Hashing;
using System.Windows.Input;
using WC_Simulator.Helpers.Stores;
using System.Windows;

namespace WC_Simulator.ViewModel
{
    internal class LoginViewModel : BaseViewModel
    {
        #region Variables

        private User _currentUser;
        private MainModel _model;
        private NavigationStore _navigationStore;
        private string _password;
        private string _username;

        #endregion


        #region Constructor

        public LoginViewModel(MainModel model, NavigationStore navigationStore)
        {
            Model = model;
            _navigationStore = navigationStore;
            _currentUser = new User();
            _test = "5";
        }

        #endregion


        #region Properties
        // do testow GroupUserControlki
        public string Test
        {
            get { return _test; }
            set { _test = value;
                OnPropertyChanged(nameof(Test));
            }
        }
        private string _test;



        public User CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        public MainModel Model
        {
            get { return _model; }
            set { _model = value; }
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

        private ICommand _login = null;

        public ICommand Login
        {
            get
            {
                if (_login == null)
                {
                    _login = new RelayCommand(arg => {
                        try
                        {
                            SHA256Hashing SHA256 = new SHA256Hashing();
                            CurrentUser.Login = Username;
                            CurrentUser.Password = SHA256.GetHash(Username, Password);
                            Username = string.Empty;
                            Password = string.Empty;
                            //Model.ValidateUser(CurrentUser);
                            //MessageBox.Show($"Username: {Username}\nPassword: {new NetworkCredential(string.Empty, Password).Password}");
                            _navigationStore.MenuVisibility = Visibility.Visible;
                            _navigationStore.CurrentViewModel = new ProfileViewModel(Model, _navigationStore);
                        }
                        catch(Exception)
                        { 
                            
                        }
                    },
                    arg => true);
                }
                return _login;
            }
        }

        private ICommand _resetPassword = null;

        public ICommand ResetPassword
        {
            get
            {
                if (_resetPassword == null)
                {
                    _resetPassword = new RelayCommand(arg =>
                    {
                        _navigationStore.CurrentViewModel = new ResetPasswordViewModel(Model, _navigationStore);
                    },
                    arg => true);
                }
                return _resetPassword;
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
