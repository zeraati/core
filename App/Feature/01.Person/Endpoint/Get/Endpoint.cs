//using Common.HttpClient;
//using App.Feature.Domain;
//using Microsoft.AspNetCore.Authorization;

//namespace App.Feature.Endpoint;

//public class PersonGet(AppDbContext db, HttpClientService httpClient) : FastEndpoint<PersonGetRequest, PersonGetResponse>
//{
//    [AllowAnonymous]
//    public override void Configure()
//    {
//        Get("person");
//        AllowAnonymous();
//    }
   
//    public override async Task HandleAsync(PersonGetRequest request, CancellationToken cancellation)
//    {
//        var person = await db.Set<Person>().SingleAsync(x => x.Id == request.Id,cancellation);
//        Response = new PersonGetResponse(person);

//        var clientRequest = new HttpClientRequest(System.Net.Http.HttpMethod.Get, "https://nerkh.jahankhahan.shop/data/live.json");
//        var response=await httpClient.Send(clientRequest,cancellation);
//    }
//}