using System;
using WC_Simulator.DAL.Entities;
using WC_Simulator.Helpers.Stores;
using WC_Simulator.Model;
using WC_Simulator.ViewModel.BaseClasses;

namespace WC_Simulator.ViewModel
{
    internal class ProfileViewModel : BaseViewModel
    {
        #region Variables

        private MainModel mainModel;
        private NavigationStore _navigationStore;
        private User _user_account;
        private TimeSpan _timeInService;

        #endregion
        

        #region Constructor

        public ProfileViewModel(MainModel model, NavigationStore navigationStore)
        {
            Model = model;
            NavigationStore = navigationStore;
            _login = "Test";

        }

        public ProfileViewModel(User user_account)
        {
            _user_account = user_account;
            _timeInService = DateTime.Now - user_account.Creation_date;

        }

        #endregion


        #region Properties
        private string _login;

        public string Login
        {
            get { return _login; }
            set { _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public MainModel Model
        {
            get { return mainModel; }
            set { mainModel = value; }
        }

        public User User_account
        {
            get { return _user_account; }
            set { _user_account = value; }
        }
        public TimeSpan TimeInService
        {
            get { return _timeInService; }
            set { _timeInService = value; }
        }

        public NavigationStore NavigationStore
        {
            get { return _navigationStore; }
            set { _navigationStore = value; }
        }

        #endregion
    }
}
