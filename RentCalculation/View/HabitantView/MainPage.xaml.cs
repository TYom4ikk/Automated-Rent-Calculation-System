using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using RentCalculation.Model;

namespace RentCalculation.View.HabitantView
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            if (CurrentUser.User != null)
            {
                UserNameTextBlock.Text = $"{CurrentUser.User.LastName} {CurrentUser.User.FirstName}";
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentUser.Logout();
            NavigationService.Navigate(new Uri("/View/LoginPage.xaml", UriKind.Relative));
        }

        private void InvoicesButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("/View/HabitantView/InvoicesPage.xaml", UriKind.Relative));
        }

        private void MeterReadingsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/HabitantView/MeterReadingsPage.xaml", UriKind.Relative));
        }

        private void ApartmentButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("/View/HabitantView/ApartmentPage.xaml", UriKind.Relative));
        }

        private void PaymentHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/HabitantView/PaymentHistoryPage.xaml", UriKind.Relative));
        }

        private void PersonalDataButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/HabitantView/PersonalDataPage.xaml", UriKind.Relative));
        }
    }
} 