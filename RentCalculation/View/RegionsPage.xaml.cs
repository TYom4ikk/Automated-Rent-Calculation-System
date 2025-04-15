using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RentCalculation.Model;

namespace RentCalculation.View
{
    public partial class RegionsPage : Page
    {
        public RegionsPage()
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
                    var regions = context.Regions.ToList();
                    RegionsGrid.ItemsSource = regions;
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
                if (string.IsNullOrWhiteSpace(RegionNameTextBox.Text))
                {
                    MessageBox.Show("Пожалуйста, введите название региона", "Ошибка", 
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                using (var context = new RentDbContext())
                {
                    var region = new Region
                    {
                        Name = RegionNameTextBox.Text
                    };

                    context.Regions.Add(region);
                    context.SaveChanges();

                    RegionNameTextBox.Clear();
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении региона: {ex.Message}", "Ошибка", 
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                if (button == null) return;

                var region = button.DataContext as Region;
                if (region == null) return;

                var result = MessageBox.Show("Вы уверены, что хотите удалить этот регион?", 
                                           "Подтверждение удаления", 
                                           MessageBoxButton.YesNo, 
                                           MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    using (var context = new RentDbContext())
                    {
                        var regionToDelete = context.Regions.Find(region.Id);
                        if (regionToDelete != null)
                        {
                            context.Regions.Remove(regionToDelete);
                            context.SaveChanges();
                            LoadData();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении региона: {ex.Message}", "Ошибка", 
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
} 