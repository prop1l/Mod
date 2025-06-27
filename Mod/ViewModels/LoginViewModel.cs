using Mod.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows;
using Mod.Services;
using Mod.ViewModels;
using Mod.Command;

public class LoginViewModel : INotifyPropertyChanged
{
    private string _username;

    public string Username { get => _username; set { _username = value; OnPropertyChanged(); } }
    private string _password;
    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged();
        }
    }



    public ICommand LoginCommand { get; }

    public LoginViewModel()
    {
        LoginCommand = new RelayCommand(Login);
    }

    private void Login(object obj)
    {



        var user = AuthService.Authenticate(Username, Password);
        if (user != null)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();

            Application.Current.MainWindow = mainWindow;

            var windowToClose = Application.Current.Windows
                .OfType<LoginWindow>()
                .FirstOrDefault();

            windowToClose?.Close();
        }
        else
        {
            MessageBox.Show("Неверный логин или пароль");
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}