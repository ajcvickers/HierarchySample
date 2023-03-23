public class FamilyTreeContext : DbContext
{
    public DbSet<Halfling> Halflings => Set<Halfling>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Halflings", b => b.UseHierarchyId())
            .EnableSensitiveDataLogging()
            .LogTo(Console.WriteLine, LogLevel.Information);
}