namespace App;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        builder.Properties<string>().HaveMaxLength(500);
        builder.Properties<Enum>().HaveConversion<string>();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        // logging
        //var personType = modelBuilder.Model.FindEntityType(typeof(Person));
        //var nameProp = personType?.FindProperty(nameof(Feature.Person.Name));
        //var finalMax = nameProp?.GetMaxLength();
        //Console.WriteLine($"Person.Name MaxLength = {finalMax}");
    }
}
