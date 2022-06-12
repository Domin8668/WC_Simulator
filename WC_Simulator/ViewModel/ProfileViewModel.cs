using System;
using System.Windows.Input;
using WC_Simulator.DAL.Entities;
using WC_Simulator.Helpers.Stores;
using WC_Simulator.Model;
using WC_Simulator.ViewModel.BaseClasses;

namespace WC_Simulator.ViewModel
{
    internal class ProfileViewModel : BaseViewModel
    {
        #region Variables

        private MainModel _model;
        private NavigationStore _navigationStore;
        private User _user_account;
        private string _login;
        private int _tourneyCount;
        private string _timeInService;
        private string _firstDate;
        private string _lastDate;

        #endregion


        #region Constructor

        public ProfileViewModel(MainModel model, NavigationStore navigationStore)
        {
            _model = model;
            _navigationStore = navigationStore;
            Login = "Jason Bourne";
            TourneyCount = 3;

            FirstDate = new DateTime(2022, 6, 11, 17, 0, 0).ToString("dd MMMM yyyy HH:mm");
            LastDate = new DateTime(2022, 6, 11, 17, 30, 0).ToString("dd MMMM yyyy HH:mm");
            TimeInService = CalculateTimeInService(new DateTime(2022, 4, 10, 17, 2, 0)); //przekazujemy creation date
        }

        public ProfileViewModel(User user_account)
        {
            _user_account = user_account;
        }

        #endregion


        #region Properties
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public int TourneyCount
        {
            get { return _tourneyCount; }
            set
            {
                _tourneyCount = value;
                OnPropertyChanged(nameof(_tourneyCount));
            }
        }
        public string FirstDate
        {
            get { return _firstDate; }
            set
            {
                _firstDate = value;
                OnPropertyChanged(nameof(_firstDate));
            }
        }
        public string LastDate
        {
            get { return _lastDate; }
            set
            {
                _lastDate = value;
                OnPropertyChanged(nameof(_lastDate));
            }
        }
        public string TimeInService
        {
            get { return _timeInService; }
            set { _timeInService = value; }
        }


        //public MainModel Model
        //{
        //    get { return mainModel; }
        //    set { mainModel = value; }
        //}

        public User User_account
        {
            get { return _user_account; }
            set { _user_account = value; }
        }

        //public NavigationStore NavigationStore
        //{
        //    get { return _navigationStore; }
        //    set { _navigationStore = value; }
        //}

        #endregion


        #region Methods

        private string CalculateTimeInService(DateTime creationDate)
        {
            string ending = "";
            string timeSpan = "brak";
            int timeSpanInt;
            var v = DateTime.Now - creationDate;
            timeSpanInt = Convert.ToInt32(v.TotalMinutes);

            if (timeSpanInt < 1)
            {

            }
            else if (timeSpanInt >= 1 && timeSpanInt < 60)
            {
                timeSpan = Convert.ToInt32(v.TotalMinutes).ToString();
                ending = "min";
            }
            else if (timeSpanInt >= 60 && timeSpanInt < 1440)
            {
                timeSpan = Convert.ToInt32(v.TotalHours).ToString();
                ending = "h";
            }
            else
            {
                timeSpan = Convert.ToInt32(v.TotalDays).ToString();
                ending = "d";
            }
            return $"{timeSpan} {ending}";

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
                        _navigationStore.CurrentViewModel = new ChangePasswordViewModel(_model, _navigationStore);
                    },
                    arg => true);
                }
                return _changePassword;
            }
        }

        #endregion
    }
}
