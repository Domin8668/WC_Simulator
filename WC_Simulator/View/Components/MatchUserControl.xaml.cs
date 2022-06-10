using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WC_Simulator.View.Components
{
    /// <summary>
    /// Interaction logic for MatchUserControl.xaml
    /// </summary>
    public partial class MatchUserControl : UserControl
    {
        public MatchUserControl()
        {
            InitializeComponent();
        }

        #region Dependencies
        // TEAM 1
        public static readonly DependencyProperty Team2_Flag_PathProperty =
            DependencyProperty.Register(
                "Team2_Flag_Path",                      // nazwa właściwości
                typeof(string),                     // typ właściwości
                typeof(MatchUserControl),                    // typ właściciela (czyli tutaj własna kontrolka)
                new FrameworkPropertyMetadata(null) // dodatkowe info
            );

        public string Team2_Flag_Path
        {
            get { return (string)GetValue(Team2_Flag_PathProperty); }
            set { SetValue(Team2_Flag_PathProperty, value); }
        }


        public static readonly DependencyProperty Team2_ShortNameProperty = DependencyProperty.Register(
                "Team2_ShortName",
                typeof(string),
                typeof(MatchUserControl),
                new FrameworkPropertyMetadata(null)
            );

        public string Team2_ShortName
        {
            get { return (string)GetValue(Team2_ShortNameProperty); }
            set { SetValue(Team2_ShortNameProperty, value); }
        }


        public static readonly DependencyProperty Team2_ResultProperty = DependencyProperty.Register(
                "Team2_Result",
                typeof(string),
                typeof(MatchUserControl),
                new FrameworkPropertyMetadata(null)
            );
        public string Team2_Result
        {
            get { return (string)GetValue(Team2_ResultProperty); }
            set { SetValue(Team2_ResultProperty, value); }
        }

        // TEAM 2
        public static readonly DependencyProperty Team1_Flag_PathProperty =
            DependencyProperty.Register(
                "Team1_Flag_Path",                      // nazwa właściwości
                typeof(string),                     // typ właściwości
                typeof(MatchUserControl),                    // typ właściciela (czyli tutaj własna kontrolka)
                new FrameworkPropertyMetadata(null) // dodatkowe info
            );

        public string Team1_Flag_Path
        {
            get { return (string)GetValue(Team1_Flag_PathProperty); }
            set { SetValue(Team1_Flag_PathProperty, value); }
        }


        public static readonly DependencyProperty Team1_ShortNameProperty = DependencyProperty.Register(
                "Team1_ShortName",
                typeof(string),
                typeof(MatchUserControl),
                new FrameworkPropertyMetadata(null)
            );

        public string Team1_ShortName
        {
            get { return (string)GetValue(Team1_ShortNameProperty); }
            set { SetValue(Team1_ShortNameProperty, value); }
        }


        public static readonly DependencyProperty Team1_ResultProperty = DependencyProperty.Register(
                "Team1_Result",
                typeof(string),
                typeof(MatchUserControl),
                new FrameworkPropertyMetadata(null)
            );
        public string Team1_Result
        {
            get { return (string)GetValue(Team1_ResultProperty); }
            set { SetValue(Team1_ResultProperty, value); }
        }

        #endregion
    }
}
