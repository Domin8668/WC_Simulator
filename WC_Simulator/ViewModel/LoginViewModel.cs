using WC_Simulator.DAL.Entities;
using WC_Simulator.ViewModel.BaseClasses;

namespace WC_Simulator.ViewModel
{
    internal class LoginViewModel : BaseViewModel
    {
        #region Variables

        private User _currentUser;

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

        #endregion

        #region Dependencies
        #endregion
    }
}
