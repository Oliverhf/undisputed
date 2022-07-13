using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using Undisputed.Data.Enum;
using Undisputed.Models;

namespace Undisputed.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Topics.Any())
                {
                    context.Topics.AddRange(new List<Topic>()
                    {
                        new Topic()
                        {
                            Title = "Goods for Men",
                            Image = "https://nypost.com/wp-content/uploads/sites/2/2022/05/mens-gifts.jpg?quality=75&strip=all",
                            Description = "This is the description of the first topic",
                            TopicCategory = TopicCategory.Goods,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Charlotte",
                                State = "NC"
                            }
                         },
                        new Topic()
                        {
                            Title = "Economy Topic",
                            Image = "https://store.councilforeconed.org/product_image.asp?id=4583&szType=2",
                            Description = "This is the description of the first cinema",
                            TopicCategory = TopicCategory.Economy,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Birmingham",
                                State = "AL"
                            }
                        },
                        new Topic()
                        {
                            Title = "Travel 3",
                            Image = "https://www.travel-nation.ca/documents/386175/0/slider+2+%281%29.jpg",
                            Description = "This is the description of Travel Topic",
                            TopicCategory = TopicCategory.Travel,
                            Address = new Address()
                            {
                                Street = "506 Main St",
                                City = "Jackson",
                                State = "MS"
                            }
                        },
                        new Topic()
                        {
                            Title = "Running Topic 3",
                            Image = "https://img.freepik.com/free-photo/big-city_1127-3102.jpg?size=626&ext=jpg",
                            Description = "This is the description of the first Topic",
                            TopicCategory = TopicCategory.City,
                            Address = new Address()
                            {
                                Street = "431 Main St",
                                City = "Oklahoma",
                                State = "OK"
                            }
                        }
                    });
                    context.SaveChanges();
}
                //NeatTopics
                if (!context.NeatTopics.Any())
                {
                    context.NeatTopics.AddRange(new List<NeatTopic>()
                    {
                        new NeatTopic()
                        {
                            Title = "Economy Data NeatTopic 1",
                            Image = "https://bouldereconomiccouncil.org/wp-content/uploads/business_resources-900.jpg",
                            Description = "This is the description of the first NeatTopic",
                            NeatTopicCategory = NeatTopicCategory.EconomyData,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Charlotte",
                                State = "NC"
}
                        },
                        new NeatTopic()
                        {
                            Title = "Gym NeatTopic 2",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the second NeatTopic",
                            NeatTopicCategory = NeatTopicCategory.Gym,
                            AddressId = 5,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Fargo",
                                State = "ND"
                            }
                        }
                    });
                    context.SaveChanges();
                }

                // Teams
                if (!context.Teams.Any())
                {
                    context.Teams.AddRange(new List<Team>()
                    {
                        new Team()
                        {
                            Title = "Team of KickBox Trainning",
                            Image = "https://i1.wp.com/www.mmaplus.co.uk/wp-content/uploads/2016/06/13410341_10154935504676038_1484402111_o-e1465337148615.jpg?fit=1024%2C517",
                            Description = "This is the description of the first Team",
                            TeamCategory = TeamCategory.RealKickBox,
                            Address = new Address()
                            {
                                Street = "533 Main St",
                                City = "New York",
                                State = "NY"
}
                        },
                        new Team()
                        {
                            Title = "Economy for My Pocket 1",
                            Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f9/Money_Cash.jpg/1200px-Money_Cash.jpg",
                            Description = "This is the description of the second Team",
                            TeamCategory = TeamCategory.EconomyForMyPocket,
                            AddressId = 5,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Fargo",
                                State = "ND"
                            }
                        }
                    });
                    context.SaveChanges();
                }
            }
        }

        //public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        //{
        //    using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        //    {
        //        //Roles
        //        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        //        if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        //        if (!await roleManager.RoleExistsAsync(UserRoles.User))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        //        //Users
        //        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
        //        string adminUserEmail = "teddysmithdeveloper@gmail.com";

        //        var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
        //        if (adminUser == null)
        //        {
        //            var newAdminUser = new AppUser()
        //            {
        //                UserName = "oliverfavalli",
        //                Email = adminUserEmail,
        //                EmailConfirmed = true,
        //                Address = new Address()
        //                {
        //                    Street = "502 Ocean Drive",
        //                    City = "Tampa",
        //                    State = "FL"
        //                }
        //            };
        //            await userManager.CreateAsync(newAdminUser, "Coding@1234?");
        //            await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
        //        }

        //        string appUserEmail = "user@etickets.com";

        //        var appUser = await userManager.FindByEmailAsync(appUserEmail);
        //        if (appUser == null)
        //        {
        //            var newAppUser = new AppUser()
        //            {
        //                UserName = "app-user",
        //                Email = appUserEmail,
        //                EmailConfirmed = true,
        //                Address = new Address()
        //                {
        //                    Street = "502 Ocean Drive",
        //                    City = "Tampa",
        //                    State = "FL"
        //                }
        //            };
        //            await userManager.CreateAsync(newAppUser, "Coding@1234?");
        //            await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
        //        }
        //    }
        //}
    }
}
