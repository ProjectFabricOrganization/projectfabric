﻿using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace ProjectFabric.Blazor.Wasm.Auth;

public class TestAuthStateProvider : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var anonymous = new ClaimsIdentity();
        return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
    }
}