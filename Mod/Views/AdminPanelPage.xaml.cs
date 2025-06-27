using Mod.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Mod.Views
{
    public partial class AdminPanelPage : UserControl
    {
        public AdminPanelPage()
        {
            InitializeComponent();
            DataContext = Application.Current.MainWindow.DataContext;
        }

    }
}