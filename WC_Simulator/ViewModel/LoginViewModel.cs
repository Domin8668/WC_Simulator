using WC_Simulator.DAL.Entities;
using WC_Simulator.ViewModel.BaseClasses;
using WC_Simulator.Model;
using System.Security;
using System;
using System.Runtime.InteropServices;

namespace WC_Simulator.ViewModel
{
    internal class LoginViewModel : BaseViewModel
    {
        #region Variables

        private User _currentUser;
        private MainModel _model;
        private SecureString _password;
        private string _login;

        #endregion


        #region Constructor

        public LoginViewModel()
        {

        }

        public LoginViewModel(MainModel Model)
        {
            _currentUser = new User();
            this.Model = Model;
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

        public SecureString Password
        {
            get { return _password; }
            set { _password = value;
                // test wpisywania hasła:
                string password = new System.Net.NetworkCredential(string.Empty, Password).Password;
                Console.WriteLine($"Password: {password}");
                OnPropertyChanged(nameof(Password));
            }
        }

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                // test wpisywania loginu:
                Console.WriteLine($"Login: {Login}");
                OnPropertyChanged(nameof(Login));
            }
        }

        #endregion

        #region Dependencies
        #endregion
    }
}
