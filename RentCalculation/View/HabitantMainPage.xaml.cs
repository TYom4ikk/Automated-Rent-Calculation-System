using System.Windows;
using System.Windows.Controls;
using RentCalculation.View;
using RentCalculation.Model;
using System.Linq;

namespace RentCalculation.View
{
    public partial class HabitantMainPage : Page
    {
        private int userId;

        public HabitantMainPage(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadCurrentUser();
        }

        private void LoadCurrentUser()
        {
            using (var context = new RentDbContext())
            {
                var user = context.Users
                    .Include(u => u.Roles)
                    .FirstOrDefault(u => u.Id == userId);
                
                if (user != null)
                {
                    Core.CurrentUser = user;
                }
            }
        }

        private void MeterReadingsButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MeterReadingsPage());
        }

        private void InvoicesButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new InvoicesPage());
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            Core.CurrentUser = null;
            NavigationService.Navigate(new LoginPage());
        }
    }
} 