using Common.Entity;

namespace App.Feature.Domain;

public partial class Person : BaseEntity
{
    private Person() { }
    public string Name { get; private set; } = null!;
    public string Mobile { get; set; } = null!;
}

public class PersonConfig : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
    }
}