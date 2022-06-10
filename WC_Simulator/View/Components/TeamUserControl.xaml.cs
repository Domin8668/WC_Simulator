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

        public static readonly DependencyProperty TeamNameTextProperty = DependencyProperty.Register(
            "TeamNameText",
            typeof(string),
            typeof(TeamUserControl),
            new FrameworkPropertyMetadata(null)
            );

        public static readonly DependencyProperty TeamImageLinkProperty = DependencyProperty.Register(
            "TeamImageLink",
            typeof(string),
            typeof(TeamUserControl),
            new FrameworkPropertyMetadata(null)
            );

        public static readonly DependencyProperty TeamCoachTextProperty = DependencyProperty.Register(
            "TeamCoachText",
            typeof(string),
            typeof(TeamUserControl),
            new FrameworkPropertyMetadata(null)
            );

        public static readonly DependencyProperty LvItemsProperty = DependencyProperty.Register(
            "LvItems",
            typeof(ObservableCollection<Player>),
            typeof(TeamUserControl),
            new FrameworkPropertyMetadata(null)
            );

        #endregion

        #region Properties

        public string TeamNameText
        {
            get { return (string)GetValue(TeamNameTextProperty); }
            set { SetValue(TeamNameTextProperty, value); }
        }

        public string TeamImageLink
        {
            get { return (string)GetValue(TeamImageLinkProperty); }
            set { SetValue(TeamImageLinkProperty, value); }
        }

        public string TeamCoachText
        {
            get { return (string)GetValue(TeamCoachTextProperty); }
            set { SetValue(TeamCoachTextProperty, value); }
        }

        public ObservableCollection<Player> LvItems
        {
            get { return (ObservableCollection<Player>)GetValue(LvItemsProperty); }
            set { SetValue(LvItemsProperty, value); }
        }

        #endregion



    }
}
