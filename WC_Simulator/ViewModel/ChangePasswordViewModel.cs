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
    internal class ChangePasswordViewModel : BaseViewModel
    {
        #region Variables

        private MainModel _model;
        private NavigationStore _navigationStore;
        private string _username;
        private string _oldPassword;
        private string _newPassword;
        private string _repeatNewPassword;

        #endregion


        #region Constructor

        public ChangePasswordViewModel(MainModel model, NavigationStore navigationStore)
        {
            _model = model;
            _navigationStore = navigationStore;
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

        public string OldPassword
        {
            get { return _oldPassword; }
            set
            {
                _oldPassword = value;
                // test wpisywania hasła:
                Console.WriteLine($"OldPassword: {OldPassword}");
                OnPropertyChanged(nameof(OldPassword));
            }
        }
        
        public string NewPassword
        {
            get { return _newPassword; }
            set
            {
                _newPassword = value;
                // test wpisywania hasła:
                Console.WriteLine($"NewPassword: {NewPassword}");
                OnPropertyChanged(nameof(NewPassword));
            }
        }
        
        public string RepeatNewPassword
        {
            get { return _repeatNewPassword; }
            set
            {
                _repeatNewPassword = value;
                // test wpisywania hasła:
                Console.WriteLine($"RepeatPassword: {RepeatNewPassword}");
                OnPropertyChanged(nameof(RepeatNewPassword));
            }
        }

        #endregion


        #region Commands

        private ICommand _changePassword = null;

        public ICommand ChangePassword
        {
            get
            {
                if (_changePassword == null)
                {
                    _changePassword = new RelayCommand(arg =>
                    {
                        ProfileViewModel profile = new ProfileViewModel(_model, _navigationStore);
                        _navigationStore.CurrentViewModel = new MessageViewModel(_model, _navigationStore, profile, Visibility.Visible);
                    },
                    arg => true);
                }
                return _changePassword;
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
                        _navigationStore.CurrentViewModel = new ProfileViewModel(Model, _navigationStore);
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
