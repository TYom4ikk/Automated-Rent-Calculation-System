using System.Windows;
using System.Windows.Controls;
using RentCalculation.View;
using RentCalculation.ViewModel;

namespace RentCalculation.View
{
    public partial class AccountantMainPage : Page
    {
        AccountantMainPageViewModel viewModel;
        public AccountantMainPage()
        {
            InitializeComponent();
            viewModel = new AccountantMainPageViewModel();
        }

        private void TariffsButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new TariffsPage());
        }

        private void InvoicesButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AccountantInvoicesPage());
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }
    }
} 