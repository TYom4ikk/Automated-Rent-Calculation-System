using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using RentCalculation.Model;
using System.Collections.Generic;
using System.Data.Entity;
using RentCalculation.ViewModel;

namespace RentCalculation.View
{
    public partial class AccountantInvoicesPage : Page
    {
        AccountantInvoicesPageViewModel viewModel;
        public AccountantInvoicesPage()
        {
            InitializeComponent();
            viewModel = new AccountantInvoicesPageViewModel();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                // Загрузка зданий
                var buildings = viewModel.GetBuildings();
                BuildingComboBox.ItemsSource = buildings;
                BuildingComboBox.DisplayMemberPath = "Address";
                BuildingComboBox.SelectedValuePath = "Id";

                // Загрузка квитанций
                var invoices = viewModel.GetInvoicesByDesc();
                InvoicesDataGrid.ItemsSource = invoices;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
            }
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (BuildingComboBox.SelectedValue == null ||
                    StartDatePicker.SelectedDate == null ||
                    EndDatePicker.SelectedDate == null)
                {
                    MessageBox.Show("Заполните все поля");
                    return;
                }

                int buildingId = (int)BuildingComboBox.SelectedValue;
                DateTime startDate = StartDatePicker.SelectedDate.Value;
                DateTime endDate = EndDatePicker.SelectedDate.Value;

                // Получаем все квартиры в выбранном здании
                var apartments = viewModel.GetApartmentsByBuilding(buildingId);

                foreach (var apartment in apartments)
                {
                    // Создаем новую квитанцию
                    var invoice = new Invoices
                    {
                        BuildingId = buildingId,
                        ApartmentId = apartment.Id,
                        PeriodStart = startDate,
                        PeriodEnd = endDate,
                        CreatedAt = DateTime.Now,
                        TotalAmound = 0
                    };

                    // Получаем показания счетчиков за период
                    var meterReadings = Core.context.MeterReadings
                        .Where(m => m.ApartmentId == apartment.Id &&
                                   m.Date >= startDate &&
                                   m.Date <= endDate)
                        .ToList();

                    // Получаем тарифы
                    var tariffs = Core.context.Tariffs
                        .Where(t => t.RegionId == apartment.Buildings.RegionId)
                        .ToList();

                    decimal totalAmount = 0;

                    // Создаем детали квитанции
                    foreach (var reading in meterReadings)
                    {
                        var tariff = tariffs.FirstOrDefault(t => t.ServiceId == reading.ServiceId);
                        if (tariff != null)
                        {
                            decimal amount = reading.Value * tariff.Price;
                            totalAmount += amount;

                            var detail = new InvoiceDetails
                            {
                                ServiceId = reading.ServiceId,
                                Consumption = reading.Value,
                                Amount = amount
                            };

                            invoice.InvoiceDetails.Add(detail);
                        }
                    }

                    invoice.TotalAmound = totalAmount;
                    Core.context.Invoices.Add(invoice);
                }

                Core.context.SaveChanges();
                LoadData();

                MessageBox.Show("Квитанции успешно сгенерированы");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при генерации квитанций: {ex.Message}");
            }
        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            int invoiceId = (int)button.Tag;
            try
            {
                var invoice = Core.context.Invoices
                    .Include("InvoiceDetails")
                    .Include("InvoiceDetails.Services")
                    .FirstOrDefault(i => i.Id == invoiceId);

                if (invoice == null)
                {
                    MessageBox.Show("Квитанция не найдена");
                    return;
                }

                string details = $"Квитанция №{invoice.Id}\n" +
                               $"Период: {invoice.PeriodStart:dd.MM.yyyy} - {invoice.PeriodEnd:dd.MM.yyyy}\n" +
                               $"Сумма: {invoice.TotalAmound:C}\n\n" +
                               "Детали:\n";

                foreach (var detail in invoice.InvoiceDetails)
                {
                    details += $"{detail.Services.Name}: {detail.Consumption} {detail.Services.Unit} - {detail.Amount:C}\n";
                }

                MessageBox.Show(details, "Детали квитанции");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при просмотре квитанции: {ex.Message}");
            }
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // TODO: Реализовать экспорт в Excel
                MessageBox.Show("Экспорт в Excel будет реализован позже");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при экспорте: {ex.Message}");
            }
        }
    }
} 