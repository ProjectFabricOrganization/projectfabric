using ProjectFabric.Models;

namespace ProjectFabric.Services;

public class OrganizationService
{
    private readonly List<string> _logoGenerators;

    public OrganizationService()
    {
        _logoGenerators = new List<string>
        {
            //"https://api.svgapi.com/v1/Ty5WcDa63E/list/?search=apple&limit=20",
            "https://iconscout.com/icons/@domain?price=free"
        };
    }

    public async Task<Organization> Generate(string name, string domain)
    {
        var generatorUrl = _logoGenerators.First();
        var url = generatorUrl.Replace("@domain", domain);
        
        var logo = await GenerateSvg();
        return new Organization(name, logo);
    }

    private async Task<string> GenerateSvg()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://designious-svg-library1.p.rapidapi.com/api/files/search?keyword=*&folder=Designious%2FSVG%2FNature&per_page=1&page=1"),
            Headers =
            {
                { "Accept", "application/json" },
                { "Authorization", "Bearer {YOUR_AUTH_KEY}" },
                { "X-RapidAPI-Key", "55bb3f07a0msh8f6f1d2528690b3p15db7ejsnf3d1d37361cb" },
                { "X-RapidAPI-Host", "designious-svg-library1.p.rapidapi.com" },
            },
        };
        using var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var body = await response.Content.ReadAsStringAsync();
        Console.WriteLine(body);

        return body;
    }
}