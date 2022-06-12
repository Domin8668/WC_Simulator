using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC_Simulator.DAL.Entities;
using WC_Simulator.ViewModel.BaseClasses;
using WC_Simulator.Model;
using WC_Simulator.Helpers.Stores;

namespace WC_Simulator.ViewModel
{
    class GroupsViewModel : BaseViewModel
    {

        #region Variables

        //private User _currentUser;
        private MainModel _model;
        private NavigationStore _navigationStore;
        //private string _password;
        //private string _username;

        private string _team2img;
        private string _team2fn; //full name
        private string _team2rm;
        private string _team2bz;
        private string _team2bs;
        private string _team2pkt;
        #endregion


        #region Constructor

        public GroupsViewModel(MainModel model, NavigationStore navigationStore)
        {
            Model = model;
            _navigationStore = navigationStore;
            //_team2img = $"../../Resources/Flags/korea.png";
            //_team2fn = "Korea";
            //_team2rm = "7";
            //_team2bz = "6";
            //_team2bs = "5";
            //_team2pkt = "4";
        }

        public GroupsViewModel()
        {
            _team2img = $"../../Resources/Flags/korea.png";
            _team2fn = "Korea";
            _team2rm = "7";
            _team2bz = "6";
            _team2bs = "5";
            _team2pkt = "4";
        }
        #endregion


        #region Properties

        //public MainModel Model
        //{
        //    get { return _model; }
        //    set { _model = value; }
        //}
        public string Team2img
        {
            get { return _team2img; }
            set { _team2img = value; }
        }

        public string Team2fn
        {
            get { return _team2fn; }
            set
            {
                _team2fn = value;
                OnPropertyChanged(nameof(Team2fn));
            }
        }

        public string Team2rm
        {
            get { return _team2rm; }
            set { _team2rm = value; }
        }

        public string Team2bz
        {
            get { return _team2bz; }
            set { _team2bz = value; }
        }
        public string Team2bs
        {
            get { return _team2bs; }
            set { _team2bs = value; }
        }

        public string Team2pkt
        {
            get { return _team2pkt; }
            set { _team2pkt = value; }
        }



        //public User CurrentUser
        //{
        //    get { return _currentUser; }
        //    set { _currentUser = value; }
        //}

        //public string Password
        //{
        //    get { return _password; }
        //    set
        //    {
        //        _password = value;
        //        // test wpisywania hasła:
        //        Console.WriteLine($"Password: {Password}");
        //        OnPropertyChanged(nameof(Password));
        //    }
        //}

        //public string Username
        //{
        //    get { return _username; }
        //    set
        //    {
        //        _username = value;
        //        // test wpisywania loginu:
        //        Console.WriteLine($"Nazwa: {Username}");
        //        OnPropertyChanged(nameof(Username));
        //    }
        //}

        #endregion


        #region Commands

        //private ICommand _login = null;

        //public ICommand Login
        //{
        //    get
        //    {
        //        if (_login == null)
        //        {
        //            _login = new RelayCommand(arg => {
        //                try
        //                {
        //                    SHA256Hashing SHA256 = new SHA256Hashing();
        //                    CurrentUser.Login = Username;
        //                    CurrentUser.Password = SHA256.GetHash(Username, Password);
        //                    Username = string.Empty;
        //                    Password = string.Empty;
        //                    //Model.ValidateUser(CurrentUser);
        //                    //MessageBox.Show($"Username: {Username}\nPassword: {new NetworkCredential(string.Empty, Password).Password}");
        //                    _navigationStore.MenuVisibility = Visibility.Visible;
        //                    _navigationStore.CurrentViewModel = new ProfileViewModel(Model, _navigationStore);
        //                }
        //                catch (Exception)
        //                {

        //                }
        //            },
        //            arg => true);
        //        }
        //        return _login;
        //    }
        //}

        //private ICommand _resetPassword = null;

        //public ICommand ResetPassword
        //{
        //    get
        //    {
        //        if (_resetPassword == null)
        //        {
        //            _resetPassword = new RelayCommand(arg =>
        //            {
        //                _navigationStore.CurrentViewModel = new ResetPasswordViewModel(Model, _navigationStore);
        //            },
        //            arg => true);
        //        }
        //        return _resetPassword;
        //    }
        //}

        //private ICommand _register = null;

        //public ICommand Register
        //{
        //    get
        //    {
        //        if (_register == null)
        //        {
        //            _register = new RelayCommand(arg =>
        //            {
        //                _navigationStore.CurrentViewModel = new RegisterViewModel(Model, _navigationStore);
        //            },
        //            arg => true);
        //        }
        //        return _register;
        //    }
        //}


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
