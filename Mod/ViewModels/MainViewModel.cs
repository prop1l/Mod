using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Mod.Database.Models;
using Mod.Command;
using Mod.Services;
using Mod.Views;
using Mod.Database;
using System.Windows;

namespace Mod.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private UserAccount _currentUser;

        private ObservableCollection<TicketType> _ticketTypes;

        public ObservableCollection<UserAccount> _users;
        private ObservableCollection<Ticket> _tickets;
        private ObservableCollection<CartItem> _cartItems;
        private decimal _totalSum;

        // ========== Свойства ==========
        public UserAccount CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsAdmin));
                OnPropertyChanged(nameof(IsCashier));
                OnPropertyChanged(nameof(IsUser));
            }
        }

        public bool IsAdmin => CurrentUser?.Role?.Name == "Администратор";
        public bool IsCashier => CurrentUser?.Role?.Name == "Кассир";
        public bool IsUser => CurrentUser?.Role?.Name == "Пользователь";

        public ObservableCollection<TicketType> TicketTypes
        {
            get => _ticketTypes;
            set
            {
                _ticketTypes = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Ticket> Tickets
        {
            get => _tickets;
            set
            {
                _tickets = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<CartItem> CartItems
        {
            get => _cartItems;
            set
            {
                _cartItems = value;
                OnPropertyChanged();
                UpdateTotalSum();
            }
        }

        public ObservableCollection<UserAccount> UserAccounts1
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged();
                
            }
        }

        public decimal TotalSum
        {
            get => _totalSum;
            private set
            {
                _totalSum = value;
                OnPropertyChanged();
            }
        }

        // ========== Команды ==========


        public ICommand AddToCartCommand { get; }
        public ICommand RemoveFromCartCommand { get; }




        // ========== Конструктор ==========
        public MainViewModel()
        {
            LoadData();


            CurrentUser = new UserAccount
            {
                Role = new Role { Name = "Пользователь" },
                FullName = "Иван Иванов"
            };


            AddToCartCommand = new RelayCommand(AddToCart);
            RemoveFromCartCommand = new RelayCommand(RemoveFromCart);
        }

        // ========== Методы ==========
        private void LoadData()
        {
            using var context = new ZooContext();
            TicketTypes = new ObservableCollection<TicketType>(context.TicketTypes.ToList());
            UserAccounts1 = new ObservableCollection<UserAccount>(context.UserAccounts.ToList());
            Tickets = new ObservableCollection<Ticket>(context.Tickets.ToList());
            CartItems = new ObservableCollection<CartItem>();
        }

        private void UpdateTotalSum()
        {
            TotalSum = CartItems.Sum(i => i.TotalPrice);
        }



        private void AddToCart(object param)
        {
            if (param is TicketType ticket)
            {
                var existing = CartItems.FirstOrDefault(i => i.Ticket.TicketTypeId == ticket.TicketTypeId);
                if (existing != null)
                    existing.Quantity++;
                else
                    CartItems.Add(new CartItem { Ticket = ticket, Quantity = 1 });

                UpdateTotalSum();
            }
        }

        private void RemoveFromCart(object param)
        {
            if (param is CartItem item)
            {
                CartItems.Remove(item);
                UpdateTotalSum();
            }
        }

        // ========== INotifyPropertyChanged ==========
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }






    }
}