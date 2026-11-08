using Common.Extension;
using Common.HttpClient;
using Microsoft.AspNetCore.Http;

namespace Common.Broker;

public class BrokerService(HttpClientService httpClient)
{
    const string BrokerUrl = "https://localhost:5002/api/";

    public async Task Publish(string topic, object payload, HttpContext httpContext, CancellationToken cancellation)
    {
        var request = new HttpClientRequest(HttpMethod.Post, BrokerUrl + "publish");
        request.Body = new { topic, payload=Json.Serialize(payload), token = httpContext.Token(), apiKey = httpContext.ApiKey() };
        var response=await httpClient.Send(request, cancellation);
    }
}