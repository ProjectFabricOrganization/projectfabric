using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ProjectFabric.Blazor.Wasm.Services;

public class UserService
{
    private readonly AuthenticationDataMemoryStorage _authenticationDataMemoryStorage;
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient, AuthenticationDataMemoryStorage authenticationDataMemoryStorage)
    {
        _httpClient = httpClient;
        _authenticationDataMemoryStorage = authenticationDataMemoryStorage;
    }

    public async Task<User?> SendAuthenticateRequestAsync(string username, string password)
    {
        //var response = await _httpClient.GetAsync($"/example-data/{username}.json");

        //if (response.IsSuccessStatusCode)
        //{
        //    var token = await response.Content.ReadAsStringAsync();
        //    var claimPrincipal = CreateClaimsPrincipalFromToken(token);
        //    var user = User.FromClaimsPrincipal(claimPrincipal);
        //    PersistUserToBrowser(token);

        //    return user;
        //}

        return null;
    }

    private ClaimsPrincipal CreateClaimsPrincipalFromToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var identity = new ClaimsIdentity();

        if (tokenHandler.CanReadToken(token))
        {
            var jwtSecurityToken = tokenHandler.ReadJwtToken(token);
            identity = new ClaimsIdentity(jwtSecurityToken.Claims, "Blazor School");
        }

        return new ClaimsPrincipal(identity);
    }

    private void PersistUserToBrowser(string token)
    {
        _authenticationDataMemoryStorage.Token = token;
    }

    public User? FetchUserFromBrowser()
    {
        var claimsPrincipal = CreateClaimsPrincipalFromToken(_authenticationDataMemoryStorage.Token);
        var user = User.FromClaimsPrincipal(claimsPrincipal);

        return user;
    }

    public void ClearBrowserUserData() => _authenticationDataMemoryStorage.Token = "";


}