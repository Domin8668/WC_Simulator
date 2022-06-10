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
using WC_Simulator.DAL.Entities;

namespace WC_Simulator.View.Components
{
    /// <summary>
    /// Interaction logic for TeamUserControl.xaml
    /// </summary>
    public partial class TeamUserControl : UserControl
    {
        public TeamUserControl()
        {
            InitializeComponent();
        }

        #region Dependencies

        public static readonly DependencyProperty TeamNameProperty = DependencyProperty.Register(
            "TeamName",
            typeof(string),
            typeof(TeamUserControl),
            new FrameworkPropertyMetadata(null)
            );

        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register(
            "Image",
            typeof(string),
            typeof(TeamUserControl),
            new FrameworkPropertyMetadata(null)
            );

        public static readonly DependencyProperty CoachProperty = DependencyProperty.Register(
            "Coach",
            typeof(string),
            typeof(TeamUserControl),
            new FrameworkPropertyMetadata(null)
            );

        public static readonly DependencyProperty TeamItemsProperty = DependencyProperty.Register(
            "TeamItems",
            typeof(ObservableCollection<string>),
            typeof(TeamUserControl),
            new FrameworkPropertyMetadata(null)
            );

        #endregion

        #region Properties

        public string TeamName
        {
            get { return (string)GetValue(TeamNameProperty); }
            set { SetValue(TeamNameProperty, value); }
        }

        public string Image
        {
            get { return (string)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public string Coach
        {
            get { return (string)GetValue(CoachProperty); }
            set { SetValue(CoachProperty, value); }
        }

        public ObservableCollection<string> TeamItems
        {
            get { return (ObservableCollection<string>)GetValue(TeamItemsProperty); }
            set { SetValue(TeamItemsProperty, value); }
        }

        #endregion

    }
}
