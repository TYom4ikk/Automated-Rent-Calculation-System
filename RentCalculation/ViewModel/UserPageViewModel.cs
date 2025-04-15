using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentCalculation.Model;

namespace RentCalculation.ViewModel
{
    internal class UserPageViewModel
    {
        public List<Roles> GetRoles()
        {
            return Core.context.Roles.ToList();
        }

        public List<Apartments> GetApartments()
        {
            return Core.context.Apartments.ToList();
        }
        public List<Users> GetUsers()
        {
            return Core.context.Users.ToList();
        }
        public void AddUser(Users user)
        {
            Core.context.Users.Add(user);
            Core.context.SaveChanges();
        }
        public Users FindUserById(int id)
        {
            return Core.context.Users.Find(id);
        }
        public void RemoveUser(Users user)
        {
            Core.context.Users.Remove(user);
            Core.context.SaveChanges();
        }
    }
}
