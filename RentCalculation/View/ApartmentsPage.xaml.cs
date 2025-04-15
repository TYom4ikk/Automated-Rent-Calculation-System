using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RentCalculation.Model;

namespace RentCalculation.View
{
    public partial class ApartmentsPage : Page
    {
        public ApartmentsPage()
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
                    var buildings = context.Buildings.ToList();
                    BuildingComboBox.ItemsSource = buildings;

                    var apartments = context.Apartments
                        .Include(a => a.Building)
                        .ToList();
                    ApartmentsGrid.ItemsSource = apartments;
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
                if (BuildingComboBox.SelectedItem == null || 
                    string.IsNullOrWhiteSpace(NumberTextBox.Text) || 
                    string.IsNullOrWhiteSpace(AreaTextBox.Text))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля", "Ошибка", 
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!decimal.TryParse(AreaTextBox.Text, out decimal area))
                {
                    MessageBox.Show("Пожалуйста, введите корректное значение площади", "Ошибка", 
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                using (var context = new RentDbContext())
                {
                    var building = BuildingComboBox.SelectedItem as Building;
                    var apartment = new Apartment
                    {
                        BuildingId = building.Id,
                        Number = NumberTextBox.Text,
                        Area = area
                    };

                    context.Apartments.Add(apartment);
                    context.SaveChanges();

                    NumberTextBox.Clear();
                    AreaTextBox.Clear();
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении квартиры: {ex.Message}", "Ошибка", 
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                if (button == null) return;

                var apartment = button.DataContext as Apartment;
                if (apartment == null) return;

                var result = MessageBox.Show("Вы уверены, что хотите удалить эту квартиру?", 
                                           "Подтверждение удаления", 
                                           MessageBoxButton.YesNo, 
                                           MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    using (var context = new RentDbContext())
                    {
                        var apartmentToDelete = context.Apartments.Find(apartment.Id);
                        if (apartmentToDelete != null)
                        {
                            context.Apartments.Remove(apartmentToDelete);
                            context.SaveChanges();
                            LoadData();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении квартиры: {ex.Message}", "Ошибка", 
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
} 