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

        public static readonly DependencyProperty M1Flag_firstProperty = DependencyProperty.Register(
            "M1Flag_first",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );

        public static readonly DependencyProperty M1Flag_secondProperty = DependencyProperty.Register(
            "M1Flag_second",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );

        public static readonly DependencyProperty M1Short_firstProperty = DependencyProperty.Register(
            "M1Short_first",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );

        public static readonly DependencyProperty M1Short_secondProperty = DependencyProperty.Register(
            "M1Short_second",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );


        public static readonly DependencyProperty M1Goals_fisrt_teamProperty = DependencyProperty.Register(
            "M1Goals_first_team",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );

        public static readonly DependencyProperty M1Goals_second_teamProperty = DependencyProperty.Register(
            "M1Goals_second_team",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );
        public static readonly DependencyProperty M2Flag_firstProperty = DependencyProperty.Register(
             "M2Flag_first",
             typeof(string),
             typeof(GroupUserControl),
             new FrameworkPropertyMetadata(null)
                );

        public static readonly DependencyProperty M2Flag_secondProperty = DependencyProperty.Register(
            "M2Flag_second",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );

        public static readonly DependencyProperty M2Short_firstProperty = DependencyProperty.Register(
            "M2Short_first",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );

        public static readonly DependencyProperty M2Short_secondProperty = DependencyProperty.Register(
            "M2Short_second",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );


        public static readonly DependencyProperty M2Goals_fisrt_teamProperty = DependencyProperty.Register(
            "M2Goals_first_team",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );

        public static readonly DependencyProperty M2Goals_second_teamProperty = DependencyProperty.Register(
            "M2Goals_second_team",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );


        public static readonly DependencyProperty M3Flag_firstProperty = DependencyProperty.Register(
            "M3Flag_first",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );

        public static readonly DependencyProperty M3Flag_secondProperty = DependencyProperty.Register(
            "M3Flag_second",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );

        public static readonly DependencyProperty M3Short_firstProperty = DependencyProperty.Register(
            "M3Short_first",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );

        public static readonly DependencyProperty M3Short_secondProperty = DependencyProperty.Register(
            "M3Short_second",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );


        public static readonly DependencyProperty M3Goals_fisrt_teamProperty = DependencyProperty.Register(
            "M3Goals_first_team",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );

        public static readonly DependencyProperty M3Goals_second_teamProperty = DependencyProperty.Register(
            "M3Goals_second_team",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );


        public static readonly DependencyProperty M4Flag_firstProperty = DependencyProperty.Register(
            "M4Flag_first",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );

        public static readonly DependencyProperty M4Flag_secondProperty = DependencyProperty.Register(
            "M4Flag_second",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );

        public static readonly DependencyProperty M4Short_firstProperty = DependencyProperty.Register(
            "M4Short_first",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );

        public static readonly DependencyProperty M4Short_secondProperty = DependencyProperty.Register(
            "M4Short_second",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );


        public static readonly DependencyProperty M4Goals_fisrt_teamProperty = DependencyProperty.Register(
            "M4Goals_first_team",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );

        public static readonly DependencyProperty M4Goals_second_teamProperty = DependencyProperty.Register(
            "M4Goals_second_team",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );


        public static readonly DependencyProperty M5Flag_firstProperty = DependencyProperty.Register(
            "M5Flag_first",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );

        public static readonly DependencyProperty M5Flag_secondProperty = DependencyProperty.Register(
            "M5Flag_second",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );

        public static readonly DependencyProperty M5Short_firstProperty = DependencyProperty.Register(
            "M5Short_first",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );

        public static readonly DependencyProperty M5Short_secondProperty = DependencyProperty.Register(
            "M5Short_second",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );


        public static readonly DependencyProperty M5Goals_fisrt_teamProperty = DependencyProperty.Register(
            "M5Goals_first_team",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );

        public static readonly DependencyProperty M5Goals_second_teamProperty = DependencyProperty.Register(
            "M5Goals_second_team",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );

        public static readonly DependencyProperty M6Flag_firstProperty = DependencyProperty.Register(
            "M6Flag_first",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );

        public static readonly DependencyProperty M6Flag_secondProperty = DependencyProperty.Register(
            "M6Flag_second",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );

        public static readonly DependencyProperty M6Short_firstProperty = DependencyProperty.Register(
            "M6Short_first",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );

        public static readonly DependencyProperty M6Short_secondProperty = DependencyProperty.Register(
            "M6Short_second",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );


        public static readonly DependencyProperty M6Goals_fisrt_teamProperty = DependencyProperty.Register(
            "M6Goals_first_team",
            typeof(string),
            typeof(GroupUserControl),
            new FrameworkPropertyMetadata(null)
        );

        public static readonly DependencyProperty M6Goals_second_teamProperty = DependencyProperty.Register(
            "M6Goals_second_team",
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

        public string M1Flag_first
        {
            get { return (string)GetValue(M1Flag_firstProperty); }
            set { SetValue(M1Flag_firstProperty, value); }
        }

        public string M1Flag_second
        {
            get { return (string)GetValue(M1Flag_secondProperty); }
            set { SetValue(M1Flag_secondProperty, value); }
        }

        public string M1Short_first
        {
            get { return (string)GetValue(M1Short_firstProperty); }
            set { SetValue(M1Short_firstProperty, value); }
        }

        public string M1Short_second
        {
            get { return (string)GetValue(M1Short_secondProperty); }
            set { SetValue(M1Short_secondProperty, value); }
        }


        public string M1Goals_first_team
        {
            get { return (string)GetValue(M1Goals_fisrt_teamProperty); }
            set { SetValue(M1Goals_fisrt_teamProperty, value); }
        }

        public string M1Goals_second_team
        {
            get { return (string)GetValue(M1Goals_second_teamProperty); }
            set { SetValue(M1Goals_second_teamProperty, value); }
        }

        public string M2Flag_first
        {
            get { return (string)GetValue(M2Flag_firstProperty); }
            set { SetValue(M2Flag_firstProperty, value); }
        }

        public string M2Flag_second
        {
            get { return (string)GetValue(M2Flag_secondProperty); }
            set { SetValue(M2Flag_secondProperty, value); }
        }

        public string M2Short_first
        {
            get { return (string)GetValue(M2Short_firstProperty); }
            set { SetValue(M2Short_firstProperty, value); }
        }

        public string M2Short_second
        {
            get { return (string)GetValue(M2Short_secondProperty); }
            set { SetValue(M2Short_secondProperty, value); }
        }


        public string M2Goals_first_team
        {
            get { return (string)GetValue(M2Goals_fisrt_teamProperty); }
            set { SetValue(M2Goals_fisrt_teamProperty, value); }
        }

        public string M2Goals_second_team
        {
            get { return (string)GetValue(M2Goals_second_teamProperty); }
            set { SetValue(M2Goals_second_teamProperty, value); }
        }

        public string M3Flag_first
        {
            get { return (string)GetValue(M3Flag_firstProperty); }
            set { SetValue(M3Flag_firstProperty, value); }
        }

        public string M3Flag_second
        {
            get { return (string)GetValue(M3Flag_secondProperty); }
            set { SetValue(M3Flag_secondProperty, value); }
        }

        public string M3Short_first
        {
            get { return (string)GetValue(M3Short_firstProperty); }
            set { SetValue(M3Short_firstProperty, value); }
        }

        public string M3Short_second
        {
            get { return (string)GetValue(M3Short_secondProperty); }
            set { SetValue(M3Short_secondProperty, value); }
        }


        public string M3Goals_first_team
        {
            get { return (string)GetValue(M3Goals_fisrt_teamProperty); }
            set { SetValue(M3Goals_fisrt_teamProperty, value); }
        }

        public string M3Goals_second_team
        {
            get { return (string)GetValue(M3Goals_second_teamProperty); }
            set { SetValue(M3Goals_second_teamProperty, value); }
        }

        public string M4Flag_first
        {
            get { return (string)GetValue(M4Flag_firstProperty); }
            set { SetValue(M4Flag_firstProperty, value); }
        }

        public string M4Flag_second
        {
            get { return (string)GetValue(M4Flag_secondProperty); }
            set { SetValue(M4Flag_secondProperty, value); }
        }

        public string M4Short_first
        {
            get { return (string)GetValue(M4Short_firstProperty); }
            set { SetValue(M4Short_firstProperty, value); }
        }

        public string M4Short_second
        {
            get { return (string)GetValue(M4Short_secondProperty); }
            set { SetValue(M4Short_secondProperty, value); }
        }


        public string M4Goals_first_team
        {
            get { return (string)GetValue(M4Goals_fisrt_teamProperty); }
            set { SetValue(M4Goals_fisrt_teamProperty, value); }
        }

        public string M4Goals_second_team
        {
            get { return (string)GetValue(M4Goals_second_teamProperty); }
            set { SetValue(M4Goals_second_teamProperty, value); }
        }

        public string M5Flag_first
        {
            get { return (string)GetValue(M5Flag_firstProperty); }
            set { SetValue(M5Flag_firstProperty, value); }
        }

        public string M5Flag_second
        {
            get { return (string)GetValue(M5Flag_secondProperty); }
            set { SetValue(M5Flag_secondProperty, value); }
        }

        public string M5Short_first
        {
            get { return (string)GetValue(M5Short_firstProperty); }
            set { SetValue(M5Short_firstProperty, value); }
        }

        public string M5Short_second
        {
            get { return (string)GetValue(M5Short_secondProperty); }
            set { SetValue(M5Short_secondProperty, value); }
        }


        public string M5Goals_first_team
        {
            get { return (string)GetValue(M5Goals_fisrt_teamProperty); }
            set { SetValue(M5Goals_fisrt_teamProperty, value); }
        }

        public string M5Goals_second_team
        {
            get { return (string)GetValue(M5Goals_second_teamProperty); }
            set { SetValue(M5Goals_second_teamProperty, value); }
        }

        public string M6Flag_first
        {
            get { return (string)GetValue(M6Flag_firstProperty); }
            set { SetValue(M6Flag_firstProperty, value); }
        }

        public string M6Flag_second
        {
            get { return (string)GetValue(M6Flag_secondProperty); }
            set { SetValue(M6Flag_secondProperty, value); }
        }

        public string M6Short_first
        {
            get { return (string)GetValue(M6Short_firstProperty); }
            set { SetValue(M6Short_firstProperty, value); }
        }

        public string M6Short_second
        {
            get { return (string)GetValue(M6Short_secondProperty); }
            set { SetValue(M6Short_secondProperty, value); }
        }


        public string M6Goals_first_team
        {
            get { return (string)GetValue(M6Goals_fisrt_teamProperty); }
            set { SetValue(M6Goals_fisrt_teamProperty, value); }
        }

        public string M6Goals_second_team
        {
            get { return (string)GetValue(M6Goals_second_teamProperty); }
            set { SetValue(M6Goals_second_teamProperty, value); }
        }

        #endregion
    }
}
