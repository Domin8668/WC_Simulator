using WC_Simulator.ViewModel.BaseClasses;
using WC_Simulator.Model;
using System;
using WC_Simulator.DAL.Entities;
using WC_Simulator.Helpers.Stores;
using System.Windows.Input;
using System.Windows;
using WC_Simulator.Helpers.Hashing;

namespace WC_Simulator.ViewModel
{
    internal class MessageViewModel : BaseViewModel
    {
        #region Variables

        private string _message;
        public BaseViewModel _targetViewModel;
        public Visibility _targetVisibility;

        #endregion


        #region Constructor

        public MessageViewModel(MainModel model, NavigationStore navigationStore, BaseViewModel targetViewModel, Visibility targetVisibility, string message)
        {
            Model = model;
            NavigationStore = navigationStore;
            NavigationStore.MenuVisibility = Visibility.Hidden;
            _targetVisibility = targetVisibility;
            _targetViewModel = targetViewModel;
            _message = message;
        }

        #endregion


        #region Properties

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        #endregion


        #region Commands

        private ICommand _changeView = null;

        public ICommand ChangeView
        {
            get
            {
                if (_changeView == null)
                {
                    _changeView = new RelayCommand(arg =>
                    {
                        _targetViewModel.Model = Model;
                        _targetViewModel.NavigationStore = NavigationStore;
                        NavigationStore.MenuVisibility = _targetVisibility;
                        NavigationStore.CurrentViewModel = _targetViewModel;
                    },
                    arg => true);
                }
                return _changeView;
            }
        }

        #endregion
    }
}
