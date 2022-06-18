using WC_Simulator.DAL.Entities;
using WC_Simulator.ViewModel.BaseClasses;
using WC_Simulator.Model;
using System;
using WC_Simulator.Helpers.Hashing;
using System.Windows.Input;
using WC_Simulator.Helpers.Stores;
using System.Windows;
using System.Windows.Media;
using WC_Simulator.DAL.Repositories;

namespace WC_Simulator.ViewModel
{
    internal class LoginViewModel : BaseViewModel
    {
        #region Variables
 
        private string _username;
        private string _password;
        private double _usernameBorder;
        private double _passwordBorder;
        private string _usernameWarning;
        private string _passwordWarning;

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
                if (_username == string.Empty)
                {
                    UsernameBorder = 0.7;
                    UsernameWarning = "Login nie może być pusty";
                }
                else
                {
                    UsernameBorder = 0;
                    UsernameWarning = string.Empty;
                }
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                if (_password == string.Empty)
                {
                    PasswordBorder = 0.7;
                    PasswordWarning = "Hasło nie może być puste";
                } 
                else
                {
                    PasswordBorder = 0;
                    PasswordWarning = string.Empty;
                }
                OnPropertyChanged(nameof(Password));
            }
        }

        public double UsernameBorder
        {
            get { return _usernameBorder; }
            set
            {
                _usernameBorder = value;
                OnPropertyChanged(nameof(UsernameBorder));
            }
        }

        public double PasswordBorder
        {
            get { return _passwordBorder; }
            set
            {
                _passwordBorder = value;
                OnPropertyChanged(nameof(PasswordBorder));
            }
        }

        public string UsernameWarning
        {
            get { return _usernameWarning; }
            set
            {
                _usernameWarning = value;
                OnPropertyChanged(nameof(UsernameWarning));
            }
        }

        public string PasswordWarning
        {
            get { return _passwordWarning; }
            set
            {
                _passwordWarning = value;
                OnPropertyChanged(nameof(PasswordWarning));
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
                        SHA256Hashing myHash = new SHA256Hashing();
                        Model.CurrentUserShort.Login = Username;
                        Model.CurrentUserShort.Password = myHash.GetHash(Username, Password);
                        myHash = null;

                        if (Username == null)
                        {
                            Username = string.Empty;
                            if (Password == null)
                            {
                                Password = string.Empty;
                            }
                            return;
                        }
                        if (Password == null)
                        {
                            Password = string.Empty;
                            if (Login == null)
                            {
                                Username = string.Empty;
                            }
                            return;
                        }
                        if (Model.CurrentUserShort.Login.Length < 5)
                        {
                            Username = null;
                            Password = null;
                            UsernameBorder = 0.7;
                            UsernameWarning = "Login musi mieć min. 5 znaków";
                            Model.CurrentUserShort.Login = string.Empty;
                            Model.CurrentUserShort.Password = new byte[32];
                            return;
                        }
                        if (Model.CurrentUserShort.Login.Contains("`"))
                        {
                            Username = null;
                            Password = null;
                            UsernameBorder = 0.7;
                            UsernameWarning = "Login nie może zawierać '`'";
                            Model.CurrentUserShort.Login = string.Empty;
                            Model.CurrentUserShort.Password = new byte[32];
                            return;
                        }
                        if (Password.Length < 8)
                        {
                            Username = null;
                            Password = null;
                            PasswordBorder = 0.7;
                            PasswordWarning = "Hasło musi mieć min. 8 znaków";
                            Model.CurrentUserShort.Login = string.Empty;
                            Model.CurrentUserShort.Password = new byte[32];
                            return;
                        }
                        if (!Model.CheckLogin())
                        {
                            Username = null;
                            Password = null;
                            UsernameBorder = 0.7;
                            UsernameWarning = "Nieprawidłowy login";
                            Model.CurrentUserShort.Login = string.Empty;
                            Model.CurrentUserShort.Password = new byte[32];
                            return;
                        }
                        if (!Model.ValidateUserShort())
                        {
                            Password = null;
                            PasswordBorder = 0.7;
                            PasswordWarning = "Nieprawidłowe hasło";
                            Model.CurrentUserShort.Login = string.Empty;
                            Model.CurrentUserShort.Password = new byte[32];
                            return;
                        }

                        Model.UpdateCurrentUser();
                        Model.LoadUserTournaments();
                        if (Model.AllTournaments.Count > 0)
                        {
                            Model.CurrentTournament = Model.AllTournaments[0];
                        }
                        NavigationStore.MenuVisibility = Visibility.Visible;
                            NavigationStore.CurrentViewModel = new ProfileViewModel(Model, NavigationStore);
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
