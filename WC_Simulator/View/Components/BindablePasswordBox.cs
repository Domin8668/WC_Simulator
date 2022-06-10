using System.Windows;
using System.Windows.Controls;

namespace WC_Simulator.View.Components
{
    public class BindablePasswordBox : Decorator
    {
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register("Password", typeof(string), typeof(BindablePasswordBox), new PropertyMetadata(string.Empty, OnDependencyPropertyChanged));
        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        private static void OnDependencyPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            BindablePasswordBox p = source as BindablePasswordBox;
            if (p != null)
            {
                if (e.Property == PasswordProperty)
                {
                    var pb = p.Child as PasswordBox;
                    if (pb != null)
                    {
                        if (pb.Password != p.Password)
                            pb.Password = p.Password;
                    }
                }
            }
        }

        public BindablePasswordBox()
        {
            Child = new PasswordBox();
            ((PasswordBox)Child).PasswordChanged += BindablePasswordBox_PasswordChanged;
        }

        void BindablePasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = ((PasswordBox)Child).Password;
        }
    }
}
