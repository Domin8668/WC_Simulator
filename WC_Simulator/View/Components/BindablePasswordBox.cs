using System.Windows;
using System.Windows.Controls;

namespace WC_Simulator.View.Components
{
    public class BindablePasswordBox : Decorator
    {
        #region Constructor

        public BindablePasswordBox()
        {
            Child = new PasswordBox();
            ((PasswordBox)Child).PasswordChanged += BindablePasswordBox_PasswordChanged;
        }

        #endregion


        #region Dependecies

        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register("Password", typeof(string), typeof(BindablePasswordBox), new PropertyMetadata(string.Empty, OnDependencyPropertyChanged));

        #endregion


        #region Properties

        public string Password
                {
                    get { return (string)GetValue(PasswordProperty); }
                    set { SetValue(PasswordProperty, value); }
                }

        #endregion


        #region Methods

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

        void BindablePasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
                {
                    Password = ((PasswordBox)Child).Password;
                }

        #endregion

    }
}
