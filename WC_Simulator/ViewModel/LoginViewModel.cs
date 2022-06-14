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
 
        private string _username;
        private string _password;

        #endregion


        #region Constructor

        public LoginViewModel(MainModel model, NavigationStore navigationStore)
        {
            Model = model;
            NavigationStore = navigationStore;
        }

        #endregion


        #region Properties

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
                            Model.CurrentUser.Login = Username;
                            Model.CurrentUser.Password = SHA256.GetHash(Username, Password);
                            Username = string.Empty;
                            Password = string.Empty;
                            //Model.ValidateUser(CurrentUser);
                            //MessageBox.Show($"Username: {Username}\nPassword: {new NetworkCredential(string.Empty, Password).Password}");
                            NavigationStore.MenuVisibility = Visibility.Visible;
                            NavigationStore.CurrentViewModel = new ProfileViewModel(Model, NavigationStore);
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
                        NavigationStore.CurrentViewModel = new ResetPasswordViewModel(Model, NavigationStore);
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
                        NavigationStore.CurrentViewModel = new RegisterViewModel(Model, NavigationStore);
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
