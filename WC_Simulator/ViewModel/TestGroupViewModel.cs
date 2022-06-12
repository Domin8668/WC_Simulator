using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC_Simulator.Model;
using WC_Simulator.ViewModel.BaseClasses;


namespace WC_Simulator.ViewModel
{
    class TestGroupViewModel : BaseViewModel
    {
        // niepotrzebne -> 
        #region Variables
        // potem mozna te wszystkie rm, bz, bs, pkt wrzucic na jedna liste
        private MainModel _model;
        private string _team2img;
        private string _team2fn; //full name
        private string _team2rm;
        private string _team2bz;
        private string _team2bs;
        private string _team2pkt;

        #endregion

        #region Constructor

        public TestGroupViewModel(MainModel model)
        {
            Model = model;
        }

        //public TestGroupViewModel(string t2img, string t2fn, string t2rm, string t2bz, string t2bs, string t2pkt)
        //{
        //    _team2fn = t2fn;
        //    _team2rm = teamname;
        //    _team2bz = coachname;
        //    _team2img = $"../../Resources/Flags/korea.png";

        //}

        public TestGroupViewModel()
        {
            _team2img = $"../../Resources/Flags/korea.png";
            _team2fn = "Korea";
            _team2rm = "7";
            _team2bz = "6";
            _team2bs = "5";
            _team2pkt = "4";
        }

        #endregion

        #region Properties

        public MainModel Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public string Team2img
        {
            get { return _team2img; }
            set { _team2img = value; }
        }

        public string Team2fn
        {
            get { return _team2fn; }
            set
            {
                _team2fn = value;
                OnPropertyChanged(nameof(Team2fn));
            }
        }

        public string Team2rm
        {
            get { return _team2rm; }
            set { _team2rm = value; }
        }

        public string Team2bz
        {
            get { return _team2bz; }
            set { _team2bz = value; }
        }
        public string Team2bs
        {
            get { return _team2bs; }
            set { _team2bs = value; }
        }

        public string Team2pkt
        {
            get { return _team2pkt; }
            set { _team2pkt = value; }
        }


        #endregion
    }
}
