using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RentCalculation.Model;
using RentCalculation.View;

namespace RentCalculation.View.HabitantView
{
    public partial class AddReadingPage : Page
    {
        public AddReadingPage()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                if (Core.CurrentUser == null)
                {
                    MessageBox.Show("Ошибка: пользователь не авторизован");
                    NavigationService.Navigate(new LoginPage());
                    return;
                }

                var services = Core.context.Services.ToList();
                ServiceComboBox.ItemsSource = services;
                ServiceComboBox.DisplayMemberPath = "Name";
                ServiceComboBox.SelectedValuePath = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Core.CurrentUser == null)
                {
                    MessageBox.Show("Ошибка: пользователь не авторизован");
                    NavigationService.Navigate(new LoginPage());
                    return;
                }

                if (ServiceComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Выберите услугу");
                    return;
                }

                if (!decimal.TryParse(ValueTextBox.Text, out decimal value))
                {
                    MessageBox.Show("Введите корректное значение");
                    return;
                }

                var reading = new MeterReading
                {
                    ApartmentId = Core.CurrentUser.ApartmentId,
                    ServiceId = (int)ServiceComboBox.SelectedValue,
                    Value = value,
                    ReadingDate = DateTime.Now
                };

                Core.context.MeterReadings.Add(reading);
                Core.context.SaveChanges();

                MessageBox.Show("Показания успешно добавлены");
                NavigationService.Navigate(new HabitantMainPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении показаний: {ex.Message}");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HabitantMainPage());
        }
    }
} 