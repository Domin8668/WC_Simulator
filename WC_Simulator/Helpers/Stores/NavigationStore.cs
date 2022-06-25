using System;
using System.Windows;
using WC_Simulator.ViewModel.BaseClasses;

namespace WC_Simulator.Helpers.Stores
{
    internal class NavigationStore
    {
        #region Variables

        private BaseViewModel _currentViewModel;
        private Visibility _menuVisibility;

        #endregion


        #region Properties

        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public Visibility MenuVisibility
        {
            get { return _menuVisibility; }
            set
            {
                _menuVisibility = value;
                OnMenuVisibilityChanged();
            }
        }

        #endregion


        #region Methods

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        private void OnMenuVisibilityChanged()
        {
            MenuVisibilityChanged?.Invoke();
        }

        #endregion


        #region Events

        public event Action CurrentViewModelChanged;
        public event Action MenuVisibilityChanged;

        #endregion

    }
}
