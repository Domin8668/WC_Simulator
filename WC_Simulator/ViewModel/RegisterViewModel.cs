using WC_Simulator.ViewModel.BaseClasses;
using WC_Simulator.Model;

namespace WC_Simulator.ViewModel
{
    internal class RegisterViewModel : BaseViewModel
    {
        #region Variables

        private MainModel _model;

        #endregion


        #region Constructor

        public RegisterViewModel()
        {

        }

        public RegisterViewModel(MainModel Model)
        {
            this.Model = Model;
        }

        #endregion


        #region Properties

        public MainModel Model
        {
            get { return _model; }
            set { _model = value; }
        }

        #endregion
    }
}