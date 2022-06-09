using System.Security;
using System.Windows;
using System.Windows.Controls;

namespace WC_Simulator.View.Components
{
    /// <summary>
    /// Interaction logic for PasswordUserControl.xaml
    /// </summary>
    public partial class PasswordUserControl : UserControl
    {
        #region Constructor

        //public PasswordUserControl()
        //{
        //    InitializeComponent();
        //}

        #endregion


        #region Dependecies

        //public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register(
        //    "PBPassword",
        //    typeof(SecureString),
        //    typeof(PasswordUserControl),
        //    new FrameworkPropertyMetadata(null)
        //    );

        #endregion


        #region Properties

        public SecureString Password
        {
            get { return (SecureString)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        #endregion


        #region Events



        #endregion

        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(SecureString), typeof(PasswordUserControl),
                new PropertyMetadata(default(SecureString)));

        public PasswordUserControl()
        {
            InitializeComponent();

            PasswordBox.PasswordChanged += (sender, args) =>
            {
                Password = ((PasswordBox)sender).SecurePassword;
            };
        }
    }
}
