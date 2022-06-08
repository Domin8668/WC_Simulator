using WC_Simulator.ViewModel.BaseClasses;

namespace WC_Simulator.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {
        private BaseViewModel _currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set { _currentViewModel = value; }
        }

        public MainViewModel()
        {
            LoginViewModel login = new LoginViewModel();
            RegisterViewModel register = new RegisterViewModel();
            ResetPasswordViewModel resetPassword = new ResetPasswordViewModel();

            CurrentViewModel = login;
        }
    }
}
