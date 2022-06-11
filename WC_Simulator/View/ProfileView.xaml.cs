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

namespace WC_Simulator.View
{
    /// <summary>
    /// Interaction logic for ProfileView.xaml
    /// </summary>
    public partial class ProfileView : UserControl
    {
        public ProfileView()
        {
            InitializeComponent();
        }

        //#region Dependencies

        //public static readonly DependencyProperty LoginProperty = DependencyProperty.Register(
        //    "Login",
        //    typeof(string),
        //    typeof(ProfileView),
        //    new FrameworkPropertyMetadata(null)
        //    );

        //public static readonly DependencyProperty TourneyCountProperty = DependencyProperty.Register(
        //    "TourneyCount",
        //    typeof(int),
        //    typeof(ProfileView),
        //    new FrameworkPropertyMetadata(null)
        //    );

        //public static readonly DependencyProperty FirstDateProperty = DependencyProperty.Register(
        //    "FirstDate",
        //    typeof(string),
        //    typeof(ProfileView),
        //    new FrameworkPropertyMetadata(null)
        //    );

        //public static readonly DependencyProperty LastDateProperty = DependencyProperty.Register(
        //    "LastDate",
        //    typeof(string),
        //    typeof(ProfileView),
        //    new FrameworkPropertyMetadata(null)
        //    );

        //public static readonly DependencyProperty TimeInServiceProperty = DependencyProperty.Register(
        //    "TimeInService",
        //    typeof(string),
        //    typeof(ProfileView),
        //    new FrameworkPropertyMetadata(null)
        //    );


        //#endregion

        //#region Properties

        //public string Login
        //{
        //    get { return (string)GetValue(LoginProperty); }
        //    set { SetValue(LoginProperty, value); }
        //}

        //public int TourneyCount
        //{
        //    get { return (int)GetValue(TourneyCountProperty); }
        //    set { SetValue(TourneyCountProperty, value); }
        //}


        //public string FirstDate
        //{
        //    get { return (string)GetValue(FirstDateProperty); }
        //    set { SetValue(FirstDateProperty, value); }
        //}

        //public string LastDate
        //{
        //    get { return (string)GetValue(LastDateProperty); }
        //    set { SetValue(LastDateProperty, value); }
        //}

        //public string TimeInService
        //{
        //    get { return (string)GetValue(TimeInServiceProperty); }
        //    set { SetValue(TimeInServiceProperty, value); }
        //}


        //#endregion

    }
}
