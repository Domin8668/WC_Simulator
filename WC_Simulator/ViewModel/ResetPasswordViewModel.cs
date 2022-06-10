using WC_Simulator.ViewModel.BaseClasses;
using WC_Simulator.Model;

namespace WC_Simulator.ViewModel
{
    internal class ResetPasswordViewModel : BaseViewModel
    {
        #region Variables

        private MainModel _model;

        #endregion


        #region Constructor

        public ResetPasswordViewModel()
        {

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