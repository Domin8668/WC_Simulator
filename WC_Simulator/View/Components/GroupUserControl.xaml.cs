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
        // FLAGI
        // TEAM 1
        public static readonly DependencyProperty Team1FlagPathProperty =
            DependencyProperty.Register(
                "Team1FlagPath",          
                typeof(string),          
                typeof(GroupUserControl),       
                new FrameworkPropertyMetadata(null)
            );

        // TEAM 2
        public static readonly DependencyProperty Team2FlagPathProperty =
            DependencyProperty.Register(
                "Team2FlagPath",                    // nazwa właściwości
                typeof(string),                     // typ właściwości
                typeof(GroupUserControl),           // typ właściciela (czyli tutaj własna kontrolka)
                new FrameworkPropertyMetadata(null) // dodatkowe info
            );

        // TEAM 3
        public static readonly DependencyProperty Team3FlagPathProperty =
            DependencyProperty.Register(
                "Team3FlagPath",                 
                typeof(string),              
                typeof(GroupUserControl),          
                new FrameworkPropertyMetadata(null)
            );

        // TEAM 4
        public static readonly DependencyProperty Team4FlagPathProperty =
            DependencyProperty.Register(
                "Team4FlagPath",               
                typeof(string),                 
                typeof(GroupUserControl),          
                new FrameworkPropertyMetadata(null)
            );

        // NAZWY
        // TEAM 1
        public static readonly DependencyProperty Team1NameProperty =
            DependencyProperty.Register(
                "Team1Name",
                typeof(string),
                typeof(GroupUserControl),
                new FrameworkPropertyMetadata(null)
            );

        // TEAM 2
        public static readonly DependencyProperty Team2NameProperty =
            DependencyProperty.Register(
                "Team2Name",          
                typeof(string),              
                typeof(GroupUserControl),          
                new FrameworkPropertyMetadata(null)
            );

        // TEAM 3
        public static readonly DependencyProperty Team3NameProperty =
            DependencyProperty.Register(
                "Team3Name",
                typeof(string),
                typeof(GroupUserControl),
                new FrameworkPropertyMetadata(null)
            );

        // TEAM 4
        public static readonly DependencyProperty Team4NameProperty =
            DependencyProperty.Register(
                "Team4Name",
                typeof(string),
                typeof(GroupUserControl),
                new FrameworkPropertyMetadata(null)
            );

        // RAZEM MECZÓW
        // TEAM 1
        public static readonly DependencyProperty Team1RMProperty =
            DependencyProperty.Register(
                "Team1RM",
                typeof(string),
                typeof(GroupUserControl),
                new FrameworkPropertyMetadata(null)
            );

        // TEAM 2
        public static readonly DependencyProperty Team2RMProperty =
            DependencyProperty.Register(
                "Team2RM",
                typeof(string),
                typeof(GroupUserControl),
                new FrameworkPropertyMetadata(null)
            );

        // TEAM 3
        public static readonly DependencyProperty Team3RMProperty =
            DependencyProperty.Register(
                "Team3RM",
                typeof(string),
                typeof(GroupUserControl),
                new FrameworkPropertyMetadata(null)
            );

        // TEAM 4
        public static readonly DependencyProperty Team4RMProperty =
            DependencyProperty.Register(
                "Team4RM",
                typeof(string),
                typeof(GroupUserControl),
                new FrameworkPropertyMetadata(null)
            );

        // BRAMKI ZDOBYTE
        // TEAM 1
        public static readonly DependencyProperty Team1BZProperty =
            DependencyProperty.Register(
                "Team1BZ",
                typeof(string),
                typeof(GroupUserControl),
                new FrameworkPropertyMetadata(null)
            );

        // TEAM 2
        public static readonly DependencyProperty Team2BZProperty =
            DependencyProperty.Register(
                "Team2BZ",
                typeof(string),
                typeof(GroupUserControl),
                new FrameworkPropertyMetadata(null)
            );

        // TEAM 3
        public static readonly DependencyProperty Team3BZProperty =
            DependencyProperty.Register(
                "Team3BZ",
                typeof(string),
                typeof(GroupUserControl),
                new FrameworkPropertyMetadata(null)
            );

        // TEAM 4
        public static readonly DependencyProperty Team4BZProperty =
            DependencyProperty.Register(
                "Team4BZ",
                typeof(string),
                typeof(GroupUserControl),
                new FrameworkPropertyMetadata(null)
            );

        // BRAMKI STRACONE
        // TEAM 1
        public static readonly DependencyProperty Team1BSProperty =
            DependencyProperty.Register(
                "Team1BS",
                typeof(string),
                typeof(GroupUserControl),
                new FrameworkPropertyMetadata(null)
            );

        // TEAM 2
        public static readonly DependencyProperty Team2BSProperty =
            DependencyProperty.Register(
                "Team2BS",
                typeof(string),
                typeof(GroupUserControl),
                new FrameworkPropertyMetadata(null)
            );

        // TEAM 3
        public static readonly DependencyProperty Team3BSProperty =
            DependencyProperty.Register(
                "Team3BS",
                typeof(string),
                typeof(GroupUserControl),
                new FrameworkPropertyMetadata(null)
            );

        // TEAM 4
        public static readonly DependencyProperty Team4BSProperty =
            DependencyProperty.Register(
                "Team4BS",
                typeof(string),
                typeof(GroupUserControl),
                new FrameworkPropertyMetadata(null)
            );

        // PUNKTY
        // TEAM 1
        public static readonly DependencyProperty Team1PKTProperty =
            DependencyProperty.Register(
                "Team1PKT",
                typeof(string),
                typeof(GroupUserControl),
                new FrameworkPropertyMetadata(null)
            );

        // TEAM 2
        public static readonly DependencyProperty Team2PKTProperty =
            DependencyProperty.Register(
                "Team2PKT",
                typeof(string),
                typeof(GroupUserControl),
                new FrameworkPropertyMetadata(null)
            );

        // TEAM 3
        public static readonly DependencyProperty Team3PKTProperty =
            DependencyProperty.Register(
                "Team3PKT",
                typeof(string),
                typeof(GroupUserControl),
                new FrameworkPropertyMetadata(null)
            );

        // TEAM 4
        public static readonly DependencyProperty Team4PKTProperty =
            DependencyProperty.Register(
                "Team4PKT",
                typeof(string),
                typeof(GroupUserControl),
                new FrameworkPropertyMetadata(null)
            );

        #endregion

        #region Properties
        // FLAGI
        // TEAM 1
        public string Team1FlagPath
        {
            get { return (string)GetValue(Team1FlagPathProperty); }
            set { SetValue(Team1FlagPathProperty, value); }
        }

        // TEAM 2
        public string Team2FlagPath
        {
            get { return (string)GetValue(Team2FlagPathProperty); }
            set { SetValue(Team2FlagPathProperty, value); }
        }

        // TEAM 3
        public string Team3FlagPath
        {
            get { return (string)GetValue(Team3FlagPathProperty); }
            set { SetValue(Team3FlagPathProperty, value); }
        }
        // TEAM 4
        public string Team4FlagPath
        {
            get { return (string)GetValue(Team4FlagPathProperty); }
            set { SetValue(Team4FlagPathProperty, value); }
        }

        // NAZWY
        // TEAM 1
        public string Team1Name
        {
            get { return (string)GetValue(Team1NameProperty); }
            set { SetValue(Team1NameProperty, value); }
        }

        // TEAM 2
        public string Team2Name
        {
            get { return (string)GetValue(Team2NameProperty); }
            set { SetValue(Team2NameProperty, value); }
        }

        // TEAM 3
        public string Team3Name
        {
            get { return (string)GetValue(Team3NameProperty); }
            set { SetValue(Team3NameProperty, value); }
        }
        // TEAM 4
        public string Team4Name
        {
            get { return (string)GetValue(Team4NameProperty); }
            set { SetValue(Team4NameProperty, value); }
        }

        // RAZEM MECZOW
        // TEAM 1
        public string Team1RM
        {
            get { return (string)GetValue(Team1RMProperty); }
            set { SetValue(Team1RMProperty, value); }
        }

        // TEAM 2
        public string Team2RM
        {
            get { return (string)GetValue(Team2RMProperty); }
            set { SetValue(Team2RMProperty, value); }
        }

        // TEAM 3
        public string Team3RM
        {
            get { return (string)GetValue(Team3RMProperty); }
            set { SetValue(Team3RMProperty, value); }
        }
        // TEAM 4
        public string Team4RM
        {
            get { return (string)GetValue(Team4RMProperty); }
            set { SetValue(Team4RMProperty, value); }
        }

        // BRAMKI ZDOBYTE
        // TEAM 1
        public string Team1BZ
        {
            get { return (string)GetValue(Team1BZProperty); }
            set { SetValue(Team1RMProperty, value); }
        }

        // TEAM 2
        public string Team2BZ
        {
            get { return (string)GetValue(Team2BZProperty); }
            set { SetValue(Team2BZProperty, value); }
        }

        // TEAM 3
        public string Team3BZ
        {
            get { return (string)GetValue(Team3BZProperty); }
            set { SetValue(Team3BZProperty, value); }
        }
        // TEAM 4
        public string Team4BZ
        {
            get { return (string)GetValue(Team4BZProperty); }
            set { SetValue(Team4BZProperty, value); }
        }

        // BRAMKI STRACONE
        // TEAM 1
        public string Team1BS
        {
            get { return (string)GetValue(Team1BSProperty); }
            set { SetValue(Team1BSProperty, value); }
        }

        // TEAM 2
        public string Team2BS
        {
            get { return (string)GetValue(Team2BSProperty); }
            set { SetValue(Team2BSProperty, value); }
        }

        // TEAM 3
        public string Team3BS
        {
            get { return (string)GetValue(Team3BSProperty); }
            set { SetValue(Team3BSProperty, value); }
        }
        // TEAM 4
        public string Team4BS
        {
            get { return (string)GetValue(Team4BSProperty); }
            set { SetValue(Team4BSProperty, value); }
        }

        // PUNKTY
        // TEAM 1
        public string Team1PKT
        {
            get { return (string)GetValue(Team1PKTProperty); }
            set { SetValue(Team1PKTProperty, value); }
        }

        // TEAM 2
        public string Team2PKT
        {
            get { return (string)GetValue(Team2PKTProperty); }
            set { SetValue(Team2PKTProperty, value); }
        }

        // TEAM 3
        public string Team3PKT
        {
            get { return (string)GetValue(Team3PKTProperty); }
            set { SetValue(Team3PKTProperty, value); }
        }
        // TEAM 4
        public string Team4PKT
        {
            get { return (string)GetValue(Team4PKTProperty); }
            set { SetValue(Team4PKTProperty, value); }
        }
        #endregion
    }
}
