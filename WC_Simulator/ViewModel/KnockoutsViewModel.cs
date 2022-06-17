using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC_Simulator.DAL.Entities;
using WC_Simulator.Helpers.Stores;
using WC_Simulator.Model;
using WC_Simulator.ViewModel.BaseClasses;

namespace WC_Simulator.ViewModel
{
    class KnockoutsViewModel : BaseViewModel
    {
        // faza pucharowa mundialu
        #region Variables

        private BindingList<Single_match> _matches = new BindingList<Single_match>();

        #endregion


        #region Constructor

        public KnockoutsViewModel(MainModel model, NavigationStore navigationStore)
        {
            Model = model;
            NavigationStore = navigationStore;
            //Matches = new BindingList<Single_match>() { new Single_match(1,2,1,1,1,2), new Single_match(3, 4, 1, 3, 3, 4) };
        }

        #endregion


        #region Properties
        public BindingList<Single_match> Matches
        {
            get { return _matches; }
            set { _matches = value; }
        }

        #endregion

        #region Methods
        public void PrepareMatches()
        {

        }

        #endregion


        #region Commands


        #endregion
    }
}
