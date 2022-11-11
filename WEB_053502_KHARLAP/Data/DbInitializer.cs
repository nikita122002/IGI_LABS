using Microsoft.AspNetCore.Identity;
using WEB_053502_KHARLAP.Entities;
using WEB_053502_KHARLAP.Data;

namespace WEB_053502_KHARLAP.Data
{

    public class DbInitializer 
    {
        public static async void Initialize(WebApplication app)
        {
            var serviceProvider = app.Services.CreateScope().ServiceProvider;

            var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            dbContext.Database.EnsureCreated();
            if (!dbContext.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };

                await roleManager.CreateAsync(roleAdmin);
            }

            if (!dbContext.Users.Any())
            {
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");

                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }

            if (!dbContext.CarGroups.Any())
            {
                dbContext.CarGroups.AddRange(
                    new List<CarGroup>
                    {
                        new CarGroup {GroupName = "Audi"},
                        new CarGroup {GroupName = "BMW"},
                        new CarGroup {GroupName = "Bentley"},
                        new CarGroup {GroupName = "Tesla"},
                        new CarGroup {GroupName = "Lamborgini"},
                        new CarGroup {GroupName = "Mercedes"}

                    });
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Cars.Any())
            {
                dbContext.Cars.AddRange(
                new List<Car>
                {
                    new Car
                    {
                        CarName = "Audi rs8",
                        Description = "Beautiful fast car",
                        Price = 100000, CarGroupId = 1, Image = "audi4.webp"
                    },
                    new Car
                    {
                        CarName = "BMWi8",
                        Description = "Fast and pretty comfortable",
                        Price = 60000, CarGroupId = 2, Image = "bmw2.jpg"
                    },
                    new Car
                    {
                        CarName = "Bentley Bentaiga",
                        Description = "Amazing comfort and speed",
                        Price = 700000,CarGroupId = 3, Image = "bentley1.jpg"
                    },
                    new Car
                    {
                        CarName = "Tesla Plaid",
                        Description = "Super modern car",
                        Price = 65000, CarGroupId = 4, Image = "tesla1.jpg"
                    },
                    new Car
                    {
                        CarName = "Lamborgini Aventador",
                        Description = "Car of your dreams",
                        Price = 400000, CarGroupId = 5, Image = "lamba.jpg"
                    }
                });
                await dbContext.SaveChangesAsync();
            }
        }
    }
}