using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Website.Domain.Entities;

namespace Website.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

		}
        public DbSet<Phone> Phones { get; set; }
        //public DbSet<Image> Images { get; set; }
        //public DbSet<Characteristic> Characteristics { get; set; }
        //public DbSet<Example> Examples { get; set; }
        //public DbSet<PhoneImage> PhoneImages { get; set; }
        //public DbSet<PhoneExample> PhoneExamples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8"
            });

    //        modelBuilder.Entity<Characteristic>().HasData(
    //            new Characteristic { Id = 1, Name = "Цвет" },
				//new Characteristic { Id = 2, Name = "Диагональ экрана" },
				//new Characteristic { Id = 3, Name = "Разрешение экрана" },
				//new Characteristic { Id = 4, Name = "Частота экрана" },
				//new Characteristic { Id = 5, Name = "Модель процессора" },
				//new Characteristic { Id = 6, Name = "Количество ядер" },
				//new Characteristic { Id = 7, Name = "Частота процессора" },
				//new Characteristic { Id = 8, Name = "Емкость батареи" },
				//new Characteristic { Id = 9, Name = "Операционная система" },
				//new Characteristic { Id = 10, Name = "Цена" });
        }
    }
}
