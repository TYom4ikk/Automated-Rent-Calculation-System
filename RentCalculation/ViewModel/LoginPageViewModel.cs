using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using RentCalculation.Model;

namespace RentCalculation.ViewModel
{
    internal class LoginPageViewModel
    {
        public Users FindUserByEmailAndPassword(string email, string password)
        {
            return Core.context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
        public void UpdateCurrentUser(Users user)
        {
            Core.CurrentUser = user;
        }
    }
}
