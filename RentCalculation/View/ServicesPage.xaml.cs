using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using RentCalculation.Model;
using RentCalculation.ViewModel;

namespace RentCalculation.View
{
    /// <summary>
    /// Логика взаимодействия для ServicesPage.xaml
    /// </summary>
    public partial class ServicesPage : Page
    {
        private ServicesPageViewModel viewModel;

        public ServicesPage()
        {
            InitializeComponent();
            viewModel = new ServicesPageViewModel();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                ServicesGrid.ItemsSource = viewModel.GetServices();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(NameTextBox.Text))
                {
                    MessageBox.Show("Введите название услуги", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var service = new Services
                {
                    Name = NameTextBox.Text,
                    Unit = UnitTextBox.Text
                };

                viewModel.AddService(service);
                LoadData();
                NameTextBox.Clear();
                UnitTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении услуги: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var service = (sender as Button).DataContext as Services;
                if (service == null) return;

                var result = MessageBox.Show("Вы уверены, что хотите удалить эту услугу?", "Подтверждение", 
                    MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    viewModel.RemoveService(service);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении услуги: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
} 