using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RentCalculation.Model;

namespace RentCalculation.View
{
    public partial class InvoiceDetailsPage : Page
    {
        public InvoiceDetailsPage()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (var context = new RentDbContext())
                {
                    var invoices = context.Invoices.ToList();
                    InvoiceComboBox.ItemsSource = invoices;

                    var services = context.Services.ToList();
                    ServiceComboBox.ItemsSource = services;

                    var invoiceDetails = context.InvoiceDetails
                        .Include(d => d.Invoice)
                        .Include(d => d.Service)
                        .ToList();
                    InvoiceDetailsGrid.ItemsSource = invoiceDetails;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", 
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (InvoiceComboBox.SelectedItem == null || 
                    ServiceComboBox.SelectedItem == null || 
                    string.IsNullOrWhiteSpace(AmountTextBox.Text))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля", "Ошибка", 
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!decimal.TryParse(AmountTextBox.Text, out decimal amount))
                {
                    MessageBox.Show("Пожалуйста, введите корректное значение суммы", "Ошибка", 
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                using (var context = new RentDbContext())
                {
                    var invoice = InvoiceComboBox.SelectedItem as Invoice;
                    var service = ServiceComboBox.SelectedItem as Service;
                    var invoiceDetail = new InvoiceDetail
                    {
                        InvoiceId = invoice.Id,
                        ServiceId = service.Id,
                        Amount = amount
                    };

                    context.InvoiceDetails.Add(invoiceDetail);
                    context.SaveChanges();

                    AmountTextBox.Clear();
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении детали квитанции: {ex.Message}", "Ошибка", 
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                if (button == null) return;

                var invoiceDetail = button.DataContext as InvoiceDetail;
                if (invoiceDetail == null) return;

                var result = MessageBox.Show("Вы уверены, что хотите удалить эту деталь квитанции?", 
                                           "Подтверждение удаления", 
                                           MessageBoxButton.YesNo, 
                                           MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    using (var context = new RentDbContext())
                    {
                        var invoiceDetailToDelete = context.InvoiceDetails.Find(invoiceDetail.Id);
                        if (invoiceDetailToDelete != null)
                        {
                            context.InvoiceDetails.Remove(invoiceDetailToDelete);
                            context.SaveChanges();
                            LoadData();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении детали квитанции: {ex.Message}", "Ошибка", 
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
} 