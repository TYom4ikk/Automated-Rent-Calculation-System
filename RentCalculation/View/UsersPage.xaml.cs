using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RentCalculation.Model;
using RentCalculation.ViewModel;

namespace RentCalculation.View
{
    public partial class UsersPage : Page
    {
        UserPageViewModel viewModel;
        public UsersPage()
        {
            InitializeComponent();
            viewModel = new UserPageViewModel();
            LoadData();
        }

        private void LoadData()
        {
            try
            {

                var roles = viewModel.GetRoles();
                RoleComboBox.ItemsSource = roles;

                var apartments = viewModel.GetApartments();
                ApartmentComboBox.ItemsSource = apartments;

                var users = viewModel.GetUsers();
                UsersGrid.ItemsSource = users;

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
                if (string.IsNullOrWhiteSpace(EmailTextBox.Text) ||
                    string.IsNullOrWhiteSpace(PasswordTextBox.Text) ||
                    string.IsNullOrWhiteSpace(SurnameTextBox.Text) ||
                    string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                    RoleComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Пожалуйста, заполните все обязательные поля", "Ошибка",
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var role = RoleComboBox.SelectedItem as Roles;
                var apartment = ApartmentComboBox.SelectedItem as Apartments;
                var user = new Users
                {
                    Email = EmailTextBox.Text,
                    Password = PasswordTextBox.Text,
                    Surname = SurnameTextBox.Text,
                    Name = NameTextBox.Text,
                    Patronymic = PatronymicTextBox.Text,
                    RoleId = role.Id,
                    ApartmentId = apartment?.Id
                };

                viewModel.AddUser(user);

                EmailTextBox.Clear();
                PasswordTextBox.Clear();
                SurnameTextBox.Clear();
                NameTextBox.Clear();
                PatronymicTextBox.Clear();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении пользователя: {ex.Message}", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                if (button == null) return;

                var user = button.DataContext as Users;
                if (user == null) return;

                var result = MessageBox.Show("Вы уверены, что хотите удалить этого пользователя?", 
                                           "Подтверждение удаления", 
                                           MessageBoxButton.YesNo, 
                                           MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {

                    var userToDelete = viewModel.FindUserById(user.Id);
                    if (userToDelete != null)
                    {
                        viewModel.RemoveUser(userToDelete);
                        LoadData();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении пользователя: {ex.Message}", "Ошибка", 
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
} 