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
        private int _position { get; set; }
        private string _image { get; set; }
        private string _country { get; set; }
        private int _matches { get; set; }
        private int _goalsFor { get; set; }
        private int _goalsAgainst { get; set; }
        private int _points { get; set; }
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
        public int GoalsFor
        {
            get { return _goalsFor; }
            set { _goalsFor = value; }
        }

        public int Bs
        {
            get { return _goalsAgainst; }
            set { _goalsAgainst = value; }
        }

        public int Points
        {
            get { return _points; }
            set { _points = value; }
        }
        #endregion

        #region Constructor
        public TeamInGroup(int lp, string image, string name, int matches, int goalsFor, int bs, int points)
        {
            Position = lp;
            Image = image;
            Country = name;
            Matches = matches;
            GoalsFor = goalsFor;
            Bs = bs;
            Points = points;

    }
        #endregion

        public override string ToString()
        {
            return "test";
        }

    }
}
