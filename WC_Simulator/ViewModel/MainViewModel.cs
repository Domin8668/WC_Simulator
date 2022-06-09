using WC_Simulator.ViewModel.BaseClasses;

namespace WC_Simulator.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {
        #region Variables

        private BaseViewModel _currentViewModel;
        private bool _isVisible;

        #endregion


        #region Constructor

        public MainViewModel()
        {
            LoginViewModel login = new LoginViewModel();
            RegisterViewModel register = new RegisterViewModel();
            ResetPasswordViewModel resetPassword = new ResetPasswordViewModel();

            CurrentViewModel = login;
        }

        #endregion


        #region Properties

        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set { _currentViewModel = value; }
        }

        #endregion


        #region Commands

        #endregion
    }
}
