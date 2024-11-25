using System.Threading.Tasks;

namespace Tests.lib;

public static class shared
{
    public static nac.MicrosoftGraph.Api graph { get; private set; }
    
    public static async Task setup()
    {
        var oauthSettings = nac.OAUTHLogin.repositories.VendorOAUTHSettings.GetMicrosoftOAUTHSettings();
        oauthSettings.ClientId = lib.settings.OAUTH_Microsoft_ClientId;
        oauthSettings.ClientSecret = lib.settings.OAUTH_Microsoft_ClientSecret;
        oauthSettings.Scope = "User.Read";
        
        // get a token via browser
        string token = await nac.OAUTHLogin.OAUTH.GetAuthTokenViaDefaultBrowser(oauthSettings);
        
        graph = new nac.MicrosoftGraph.Api(token);
    }
}