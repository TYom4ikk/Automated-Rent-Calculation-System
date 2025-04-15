using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RentCalculation.Model;
using RentCalculation.View;
using RentCalculation.ViewModel;

namespace RentCalculation.View.HabitantView
{
    public partial class InvoicesPage : Page
    {
        InvoicesPageViewModel viewModel;
        private int _userId;

        public InvoicesPage(int userId)
        {
            InitializeComponent();
            viewModel = new InvoicesPageViewModel();
            _userId = userId;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var user = viewModel.GetUserById(_userId);

                if (user == null || user.Apartments == null)
                {
                    MessageBox.Show("Ошибка: пользователь или квартира не найдены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    NavigationService.Navigate(new LoginPage());
                    return;
                }

                var invoices = viewModel.GetInvoicesByApartmentId(user.Apartments.Id);

                InvoicesGrid.ItemsSource = invoices;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ViewDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int invoiceId)
            {
                NavigationService.Navigate(new InvoiceDetailsPage(invoiceId));
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HabitantMainPage(_userId));
        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
} 