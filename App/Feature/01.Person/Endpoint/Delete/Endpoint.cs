using App.Feature.Domain;

namespace App.Feature.Endpoint;
public class PersonDelete(AppDbContext db): FastEndpoint<PersonDeleteRequest>
{
    public override void Configure()
    {
        Delete("person");
    }

    public override async Task HandleAsync(PersonDeleteRequest request, CancellationToken cancellation)
    {
        await db.Set<Person>().Where(x => x.Id == request.Id).ExecuteDeleteAsync(cancellation);
    }
}