using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WC_Simulator.Model;

namespace WC_Simulator.View.Components
{
    /// <summary>
    /// Interaction logic for GroupUserControl.xaml
    /// </summary>
    public partial class GroupUserControl : UserControl
    {
        #region Constructor

        public GroupUserControl()
        {
            InitializeComponent();
        }

        #endregion


        #region Dependencies

        public static readonly DependencyProperty TeamsProperty = DependencyProperty.Register(
            "Teams",
            typeof(ObservableCollection<TeamInGroup>),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );

        public static readonly DependencyProperty Team2ResProperty = DependencyProperty.Register(
            "Team2Result",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );

        #endregion


        #region Properties

        public ObservableCollection<TeamInGroup> Teams
        {
            get { return (ObservableCollection<TeamInGroup>)GetValue(TeamsProperty); }
            set { SetValue(TeamsProperty, value); }
        }

        public string Team2Result
        {
            get { return (string)GetValue(Team2ResProperty); }
            set { SetValue(Team2ResProperty, value); }
        }


        #endregion
    }
}
