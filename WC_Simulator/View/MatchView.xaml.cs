using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace WC_Simulator.View
{
    /// <summary>
    /// Interaction logic for MatchView.xaml
    /// </summary>
    public partial class MatchView : UserControl
    {
        public MatchView()
        {
            InitializeComponent();
        }


        #region Dependencies

        #region Team1
        public static readonly DependencyProperty TeamName1Property = DependencyProperty.Register(
            "TeamName1",
            typeof(string),
            typeof(MatchView),
            new FrameworkPropertyMetadata(null)
            );

        public static readonly DependencyProperty Image1Property = DependencyProperty.Register(
            "Image1",
            typeof(string),
            typeof(MatchView),
            new FrameworkPropertyMetadata(null)
            );

        public static readonly DependencyProperty Coach1Property = DependencyProperty.Register(
            "Coach1",
            typeof(string),
            typeof(MatchView),
            new FrameworkPropertyMetadata(null)
            );

        public static readonly DependencyProperty TeamItems1Property = DependencyProperty.Register(
            "TeamItems1",
            typeof(ObservableCollection<string>),
            typeof(MatchView),
            new FrameworkPropertyMetadata(null)
            );
        #endregion

        #region Info
        public static readonly DependencyProperty HourProperty = DependencyProperty.Register(
            "Hour",
            typeof(string),
            typeof(MatchView),
            new FrameworkPropertyMetadata(null)
            );

        public static readonly DependencyProperty DateProperty = DependencyProperty.Register(
            "Date",
            typeof(string),
            typeof(MatchView),
            new FrameworkPropertyMetadata(null)
            );


        public static readonly DependencyProperty TeamGoals1Property = DependencyProperty.Register(
            "TeamGoals1",
            typeof(string),
            typeof(MatchView),
            new FrameworkPropertyMetadata(null)
            );

        public static readonly DependencyProperty TeamGoals2Property = DependencyProperty.Register(
            "TeamGoals2",
            typeof(string),
            typeof(MatchView),
            new FrameworkPropertyMetadata(null)
            );

        public static readonly DependencyProperty LocationProperty = DependencyProperty.Register(
            "Location",
            typeof(string),
            typeof(MatchView),
            new FrameworkPropertyMetadata(null)
            );

        public static readonly DependencyProperty RefereeProperty = DependencyProperty.Register(
            "Referee",
            typeof(string),
            typeof(MatchView),
            new FrameworkPropertyMetadata(null)
            );
        #endregion

        #region Team2
        public static readonly DependencyProperty TeamName2Property = DependencyProperty.Register(
            "TeamName2",
            typeof(string),
            typeof(MatchView),
            new FrameworkPropertyMetadata(null)
            );

        public static readonly DependencyProperty Image2Property = DependencyProperty.Register(
            "Image2",
            typeof(string),
            typeof(MatchView),
            new FrameworkPropertyMetadata(null)
            );

        public static readonly DependencyProperty Coach2Property = DependencyProperty.Register(
            "Coach2",
            typeof(string),
            typeof(MatchView),
            new FrameworkPropertyMetadata(null)
            );

        public static readonly DependencyProperty TeamItems2Property = DependencyProperty.Register(
            "TeamItems2",
            typeof(ObservableCollection<string>),
            typeof(MatchView),
            new FrameworkPropertyMetadata(null)
            );
        #endregion

        #endregion

        #region Properties
        #region Team1 i 2
        public string TeamName1
        {
            get { return (string)GetValue(TeamName1Property); }
            set { SetValue(TeamName1Property, value); }
        }

        public string Image1
        {
            get { return (string)GetValue(Image1Property); }
            set { SetValue(Image1Property, value); }
        }

        public string Coach1
        {
            get { return (string)GetValue(Coach1Property); }
            set { SetValue(Coach1Property, value); }
        }

        public ObservableCollection<string> TeamItems1
        {
            get { return (ObservableCollection<string>)GetValue(TeamItems1Property); }
            set { SetValue(TeamItems1Property, value); }
        }

        public string TeamName2
        {
            get { return (string)GetValue(TeamName2Property); }
            set { SetValue(TeamName2Property, value); }
        }

        public string Image2
        {
            get { return (string)GetValue(Image2Property); }
            set { SetValue(Image2Property, value); }
        }

        public string Coach2
        {
            get { return (string)GetValue(Coach2Property); }
            set { SetValue(Coach2Property, value); }
        }

        public ObservableCollection<string> TeamItems2
        {
            get { return (ObservableCollection<string>)GetValue(TeamItems2Property); }
            set { SetValue(TeamItems2Property, value); }
        }
        #endregion

        public string Referee
        {
            get { return (string)GetValue(RefereeProperty); }
            set { SetValue(RefereeProperty, value); }
        }

        public string Location
        {
            get { return (string)GetValue(LocationProperty); }
            set { SetValue(LocationProperty, value); }
        }

        public string TeamGoals2
        {
            get { return (string)GetValue(TeamGoals2Property); }
            set { SetValue(TeamGoals2Property, value); }
        }

        public string TeamGoals1
        {
            get { return (string)GetValue(TeamGoals1Property); }
            set { SetValue(TeamGoals1Property, value); }
        }

        public string Hour
        {
            get { return (string)GetValue(HourProperty); }
            set { SetValue(HourProperty, value); }
        }

        public string Date
        {
            get { return (string)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }

        #endregion

    }
}
