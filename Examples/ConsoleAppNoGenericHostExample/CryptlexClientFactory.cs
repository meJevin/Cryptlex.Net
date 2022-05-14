using Cryptlex.Net.Core;
using Cryptlex.Net.Core.Services;
using Microsoft.Extensions.Options;

public class MyHttpClientFactory : IHttpClientFactory
{
    public HttpClient CreateClient(string name)
    {
        var client = new HttpClient();
        return client;
    }
}

public static class CryptlexClientFactory
{
    public static ICryptlexClient Create()
    {
        var token = "YOUR TOKEN";

        var cryptlexClientSettings = new CryptlexClientSettings() { AccessToken = token };

        var httpClientFactory = new MyHttpClientFactory();
        var options = Options.Create(cryptlexClientSettings);

        var accounts = new AccountsService(httpClientFactory, options);
        var accessTokens = new AccessTokensService(httpClientFactory, options);
        var licenses = new LicensesService(httpClientFactory, options);
        var activations = new ActivationsService(httpClientFactory, options);
        var tags = new TagsService(httpClientFactory, options);

        var client = new CryptlexClient(accounts, accessTokens, licenses, activations, tags);

        return client;
    }
}