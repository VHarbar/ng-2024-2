namespace Infrastructure.Persistence
{
    public static class Initializer
    {
        public static void InitializeDb(ApplicationDbContext ctx)
        {
            ctx.Database.EnsureCreated();
        }
    }
}
