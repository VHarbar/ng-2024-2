using DataAccessLayer.DatabaseContext;

namespace DataAccessLayer.Initializer
{
    public static class Initializer
    {
        public static void InitializeDb(WebShopDbContext ctx)
        {
            ctx.Database.EnsureCreated();
        }
    }
}
