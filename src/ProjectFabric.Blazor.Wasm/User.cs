using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ProjectFabric.Blazor.Wasm;

public class User
{
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public int Age { get; set; }
    public List<string> Roles { get; set; } = new();
    public string FullName { get; set; } = "";
    public string Email { get; set; } = "";

    public static User? FromGoogleJwt(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        if (!tokenHandler.CanReadToken(token))
            return null;

        var jwtSecurityToken = tokenHandler.ReadJwtToken(token);

        foreach (var claim in jwtSecurityToken.Claims)
        {
            Console.WriteLine($"Claim {claim.Type}: {claim.Value}");
        }

        return new User
        {
            Username = jwtSecurityToken.Claims.First(c => c.Type == "name").Value,
            Password = "",
            Email = jwtSecurityToken.Claims.First(c => c.Type == "email").Value
        };
    }

    public ClaimsPrincipal ToClaimsPrincipal()
    {
        return new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new(ClaimTypes.Name, Username),
                new(ClaimTypes.Hash, Password),
                new(nameof(Age), Age.ToString())
            }.Concat(Roles.Select(r => new Claim(ClaimTypes.Role, r)).ToArray()),
            "ProjectFabric"));
    }

    public static User FromClaimsPrincipal(ClaimsPrincipal principal)
    {
        return new User
        {
            Username = principal.FindFirst(ClaimTypes.Name)?.Value ?? "",
            Password = principal.FindFirst(ClaimTypes.Hash)?.Value ?? "",
            Age = Convert.ToInt32(principal.FindFirst(nameof(Age))?.Value),
            Roles = principal.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList(),
            FullName = principal.FindFirst(nameof(FullName))?.Value ?? ""
        };
    }
}