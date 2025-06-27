using Mod.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Mod.Views
{
    public partial class CartPage : UserControl
    {
        public CartPage()
        {
            InitializeComponent();
            DataContext = Application.Current.MainWindow.DataContext;
        }
    }
}