using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RentCalculation.Model;

namespace RentCalculation.View
{
    public partial class RolesPage : Page
    {
        public RolesPage()
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
                    var roles = context.Roles.ToList();
                    RolesGrid.ItemsSource = roles;
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
                if (string.IsNullOrWhiteSpace(NameTextBox.Text))
                {
                    MessageBox.Show("Пожалуйста, введите название роли", "Ошибка", 
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                using (var context = new RentDbContext())
                {
                    var role = new Role
                    {
                        Name = NameTextBox.Text
                    };

                    context.Roles.Add(role);
                    context.SaveChanges();

                    NameTextBox.Clear();
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении роли: {ex.Message}", "Ошибка", 
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                if (button == null) return;

                var role = button.DataContext as Role;
                if (role == null) return;

                var result = MessageBox.Show("Вы уверены, что хотите удалить эту роль?", 
                                           "Подтверждение удаления", 
                                           MessageBoxButton.YesNo, 
                                           MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    using (var context = new RentDbContext())
                    {
                        var roleToDelete = context.Roles.Find(role.Id);
                        if (roleToDelete != null)
                        {
                            context.Roles.Remove(roleToDelete);
                            context.SaveChanges();
                            LoadData();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении роли: {ex.Message}", "Ошибка", 
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
} 