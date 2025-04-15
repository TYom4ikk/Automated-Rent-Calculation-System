using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RentCalculation.Model;
using RentCalculation.View.HabitantView;
using RentCalculation.ViewModel;

namespace RentCalculation.View
{
    public partial class LoginPage : Page
    {
        LoginPageViewModel viewModel;
        public LoginPage()
        {
            InitializeComponent();
            viewModel = new LoginPageViewModel();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, введите email и пароль");
                return;
            }

            try
            {
                var user = viewModel.FindUserByEmailAndPassword(email, password);

                if (user != null)
                {
                    viewModel.UpdateCurrentUser(user);
                    
                    // В зависимости от роли пользователя открываем соответствующее окно
                    if (user.RoleId == 1) // Администратор
                    {
                        NavigationService.Navigate(new AdminMainPage());
                    }
                    else if (user.RoleId == 2) // Бухгалтер
                    {
                        NavigationService.Navigate(new AccountantMainPage());
                    }
                    else if (user.RoleId == 3) // Житель
                    {
                        NavigationService.Navigate(new HabitantMainPage(user.Id));
                    }
                }
                else
                {
                    MessageBox.Show("Неверный email или пароль");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при входе: {ex.Message}");
            }
        }
    }
} 