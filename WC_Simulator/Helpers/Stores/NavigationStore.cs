using System;
using System.Windows;
using WC_Simulator.DAL.Entities;
using WC_Simulator.ViewModel.BaseClasses;

namespace WC_Simulator.Helpers.Stores
{
    internal class NavigationStore
    {
        #region Variables

        private BaseViewModel _currentViewModel;
        private Visibility _menuVisibility;
        //private Tournament _currentTournament;

        #endregion


        #region Properties

        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set { _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public Visibility MenuVisibility
        {
            get { return _menuVisibility; }
            set { _menuVisibility = value;
                OnMenuVisibilityChanged();
            }
        }

        //public Tournament CurrentTournament
        //{
        //    get { return _currentTournament; }
        //    set
        //    {
        //        _currentTournament = value;
        //        OnCurrentTournamentChanged();
        //    }
        //}

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

        //private void OnCurrentTournamentChanged()
        //{
        //    CurrentTournamentChanged?.Invoke();
        //}

        #endregion


        #region Events

        public event Action CurrentViewModelChanged;
        public event Action MenuVisibilityChanged;
        //public event Action CurrentTournamentChanged;

        #endregion

    }
}
