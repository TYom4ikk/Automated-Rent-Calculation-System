using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RentCalculation.Model;
using RentCalculation.View;
using RentCalculation.ViewModel;

namespace RentCalculation.View.HabitantView
{
    public partial class InvoiceDetailsPage : Page
    {
        InvoiceDetailsPageViewModel viewModel;
        private int _invoiceId;

        public InvoiceDetailsPage(int invoiceId)
        {
            InitializeComponent();
            viewModel = new InvoiceDetailsPageViewModel();
            _invoiceId = invoiceId;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var invoice = viewModel.GetInvoicesById(_invoiceId);

                if (invoice == null)
                {
                    MessageBox.Show("Квитанция не найдена", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    NavigationService.GoBack();
                    return;
                }

                var details = viewModel.GetInvoicesByInvoiceId(_invoiceId);

                DetailsGrid.ItemsSource = details;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
} 