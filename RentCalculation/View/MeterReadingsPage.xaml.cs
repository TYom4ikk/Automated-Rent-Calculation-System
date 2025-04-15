using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RentCalculation.Model;
using System.Data.Entity;

namespace RentCalculation.View
{
    public partial class MeterReadingsPage : Page
    {
        public MeterReadingsPage()
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
                    ServiceComboBox.ItemsSource = context.Services.ToList();
                    ServiceComboBox.DisplayMemberPath = "Name";
                    ServiceComboBox.SelectedValuePath = "Id";

                    var currentUser = Core.CurrentUser;
                    if (currentUser != null && currentUser.ApartmentId.HasValue)
                    {
                        var meterReadings = context.MeterReadings
                            .Include(m => m.Service)
                            .Where(m => m.ApartmentId == currentUser.ApartmentId)
                            .ToList();

                        MeterReadingsGrid.ItemsSource = meterReadings;
                    }
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
                if (ServiceComboBox.SelectedItem == null ||
                    ReadingDatePicker.SelectedDate == null ||
                    string.IsNullOrWhiteSpace(ValueTextBox.Text))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля", "Ошибка",
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!decimal.TryParse(ValueTextBox.Text, out decimal value))
                {
                    MessageBox.Show("Пожалуйста, введите корректное значение", "Ошибка",
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var currentUser = Core.CurrentUser;
                if (currentUser == null || !currentUser.ApartmentId.HasValue)
                {
                    MessageBox.Show("Ошибка: пользователь не привязан к квартире", "Ошибка",
                                  MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var service = ServiceComboBox.SelectedItem as Services;
                var meterReading = new MeterReadings
                {
                    ApartmentId = currentUser.ApartmentId.Value,
                    ServiceId = service.Id,
                    Date = ReadingDatePicker.SelectedDate.Value,
                    Value = value
                };

                using (var context = new RentDbContext())
                {
                    context.MeterReadings.Add(meterReading);
                    context.SaveChanges();
                }

                ValueTextBox.Clear();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении показаний: {ex.Message}", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                var meterReading = button.DataContext as MeterReadings;

                if (MessageBox.Show("Вы уверены, что хотите удалить эти показания?", "Подтверждение",
                                  MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    using (var context = new RentDbContext())
                    {
                        context.MeterReadings.Remove(meterReading);
                        context.SaveChanges();
                    }
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении показаний: {ex.Message}", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
} 