using WC_Simulator.DAL.Entities;
using WC_Simulator.ViewModel.BaseClasses;
using WC_Simulator.Model;
using System.Security;
using System;
using WC_Simulator.Helpers.Hashing;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Net;

namespace WC_Simulator.ViewModel
{
    internal class LoginViewModel : BaseViewModel
    {
        #region Variables

        private User _currentUser;
        private MainModel _model;
        private string _securePassword;
        private string _username;

        #endregion


        #region Constructor

        public LoginViewModel()
        {
            _currentUser = new User();
        }

        #endregion


        #region Properties

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
            get { return _securePassword; }
            set
            {
                _securePassword = value;
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
                            //MessageBox.Show($"Username: {Username}\nPassword: {new NetworkCredential(string.Empty, Password).Password}");
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
