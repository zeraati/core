using App.Feature.Domain;

namespace App.Feature.Endpoint;

public class PersonUpdate(AppDbContext db) : FastEndpoint<PersonUpdateRequest>
{
    public override void Configure()
    {
        Put("person");
    }

    public override async Task HandleAsync(PersonUpdateRequest request, CancellationToken cancellation)
    {
        var person = await db.Set<Person>().SingleAsync(x => x.Id == request.Id, cancellation);
        //person.Update(request.Name);
        db.Set<Person>().Update(person);
        await db.SaveChangesAsync(cancellation);
    }
}