using App.Feature.Domain;

namespace App.Feature.Endpoint;

public class PersonCreate(AppDbContext db) : FastEndpoint<PersonCreateRequest, long>
{
    public override void Configure()
    {
        Post("person");
    }

    public override async Task HandleAsync(PersonCreateRequest request, CancellationToken cancellation)
    {
        var person = new Person(request.Name, request.Mobile);
        db.Set<Person>().Add(person);
        await db.SaveChangesAsync(cancellation);
        
        await Send.Success(person.Id, null, cancellation);
    }
}
