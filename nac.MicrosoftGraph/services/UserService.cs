namespace nac.MicrosoftGraph.services;

public class UserService
{
    private Microsoft.Graph.GraphServiceClient graphClient;
    private nac.http.HttpClient graphHttpClient;

    public UserService(Microsoft.Graph.GraphServiceClient __graphClient,
        nac.http.HttpClient __graphHttpClient){
        this.graphClient = __graphClient;
        this.graphHttpClient = __graphHttpClient;
    }


    public async Task<Microsoft.Graph.Models.User> getUser(string userPrincipalName)
    {
        var u = await this.graphClient.Users[userPrincipalName]
            .GetAsync();

        return u;
    }

    public  async Task<Microsoft.Graph.Models.User> getCurrentUser()
    {
            
        var user = await   this.graphHttpClient.GetJSONAsync<Microsoft.Graph.Models.User>("/v1.0/me");
        return user;
    }
}