namespace CommunicationWebApi.Data
{
    public static class Extensions
    {
        public static void CreateDB(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<CommunicationDbContext>();
            context.Database.EnsureCreated();
            DBInitializer.Initialize(context);
        }
    }
}
