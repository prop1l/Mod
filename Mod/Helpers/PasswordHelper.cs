using System.Windows;
using System.Windows.Controls;

namespace Mod.Helpers
{
    public static class PasswordHelper
    {
        public static readonly DependencyProperty Password =
            DependencyProperty.RegisterAttached(
                "Password",
                typeof(string),
                typeof(PasswordHelper),
                new FrameworkPropertyMetadata(string.Empty, OnPasswordPropertyChanged));

        public static string GetPassword(DependencyObject obj)
        {
            return (string)obj.GetValue(Password);
        }

        public static void SetPassword(DependencyObject obj, string value)
        {
            obj.SetValue(Password, value);
        }

        private static void OnPasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PasswordBox passwordBox)
            {
                passwordBox.Password = e.NewValue?.ToString();
            }
        }

        public static readonly DependencyProperty Attach =
            DependencyProperty.RegisterAttached(
                "Attach",
                typeof(bool),
                typeof(PasswordHelper),
                new PropertyMetadata(false, OnAttach));

        public static bool GetAttach(DependencyObject obj)
        {
            return (bool)obj.GetValue(Attach);
        }

        public static void SetAttach(DependencyObject obj, bool value)
        {
            obj.SetValue(Attach, value);
        }

        private static void OnAttach(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PasswordBox passwordBox && (bool)e.NewValue)
            {
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            var viewModel = passwordBox.DataContext as LoginViewModel;

            if (viewModel != null)
            {
                viewModel.Password = passwordBox.Password;
            }
        }
    }
}