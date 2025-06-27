using Mod.ViewModels;
using Mod.Services;
using System.Windows;
using System.Windows.Controls;

namespace Mod.Views
{
    public partial class MainWindow : Window
    {
        public Frame AppFrame => MainFrame;

        public MainWindow()
        {
            InitializeComponent();

            var mainViewModel = new MainViewModel();
            DataContext = mainViewModel;

            var navigationService = new NavigationService(AppFrame);

            MainFrame.Navigate(new Uri("/Views/TicketsPage.xaml", UriKind.Relative));
        }

        private void EntityButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is string pageName)
            {
                try
                {
                    switch (pageName)
                    {
                        case "TicketsPage":
                            MainFrame.Navigate(new Uri("/Views/TicketsPage.xaml", UriKind.Relative));
                            break;
                        case "CartPage":
                            MainFrame.Navigate(new Uri("/Views/CartPage.xaml", UriKind.Relative));
                            break;
                        case "AdminPanelPage":
                            MainFrame.Navigate(new Uri("/Views/AdminPanelPage.xaml", UriKind.Relative));
                            break;
                        default:
                            throw new ArgumentException($"Неизвестная страница: {pageName}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки страницы: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}