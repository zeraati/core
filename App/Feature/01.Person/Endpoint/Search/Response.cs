using App.Feature.Domain;

namespace App.Feature.Endpoint;

public class PersonSearchResponse
{
    public PersonSearchResponse(Person person)
    {
        Id = person.Id;
        Name = person.Name;
    }

    public long Id { get; private set; }
    public string Name { get; private set; }
}
