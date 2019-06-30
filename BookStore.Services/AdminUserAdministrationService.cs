using BookStore.Domain;
using BookStore.Services.Models.AdminUserAdministrationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class AdminUserAdministrationService
    {
        private ApplicationDbContext _db;

        public AdminUserAdministrationService()
        {
            _db = new ApplicationDbContext();
        }

        public IEnumerable<AdminUserListItem> All()
        {
            var roleId = _db.Roles.Where(m => m.Name == "Admin").Select(m => m.Id).First();

            var users = _db.Users
                .Where(m => m.Roles.Any(r => r.RoleId == roleId)).Select(m => new AdminUserListItem
                {
                    Email = m.Email,
                    FirstName = m.FirstName,
                    Id = m.Id,
                    LastName = m.LastName,
                    PhoneNumber = m.PhoneNumber
                });

            return users;
        }
    }
}
