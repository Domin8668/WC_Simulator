using WC_Simulator.ViewModel.BaseClasses;
using WC_Simulator.Model;
using System.Windows;

namespace WC_Simulator.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {
        #region Variables

        private MainModel _model;
        private BaseViewModel _currentViewModel;
        private Visibility _menuVisibility;

        #endregion


        #region Constructor

        public MainViewModel()
        {
            Model = new MainModel();
            LoginViewModel login = new LoginViewModel();
            RegisterViewModel register = new RegisterViewModel();
            ResetPasswordViewModel resetPassword = new ResetPasswordViewModel();

            CurrentViewModel = login;
            MenuVisibility = Visibility.Hidden;
        }

        #endregion


        #region Properties

        public MainModel Model
        {
            get { return _model; }
            set { _model = value; }
        }


        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set { _currentViewModel = value; }
        }

        public Visibility MenuVisibility
        {
            get { return _menuVisibility; }
            set { _menuVisibility = value; }
        }

        #endregion


        #region Commands

        #endregion
    }
}
