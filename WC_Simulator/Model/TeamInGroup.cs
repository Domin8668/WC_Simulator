using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC_Simulator.Model
{
    public class TeamInGroup
    {
        #region Variables

        private int _position;
        private string _image;
        private string _country;
        private int _matches;
        private int _gf;
        private int _ga;
        private int _points;

        #endregion


        #region Constructor

        public TeamInGroup(int lp, string image, string country, int matches, int gf, int ga, int points)
        {
            _position = lp;
            _image = image;
            _country = country;
            _matches = matches;
            _gf = gf;
            _ga = ga;
            _points = points;
        }

        #endregion


        #region Properties

        public int Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public int Matches
        {
            get { return _matches; }
            set { _matches = value; }
        }

        public int GF
        {
            get { return _gf; }
            set { _gf = value; }
        }

        public int GA
        {
            get { return _ga; }
            set { _ga = value; }
        }

        public int Points
        {
            get { return _points; }
            set { _points = value; }
        }

        #endregion

        public override string ToString()
        {
            return "test";
        }
    }
}
