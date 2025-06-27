using Mod.Database.Models;
using Microsoft.EntityFrameworkCore;
using Mod.Database;

namespace Mod.Services
{
    public static class AuthService
    {
        public static UserAccount Authenticate(string username, string password)
        {
            using var context = new ZooContext();

            var user = context.UserAccounts
                .Include(u => u.Role)
                .FirstOrDefault(u => u.FullName == username && u.Password == password);
            return user;
        }
    }
}