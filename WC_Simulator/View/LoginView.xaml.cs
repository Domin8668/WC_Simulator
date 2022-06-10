using System.Windows;
using System.Windows.Controls;
using WC_Simulator.ViewModel;

namespace WC_Simulator.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        //private void PBPasswordChanged(object sender, RoutedEventArgs e)
        //{
        //    if (DataContext != null)
        //    { ((LoginViewModel)DataContext).SecurePassword = ((PasswordBox)sender).SecurePassword; }
        //}
    }
}
