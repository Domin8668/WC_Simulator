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
    /// Interaction logic for UsernameUserControl.xaml
    /// </summary>
    public partial class UsernameUserControl : UserControl
    {
        #region Constructor

        public UsernameUserControl()
        {
            InitializeComponent();

            TextBox.TextChanged += (sender, args) =>
            {
                Username = ((TextBox)sender).Text;
            };
        }

        #endregion


        #region Dependecies

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Username", typeof(string), typeof(UsernameUserControl),
                new PropertyMetadata(default(string)));

        #endregion


        #region Properties

        public string Username
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        #endregion


        #region Events



        #endregion

    }
}
