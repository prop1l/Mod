using System.Windows;
using System.Windows.Navigation;
using Mod.Services;

namespace Mod
{
    public partial class App : Application
    {
        private static readonly NavigationService _navigationService = new(null);

        public static INavigationService GetService() => _navigationService;

        // Этот метод должен быть универсальным (generic)
        public static T? GetService<T>() where T : class
        {
            return (INavigationService?)_navigationService as T;
        }
    }
}