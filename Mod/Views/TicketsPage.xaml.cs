using Mod.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Mod.Views
{
    public partial class TicketsPage : UserControl
    {
        public TicketsPage()
        {
            InitializeComponent();
            DataContext = Application.Current.MainWindow.DataContext;
        }
    }
}