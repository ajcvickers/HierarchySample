public class FamilyTreeContext : DbContext
{
    public DbSet<Halfling> Halflings => Set<Halfling>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseNpgsql(
                $"Server=127.0.0.1;Database=Halflings;User Id=postgres;Password={UserSecrets.Read("Halflings:Password")};")
            .EnableSensitiveDataLogging()
            .LogTo(Console.WriteLine, LogLevel.Information);
}