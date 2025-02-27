using DataAccessLayer.DatabaseContext;
using DataAccessLayer.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer.Initializer
{
    public class SeedDb
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public SeedDb(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public void SeedLocalEnv()
        {
            var userId1 = Guid.NewGuid();
            var userId2 = Guid.NewGuid();

            var accountId1 = Guid.NewGuid();
            var accountId2 = Guid.NewGuid();


            using (var scope = _scopeFactory.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<WebShopDbContext>())
                {
                    if (!context.Users.Any())
                    {
                        var user1 = new User
                        {
                            UserName = "da"
                        };

                        var user2 = new User
                        {
                            UserName = "kabanchik"
                        };

                        context.Users.AddRange(new[] { user1, user2 });
                    }

                    if (!context.Accounts.Any())
                    {
                        var users = context.Users.ToList();
                        foreach(var user in users) 
                        {
                            var account = new Account
                            {
                                Description = $"{Guid.NewGuid()} description",
                                UserId = user.Id
                            };
                            context.Accounts.Add(account);
                        }
                        context.SaveChanges();
                    }

                }
            }
        }
    }
}
