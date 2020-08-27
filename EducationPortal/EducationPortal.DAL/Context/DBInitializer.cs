using EducationPortal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.DAL.Context
{
    public class DBInitializer : CreateDatabaseIfNotExists<EducationPortalContext>
    {
        protected override void Seed(EducationPortalContext db)
        {
            var roleAdmin = new Role
            {
                Name = "admin",
            };

            var roleUser = new Role
            {
                Name = "user",
            };

            var user = new User
            {
                FirstName = "admin",
                LastName = "admin",
                Age = 20,
                Email = "email@gmail.com",
                Login = "admin",
                Role = roleAdmin,
                Password = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92"
            };

            db.Users.Add(user);
            db.Roles.AddRange(new List<Role>() { roleAdmin, roleUser});

            base.Seed(db);
        }
    }
}
