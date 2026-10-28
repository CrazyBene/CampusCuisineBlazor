using System.Net;
using System.Net.Http.Json;

namespace CampusCuisine.Client.Tests;

// Answers every request with the given object as JSON, instead of a real backend
public class FakeApiHandler(object response) : HttpMessageHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = JsonContent.Create(response)
        });
    }
}
