using App.Feature.Domain;

namespace App.Feature.Endpoint;

public class PersonSearch(AppDbContext db) : FastEndpoint<PersonSearchRequest, PersonSearchResponse[]>
{
    public override void Configure()
    {
        Get("person/search");
    }

    public override async Task HandleAsync(PersonSearchRequest request, CancellationToken cancellation)
    {
        var query = db.Set<Person>().AsQueryable();
        if (request.Name != null) query = query.Where(x => x.Name.Contains(request.Name));
        var persons = await query.Select(x => new PersonSearchResponse(x)).ToArrayAsync(cancellation);

        await Send.Success(persons,null, cancellation);
    }
}
