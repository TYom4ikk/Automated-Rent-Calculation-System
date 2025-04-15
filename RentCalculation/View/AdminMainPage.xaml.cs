using System.Windows;
using System.Windows.Controls;
using RentCalculation.View;
using RentCalculation.ViewModel;

namespace RentCalculation.View
{
    public partial class AdminMainPage : Page
    {
        AdminMainPageViewModel viewModel;
        public AdminMainPage()
        {
            InitializeComponent();
            viewModel = new AdminMainPageViewModel();
        }

        private void UsersButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new UsersPage());
        }

        private void BuildingsButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new BuildingsPage());
        }

        private void ServicesButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ServicesPage());
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }
    }
} 