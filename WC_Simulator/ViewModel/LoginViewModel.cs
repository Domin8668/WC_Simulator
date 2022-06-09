using WC_Simulator.DAL.Entities;
using WC_Simulator.ViewModel.BaseClasses;
using WC_Simulator.Model;

namespace WC_Simulator.ViewModel
{
    internal class LoginViewModel : BaseViewModel
    {
        #region Variables

        private User _currentUser;
        private MainModel _model;

        #endregion

        #region Constructor

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

        #endregion

        #region Dependencies
        #endregion
    }
}
