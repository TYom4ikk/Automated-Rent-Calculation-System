using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RentCalculation.Model;
using RentCalculation.ViewModel;

namespace RentCalculation.View
{
    public partial class BuildingsPage : Page
    {
        BuildingsPageViewModel viewModel;
        public BuildingsPage()
        {
            InitializeComponent();
            viewModel = new BuildingsPageViewModel();
            LoadData();
        }

        private void LoadData()
        {
            try
            {

                var regions = viewModel.GetRegions();
                RegionComboBox.ItemsSource = regions;

                var buildings = viewModel.GetBuildings();
                BuildingsGrid.ItemsSource = buildings;

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
                if (string.IsNullOrWhiteSpace(AddressTextBox.Text) ||
                    RegionComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Пожалуйста, заполните все поля", "Ошибка",
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                var region = RegionComboBox.SelectedItem as Regions;
                var building = new Buildings
                {
                    Address = AddressTextBox.Text,
                    RegionId = region.Id
                };

                viewModel.AddBuilding(building);

                AddressTextBox.Clear();
                LoadData();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении здания: {ex.Message}", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                if (button == null) return;

                var building = button.DataContext as Buildings;
                if (building == null) return;

                var result = MessageBox.Show("Вы уверены, что хотите удалить это здание?", 
                                           "Подтверждение удаления", 
                                           MessageBoxButton.YesNo, 
                                           MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {

                    var buildingToDelete = viewModel.FindBuildingById(building.Id);
                    if (buildingToDelete != null)
                    {
                        viewModel.RemoveBuilding(buildingToDelete);
                        LoadData();
                    }
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении здания: {ex.Message}", "Ошибка", 
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
} 