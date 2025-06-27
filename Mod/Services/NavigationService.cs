using Mod.Services;
using System.Windows.Controls;

public class NavigationService : INavigationService
{
    private readonly Frame _frame;

    public NavigationService(Frame frame)
    {
        _frame = frame;
    }

    public void Navigate(UserControl page)
    {
        _frame?.Navigate(page);
    }
}