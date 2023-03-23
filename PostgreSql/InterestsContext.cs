public class InterestsContext : DbContext
{
    public DbSet<Interest> Interests => Set<Interest>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseNpgsql(
                $"Server=127.0.0.1;Database=Interests;User Id=postgres;Password={UserSecrets.Read("Interests:Password")};")
            .EnableSensitiveDataLogging()
            .LogTo(Console.WriteLine, LogLevel.Information);
}