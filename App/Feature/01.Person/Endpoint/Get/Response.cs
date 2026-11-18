using App.Feature.Domain;

namespace App.Feature.Endpoint;

public class PersonGetResponse
{
    public PersonGetResponse(Person person)
    {
        Id = person.Id;
        Name = person.Name;
    }

    public long Id { get; private set; }
    public string Name { get; private set; }
}
