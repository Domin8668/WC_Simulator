﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC_Simulator.ViewModel
{
    internal class TeamViewModel
    {
        #region Variables

        private string _teamname;
        private string _coach;
        private string _image;
        private ObservableCollection<string> _teamItems;

        #endregion

        #region Constructor

        public TeamViewModel()
        {

        }

        public TeamViewModel(string teamname, string coachname, ObservableCollection<string> team)
        {
            _teamItems = team;
            _teamname = teamname;
            _coach = coachname;
            _image = $"../../Resources/Flags/{teamname.ToLower()}.png";
        }

        #endregion

        #region Properties

        public string TeamName
        {
            get { return _teamname; }
            set { _teamname = value; }
        }

        public string Coach
        {
            get { return _coach; }
            set { _coach = value; }
        }

        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public ObservableCollection<string> TeamItems
        {
            get { return _teamItems; }
            set { _teamItems = value; }
        }



        #endregion

        #region Dependencies
        #endregion
    }
}