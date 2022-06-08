using WC_Simulator.DAL.Entities;
using WC_Simulator.ViewModel.BaseClasses;

namespace WC_Simulator.ViewModel
{
    internal class LoginViewModel : BaseViewModel
    {
        #region Variables
        #endregion

        #region Properties

        private User _currentUser;

        public User CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        #endregion

        #region Constructor
        #endregion

        #region Dependencies
        #endregion
    }
}
