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



        #endregion


        #region Constructor

        public HelpViewModel(MainModel model, NavigationStore navigationStore)
        {
            Model = model;
            NavigationStore = navigationStore;
        }

        public HelpViewModel()
        {
        }

        #endregion


        #region Properties

        //public MainModel Model
        //{
        //    get { return Model; }
        //    set { Model = value; }
        //}

        //public NavigationStore NavigationStore
        //{
        //    get { return NavigationStore; }
        //    set { NavigationStore = value; }
        //}

        #endregion

    }
}
