namespace nac.MicrosoftGraph;

public class Api
{
    private Microsoft.Graph.GraphServiceClient graphClient;
    private nac.http.HttpClient graphHttpClient;
    
    public services.UserService User { get; private set; }

    public Api(string token)
    {
        this.setupWithToken(token);
    }
    
    private void setupWithToken(string token)
    {
        this.graphClient = new Microsoft.Graph.GraphServiceClient(CreateHttpClientWithBearerToken(token));

        this.graphHttpClient = new nac.http.HttpClient(
            baseUrl: lib.settings.baseAddressMicrosoftGraphAPI,
            args: new nac.http.model.HttpClientConfigurationOptions{
                useWindowsAuth = false,
                useBearerTokenAuthentication = true,
                bearerToken = token
            });
        
        this.User = new services.UserService(this.graphClient, this.graphHttpClient);
    }


    private static System.Net.Http.HttpClient CreateHttpClientWithBearerToken(string token)
    {
        var httpClientHandler = new System.Net.Http.HttpClientHandler();
        
        var http = new System.Net.Http.HttpClient(handler:
            new nac.http.logging.har.LoggingHandler(
                new nac.http.logging.curl.LoggingHandler(
                    httpClientHandler
                )
            )
        );

        http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        return http;
    }
}