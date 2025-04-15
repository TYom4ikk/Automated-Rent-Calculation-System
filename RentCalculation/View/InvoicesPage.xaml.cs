using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RentCalculation.Model;

namespace RentCalculation.View
{
    public partial class InvoicesPage : Page
    {
        public InvoicesPage()
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
                    var apartments = context.Apartments.ToList();
                    ApartmentComboBox.ItemsSource = apartments;

                    var invoices = context.Invoices
                        .Include(i => i.Apartment)
                        .ToList();
                    InvoicesGrid.ItemsSource = invoices;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", 
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ApartmentComboBox.SelectedItem == null || 
                    StartDatePicker.SelectedDate == null || 
                    EndDatePicker.SelectedDate == null)
                {
                    MessageBox.Show("Пожалуйста, заполните все поля", "Ошибка", 
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (StartDatePicker.SelectedDate.Value > EndDatePicker.SelectedDate.Value)
                {
                    MessageBox.Show("Дата начала не может быть позже даты окончания", "Ошибка", 
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                using (var context = new RentDbContext())
                {
                    var apartment = ApartmentComboBox.SelectedItem as Apartment;
                    var startDate = StartDatePicker.SelectedDate.Value;
                    var endDate = EndDatePicker.SelectedDate.Value;

                    // Получаем показания счетчиков за период
                    var meterReadings = context.MeterReadings
                        .Include(m => m.Service)
                        .Where(m => m.ApartmentId == apartment.Id && 
                                  m.ReadingDate >= startDate && 
                                  m.ReadingDate <= endDate)
                        .ToList();

                    // Получаем тарифы для услуг
                    var tariffs = context.Tariffs
                        .Include(t => t.Service)
                        .Where(t => t.RegionId == apartment.Building.RegionId)
                        .ToList();

                    // Рассчитываем сумму для каждой услуги
                    decimal totalAmount = 0;
                    var invoiceDetails = new List<InvoiceDetail>();

                    foreach (var reading in meterReadings)
                    {
                        var tariff = tariffs.FirstOrDefault(t => t.ServiceId == reading.ServiceId);
                        if (tariff != null)
                        {
                            decimal amount = reading.Value * tariff.Rate;
                            totalAmount += amount;

                            invoiceDetails.Add(new InvoiceDetail
                            {
                                ServiceId = reading.ServiceId,
                                Amount = amount
                            });
                        }
                    }

                    // Создаем квитанцию
                    var invoice = new Invoice
                    {
                        ApartmentId = apartment.Id,
                        Period = endDate,
                        TotalAmount = totalAmount,
                        CreationDate = DateTime.Now,
                        Details = invoiceDetails
                    };

                    context.Invoices.Add(invoice);
                    context.SaveChanges();

                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при формировании квитанции: {ex.Message}", "Ошибка", 
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                if (button == null) return;

                var invoice = button.DataContext as Invoice;
                if (invoice == null) return;

                using (var context = new RentDbContext())
                {
                    var invoiceDetails = context.InvoiceDetails
                        .Include(d => d.Service)
                        .Where(d => d.InvoiceId == invoice.Id)
                        .ToList();

                    string details = "Детали квитанции:\n\n";
                    foreach (var detail in invoiceDetails)
                    {
                        details += $"{detail.Service.Name}: {detail.Amount:N2} руб.\n";
                    }
                    details += $"\nИтого: {invoice.TotalAmount:N2} руб.";

                    MessageBox.Show(details, "Детали квитанции", 
                                  MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при просмотре деталей: {ex.Message}", "Ошибка", 
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // TODO: Реализовать экспорт в Excel
                MessageBox.Show("Экспорт в Excel будет реализован в следующей версии", "Информация", 
                              MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при экспорте: {ex.Message}", "Ошибка", 
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
} 