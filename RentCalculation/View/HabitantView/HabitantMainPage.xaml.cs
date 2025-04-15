using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RentCalculation.Model;
using RentCalculation.View;

namespace RentCalculation.View.HabitantView
{
    public partial class HabitantMainPage : Page
    {
        private int _userId;

        public HabitantMainPage(int userId)
        {
            InitializeComponent();
            _userId = userId;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var user = Core.context.Users
                    .FirstOrDefault(u => u.Id == _userId);

                if (user == null || user.Apartments == null)
                {
                    MessageBox.Show("Ошибка: пользователь или квартира не найдены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    NavigationService.Navigate(new LoginPage());
                    return;
                }

                AddressTextBlock.Text = $"Адрес: {user.Apartments.Buildings.Address}, кв. {user.Apartments.Number}";
                AreaTextBlock.Text = $"Площадь: {user.Apartments.Area} кв.м";

                // Загрузка последних показаний счетчиков
                var lastReadings = Core.context.MeterReadings
                    .Where(r => r.ApartmentId == user.Apartments.Id)
                    .OrderByDescending(r => r.Date)
                    .Take(5)
                    .Select(r => new
                    {
                        ServiceName = r.Services.Name,
                        Date = r.Date,
                        Value = r.Value,
                        Unit = r.Services.Unit
                    })
                    .ToList();

                LastReadingsGrid.ItemsSource = lastReadings;

                // Загрузка последних квитанций
                var lastInvoices = Core.context.Invoices
                    .Where(i => i.ApartmentId == user.Apartments.Id)
                    .OrderByDescending(i => i.Id)
                    .Take(5)
                    .ToList();

                LastInvoicesGrid.ItemsSource = lastInvoices;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MeterReadingsButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO : NavigationService.Navigate(new AddReadingPage());
        }

        private void InvoicesButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InvoicesPage(_userId));
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            Core.CurrentUser = null;
            NavigationService.Navigate(new LoginPage());
        }
    }
} 