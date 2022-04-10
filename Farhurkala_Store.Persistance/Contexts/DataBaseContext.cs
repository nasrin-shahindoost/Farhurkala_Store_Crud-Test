using Farhurkala_Store.Application.Interfaces.Contexts;
using Farhurkala_Store.Common.Roles;
using Farhurkala_Store.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farhurkala_Store.Persistance.Contexts
{
   public class DataBaseContext:DbContext , IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) :base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserInRole> UserInRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //افزودن مقادیر پیشفرض به جدول Roles
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = nameof(UserRoles.Admin) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = nameof(UserRoles.Operator) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, Name = nameof(UserRoles.Customer) });


            // اعمال ایندکس بر روی فیلد ایمیل
            // اعمال عدم تکراری بودن ایمیل
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

            // اعمال فیلترینگ بر روی جدول یوزر که فقط مواردی را نشان دهد که حذف نشده اند در اپلیکیشن
            //isremoved=false
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsRemoved);
        }
    }
}
