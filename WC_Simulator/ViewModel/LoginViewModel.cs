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
                string password = new System.Net.NetworkCredential(string.Empty, Password).Password;
                Console.WriteLine($"SecurePassword:{password}");
            }
        }

        #endregion

        #region Dependencies
        #endregion
    }
}
