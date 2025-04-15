using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RentCalculation.Model;
using RentCalculation.ViewModel;

namespace RentCalculation.View.HabitantView
{
    public partial class MeterReadingsPage : Page
    {
        private int _apartmentId;
        MeterReadingsPageViewModel viewModel;
        public MeterReadingsPage(int apartmentId)
        {
            InitializeComponent();
            viewModel = new MeterReadingsPageViewModel();
            _apartmentId = apartmentId;
            LoadData();
        }

        private void LoadData()
        {
            try
            {

                var apartment = viewModel.GetApartmentById(_apartmentId);
                if (apartment != null)
                {
                    ApartmentInfo.Text = $"Квартира {apartment.Number}, {apartment.Buildings.Address}";
                }

                var readings = viewModel.GetMeterReadingsByApartmentId(_apartmentId);

                ReadingsGrid.ItemsSource = readings;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
} 