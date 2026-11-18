namespace App.Feature.Domain;

public partial class Person
{
    public Person(string? name,string? mobile)
    {
        Name = name;
        Mobile = mobile;
    }

    public void Update(string? name, string? mobile)
    {
        Name = name;
        Mobile = mobile;
    }
}