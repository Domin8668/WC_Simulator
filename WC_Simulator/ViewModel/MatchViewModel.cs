using WC_Simulator.Model;

namespace WC_Simulator.ViewModel
{
    internal class MatchViewModel
    {
        #region Variables

        private MainModel _model;

        #endregion


        #region Constructor

        public MatchViewModel(MainModel Model)
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
