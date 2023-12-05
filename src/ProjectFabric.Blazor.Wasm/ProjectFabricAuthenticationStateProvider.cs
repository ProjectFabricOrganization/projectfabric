using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using ProjectFabric.Blazor.Wasm.Services;

namespace ProjectFabric.Blazor.Wasm;

public class ProjectFabricAuthenticationStateProvider : AuthenticationStateProvider, IDisposable
{
    private readonly UserService _userService;

    public ProjectFabricAuthenticationStateProvider(UserService userService)
    {
        _userService = userService;
    }

    [JSInvokable]
    public void GoogleLogin(GoogleResponse googleResponse)
    {
        var principal = new ClaimsPrincipal();
        var user = User.FromGoogleJwt(googleResponse.Credential);
        CurrentUser = user;

        if (user is not null)
        {
            principal = user.ToClaimsPrincipal();
        }

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
    }

    public User CurrentUser { get; private set; } = new();

    public async Task LoginAsync(string username, string password)
    {
        var principal = new ClaimsPrincipal();
        var user = await _userService.SendAuthenticateRequestAsync(username, password);

        if (user is not null)
        {
            principal = user.ToClaimsPrincipal();
            CurrentUser = user;
        }

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var principal = new ClaimsPrincipal();
        var user = _userService.FetchUserFromBrowser();

        if (user is null) 
            return new AuthenticationState(principal);
        
        var authenticatedUser = await _userService.SendAuthenticateRequestAsync(user.Username, user.Password);
        if (authenticatedUser is null) 
            return new AuthenticationState(principal);
        
        principal = authenticatedUser.ToClaimsPrincipal();
        CurrentUser = authenticatedUser;

        return new AuthenticationState(principal);
    }

    public void Logout()
    {
        _userService.ClearBrowserUserData();
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal())));
    }

    private async void OnAuthenticationStateChangedAsync(Task<AuthenticationState> task)
    {
        var authenticationState = await task;

        if (authenticationState is not null) CurrentUser = User.FromClaimsPrincipal(authenticationState.User);
    }

    public void Dispose() => AuthenticationStateChanged -= OnAuthenticationStateChangedAsync;

}