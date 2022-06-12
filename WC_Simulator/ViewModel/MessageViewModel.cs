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

        private MainModel _model;
        private NavigationStore _navigationStore;
        public BaseViewModel _targetViewModel;
        public Visibility _targetVisibility;

        #endregion


        #region Constructor

        public MessageViewModel(MainModel model, NavigationStore navigationStore, BaseViewModel targetViewModel, Visibility targetVisibility)
        {
            _model = model;
            _navigationStore = navigationStore;
            _navigationStore.MenuVisibility = Visibility.Hidden;
            _targetVisibility = targetVisibility;
            _targetViewModel = targetViewModel;
        }

        #endregion


        #region Properties

        //public MainModel Model
        //{
        //    get { return _model; }
        //    set { _model = value; }
        //}

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
                        _targetViewModel.NavigationStore = _navigationStore;
                        _navigationStore.MenuVisibility = _targetVisibility;
                        _navigationStore.CurrentViewModel = _targetViewModel;
                    },
                    arg => true);
                }
                return _changeView;
            }
        }

        #endregion
    }
}
