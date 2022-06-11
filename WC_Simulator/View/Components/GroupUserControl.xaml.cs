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
    /// Interaction logic for GroupUserControl.xaml
    /// </summary>
    public partial class GroupUserControl : UserControl
    {
        public GroupUserControl()
        {
            InitializeComponent();
        }

        #region Dependencies

        //// TEAM 1
        //public static readonly DependencyProperty Team1FlagPathProperty =
        //    DependencyProperty.Register(
        //        "Team1FlagPath",                      // nazwa właściwości
        //        typeof(string),                     // typ właściwości
        //        typeof(MatchUserControl),                    // typ właściciela (czyli tutaj własna kontrolka)
        //        new FrameworkPropertyMetadata(null) // dodatkowe info
        //    );

        //public static readonly DependencyProperty Team1ShortNameProperty = DependencyProperty.Register(
        //        "Team1ShortName",
        //        typeof(string),
        //        typeof(MatchUserControl),
        //        new FrameworkPropertyMetadata(null)
        //    );

        //public static readonly DependencyProperty Team1ResultProperty = DependencyProperty.Register(
        //        "Team1Result",
        //        typeof(string),
        //        typeof(MatchUserControl),
        //        new FrameworkPropertyMetadata(null)
        //    );

        //// TEAM 2
        //public static readonly DependencyProperty Team2FlagPathProperty =
        //    DependencyProperty.Register(
        //        "Team2FlagPath",                      // nazwa właściwości
        //        typeof(string),                     // typ właściwości
        //        typeof(MatchUserControl),                    // typ właściciela (czyli tutaj własna kontrolka)
        //        new FrameworkPropertyMetadata(null) // dodatkowe info
        //    );

        //public static readonly DependencyProperty Team2ShortNameProperty = DependencyProperty.Register(
        //        "Team2ShortName",
        //        typeof(string),
        //        typeof(MatchUserControl),
        //        new FrameworkPropertyMetadata(null)
        //    );

        //public static readonly DependencyProperty Team2ResultProperty = DependencyProperty.Register(
        //        "Team2Result",
        //        typeof(string),
        //        typeof(MatchUserControl),
        //        new FrameworkPropertyMetadata(null)
        //    );

        //#endregion

        //#region Properties

        //// TEAM 1
        //public string Team1FlagPath
        //{
        //    get { return (string)GetValue(Team1FlagPathProperty); }
        //    set { SetValue(Team1FlagPathProperty, value); }
        //}

        //public string Team1ShortName
        //{
        //    get { return (string)GetValue(Team1ShortNameProperty); }
        //    set { SetValue(Team1ShortNameProperty, value); }
        //}

        //public string Team1Result
        //{
        //    get { return (string)GetValue(Team1ResultProperty); }
        //    set { SetValue(Team1ResultProperty, value); }
        //}

        //// TEAM 2
        //public string Team2FlagPath
        //{
        //    get { return (string)GetValue(Team2FlagPathProperty); }
        //    set { SetValue(Team2FlagPathProperty, value); }
        //}

        //public string Team2ShortName
        //{
        //    get { return (string)GetValue(Team2ShortNameProperty); }
        //    set { SetValue(Team2ShortNameProperty, value); }
        //}

        //public string Team2Result
        //{
        //    get { return (string)GetValue(Team2ResultProperty); }
        //    set { SetValue(Team2ResultProperty, value); }
        //}

        #endregion
    }
}
