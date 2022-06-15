using System;
using System.Windows.Input;
using WC_Simulator.Helpers.Stores;
using WC_Simulator.Model;
using WC_Simulator.ViewModel.BaseClasses;

namespace WC_Simulator.ViewModel
{
    internal class ProfileViewModel : BaseViewModel
    {
        #region Variables

        private string _accountAge;

        #endregion


        #region Constructor

        public ProfileViewModel(MainModel model, NavigationStore navigationStore)
        {
            Model = model;
            NavigationStore = navigationStore;
            _accountAge = CalculateTimeInService(Model.CurrentUser.Creation_date);
        }

        #endregion


        #region Properties

        public string Username
        {
            get { return Model.CurrentUser.Login; }
            set
            {
                Model.CurrentUser.Login = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public int TournamentCount
        {
            get { return Model.AllTournaments.Count; }
            set
            {
                OnPropertyChanged(nameof(TournamentCount));
            }
        }

        public string CreationDate
        {
            get { return Model.CurrentUser.Creation_date.ToString(); }
            set
            {
                OnPropertyChanged(nameof(CreationDate));
            }
        }

        public string LastLoginDate
        {
            get { return Model.CurrentUser.Last_log_date.ToString(); }
            set
            {
                OnPropertyChanged(nameof(LastLoginDate));
            }
        }

        public string AccountAge
        {
            get { return _accountAge; }
            set
            {
                _accountAge = value;
                OnPropertyChanged(nameof(AccountAge));
            }
        }

        #endregion


        #region Methods

        private string CalculateTimeInService(DateTime creationDate)
        {
            string ending;
            string timeSpan = "";
            var v = DateTime.Now - creationDate;
            int timeSpanInt = Convert.ToInt32(v.TotalMinutes);

            if (timeSpanInt < 1)
            {
                ending = "Przed chwilą";
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
                        NavigationStore.CurrentViewModel = new ChangePasswordViewModel(Model, NavigationStore);
                    },
                    arg => true);
                }
                return _changePassword;
            }
        }

        #endregion
    }
}
