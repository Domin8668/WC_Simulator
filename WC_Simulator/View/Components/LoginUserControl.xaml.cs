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
    /// Interaction logic for LoginUserControl.xaml
    /// </summary>
    public partial class LoginUserControl : UserControl
    {

        #region Constructor

        public LoginUserControl()
        {
            InitializeComponent();

            TextBox.TextChanged += (sender, args) =>
            {
                Login = ((TextBox)sender).Text;
            };
        }

        #endregion


        #region Dependecies

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Login", typeof(string), typeof(LoginUserControl),
                new PropertyMetadata(default(string)));

        #endregion


        #region Properties

        public string Login
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        #endregion


        #region Events



        #endregion
    }
}
