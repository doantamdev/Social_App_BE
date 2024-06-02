using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReactMXHApi6.Core.Entities;

namespace ReactMXHApi6.Infrastructure.Data
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<AppUser> userManager, DataContext context)
        {
            if (!await context.Posts.AnyAsync())
            {
                if (!await userManager.Users.AnyAsync())
                {
                    var users = new List<AppUser> {
                        new AppUser { 
                            UserName = "doantam", 
                            DisplayName = "Huynh Doan Tam", 
                            ImageUrl = "images/post2.jpg"
                        },
                        new AppUser{ UserName="ubuntu", DisplayName = "Ubuntu Nguyễn", ImageUrl = "images/post2.jpg"},
                        new AppUser{UserName="lisa", DisplayName = "Lisa" },
                        new AppUser{UserName="minhtruong", DisplayName = "Minh Truong", ImageUrl = "images/user3.jpg" },
                        new AppUser{UserName="minhtri", DisplayName = "Minh Tri" },
                        new AppUser{UserName="hoangtho", DisplayName = "Hoang Tho", ImageUrl = "images/user3.jpg" },
                        new AppUser{UserName="doantam123", DisplayName = "Doan Tam" },
                        new AppUser{UserName="doantamne", DisplayName = "Doan Tam ne" },
                        new AppUser{UserName="tamhuynh", DisplayName = "Tam Huynh Doan" },
                        new AppUser{UserName="tamdz", DisplayName = "Tam hjhj" },
                    };

                    foreach (var user in users)
                    {
                        await userManager.CreateAsync(user, "123456");
                    }
                }

                var posts = new List<Post>
                {
                    new Post{
                        NoiDung="Chan wa " +
                        "Di choi khong moi nguoi",
                        UserId = userManager.Users.FirstOrDefault().Id,
                    },
                     new Post{
                        NoiDung="Dang lam gi do" +
                        " Co nho a khong",
                        UserId = userManager.Users.FirstOrDefault().Id,
                    },
                      new Post{
                        NoiDung="Nhan tin khum ne " +
                        "ib di",
                        UserId = userManager.Users.FirstOrDefault().Id,
                    },
                };

                context.Posts.AddRange(posts);

                await context.SaveChangesAsync();
            }                      
        }
    }
}
