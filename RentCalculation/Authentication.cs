using RentCalculation.Model;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace GardenKeeper
{
    public static class Authentication
    {
        private static List<Users> users = Core.context.Users.ToList();
        public static bool IsAuthenticated(string email, string password)
        {
            SHA256 hasher = SHA256.Create();

            byte[] data = hasher.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            foreach (var user in users)
            {
                if(user.Email == email && user.Password == sBuilder.ToString())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
