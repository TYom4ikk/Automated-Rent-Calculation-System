using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RentCalculation.Model;
using System.Data.Entity;
using RentCalculation.ViewModel;

namespace RentCalculation.View
{
    public partial class TariffsPage : Page
    {
        public TariffsPageViewModel viewModel;
        public TariffsPage()
        {
            InitializeComponent();
            viewModel = new TariffsPageViewModel();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                ServiceComboBox.ItemsSource = viewModel.GetServices();
                ServiceComboBox.DisplayMemberPath = "Name";
                ServiceComboBox.SelectedValuePath = "Id";

                RegionComboBox.ItemsSource = viewModel.GetRegions();
                RegionComboBox.DisplayMemberPath = "Name";
                RegionComboBox.SelectedValuePath = "Id";

                var tariffs = viewModel.GetTariffs();

                TariffsGrid.ItemsSource = tariffs;

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
                    RegionComboBox.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(RateTextBox.Text))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля", "Ошибка",
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!decimal.TryParse(RateTextBox.Text, out decimal price))
                {
                    MessageBox.Show("Пожалуйста, введите корректное значение тарифа", "Ошибка",
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var service = ServiceComboBox.SelectedItem as Services;
                var region = RegionComboBox.SelectedItem as Regions;
                var tariff = new Tariffs
                {
                    ServiceId = service.Id,
                    RegionId = region.Id,
                    Price = price
                };


                viewModel.AddTariff(tariff);


                RateTextBox.Clear();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении тарифа: {ex.Message}", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                var tariff = button.DataContext as Tariffs;

                if (MessageBox.Show("Вы уверены, что хотите удалить этот тариф?", "Подтверждение",
                                  MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {

                    viewModel.RemoveTariff(tariff);

                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении тарифа: {ex.Message}", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
} 