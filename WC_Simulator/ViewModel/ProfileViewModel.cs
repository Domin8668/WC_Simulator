using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC_Simulator.DAL.Entities;

namespace WC_Simulator.ViewModel
{
    internal class ProfileViewModel
    {
        #region Variables

        private User _user_account;
        private TimeSpan _timeInService;

        #endregion

        #region Constructor
        public ProfileViewModel()
        {

        }

        public ProfileViewModel(User user_account)
        {
            _user_account = user_account;
            _timeInService = DateTime.Now - user_account.Creation_date;

        }
        #endregion

        #region Properties

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

        #endregion
    }
}
