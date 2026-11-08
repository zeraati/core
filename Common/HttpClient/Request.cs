using System.Text;
using System.Net.Http.Headers;

namespace Common.HttpClient;

public class HttpClientRequest
{
    public HttpClientRequest(HttpMethod method, string url) { Method = method; Url = url; }

    public HttpMethod Method { get; private set; }
    public string Url { get; private set; }
    public object? Body { get; set; }
    public string? Token { get; set; }
    public string? ApiKey { get; set; }

    public HttpRequestMessage CreateRequest(out string? bodyJson)
    {
        if (Uri.TryCreate(Url, UriKind.Absolute, out var absoluteUri) == false) throw new ArgumentException("Invalid URL");
        var request = new HttpRequestMessage(Method, absoluteUri);

        bodyJson = Body switch { null => null, string json => json, _ => Json.Serialize(Body, "bale") };
        if (bodyJson is not null) request.Content = new StringContent(bodyJson, Encoding.UTF8, "application/json");

        if (Token != null) request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Token);
        if (ApiKey != null) request.Headers.Add("X-Api-Key", ApiKey);

        return request;
    }
}




