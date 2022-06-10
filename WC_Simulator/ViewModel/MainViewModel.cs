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
        private TeamViewModel _teamVM;

        #endregion
        //public ObservableCollection<string> col = new ObservableCollection<string> { "twoja stara", "twoj stary" };

        #region Constructor

        public MainViewModel()
        {
            Model = new MainModel();
            LoginViewModel login = new LoginViewModel(Model);
            RegisterViewModel register = new RegisterViewModel(Model);
            ResetPasswordViewModel resetPassword = new ResetPasswordViewModel(Model);
            //TeamVM = new TeamViewModel("Poland", "Michniewicz", col);

            CurrentViewModel = login;
            MenuVisibility = Visibility.Visible;
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

        public TeamViewModel TeamVM
        {
            get { return _teamVM; }
            set { _teamVM = value; }
        }


        #endregion


        #region Commands

        #endregion
    }
}
