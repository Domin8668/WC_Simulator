using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC_Simulator.Helpers.Stores;
using WC_Simulator.Model;
using WC_Simulator.ViewModel.BaseClasses;

namespace WC_Simulator.ViewModel
{
    internal class HelpViewModel : BaseViewModel
    {

        #region Variables

        private MainModel _model;
        private NavigationStore _navigationStore;

        #endregion


        #region Constructor

        public HelpViewModel(MainModel model, NavigationStore navigationStore)
        {
            _model = model;
            _navigationStore = navigationStore;
        }

        public HelpViewModel()
        {
        }

        #endregion


        #region Properties

        //public MainModel Model
        //{
        //    get { return _model; }
        //    set { _model = value; }
        //}

        //public NavigationStore NavigationStore
        //{
        //    get { return _navigationStore; }
        //    set { _navigationStore = value; }
        //}

        #endregion

    }
}
