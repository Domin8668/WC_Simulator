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
    class CreateTourneyViewModel : BaseViewModel
    {
        #region Variables

        private string _newTourney;
        private double _newTourneyBorder;
        private string _newTourneyWarning;

        #endregion


        #region Constructor

        public CreateTourneyViewModel(MainModel model, NavigationStore navigationStore)
        {
            Model = model;
            NavigationStore = navigationStore;
            NewTourneyWarning = string.Empty;
        }

        #endregion

        #region Properties

        public string NewTourney
        {
            get { return _newTourney; }
            set
            {
                _newTourney = value;
                if (_newTourney == string.Empty)
                {
                    NewTourneyBorder = 1;
                    NewTourneyWarning = "Nazwa turnieju nie może zostać pusta!";
                }
                else
                {
                    NewTourneyBorder = 0;
                    NewTourneyWarning = string.Empty;
                }
                OnPropertyChanged(NewTourney);
            }
        }

        public double NewTourneyBorder
        {
            get { return _newTourneyBorder; }
            set
            {
                _newTourneyBorder = value;
                OnPropertyChanged(nameof(NewTourneyBorder));
            }
        }

        public string NewTourneyWarning
        {
            get { return _newTourneyWarning; }
            set
            {
                _newTourneyWarning = value;
                OnPropertyChanged(nameof(NewTourneyWarning));
            }
        }

        #endregion
    }
}
