// using
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ProjectFabric.Blazor.Wasm;
using ProjectFabric.Blazor.Wasm.Auth;
using ProjectFabric.Blazor.Wasm.ViewModels;
using ProjectFabric.Razor.Services.Implementations;
using ProjectFabric.Razor.Services.Interfaces;
using ProjectFabric.Razor.ViewModels;

// builder with args
var builder = WebAssemblyHostBuilder.CreateDefault();
// components
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// pages view models
builder.Services.AddTransient<IndexViewModel>();
builder.Services.AddTransient<NavMenuViewModel>();
builder.Services.AddTransient<WallPaperViewModel>();
builder.Services.AddTransient<FooterViewModel>();
builder.Services.AddTransient<PricingViewModel>();
builder.Services.AddTransient<AboutViewModel>();
builder.Services.AddTransient<RegistrationViewModel>();
builder.Services.AddTransient<LoginViewModel>();

// services
builder.Services.AddBlazoredLocalStorageAsSingleton();
builder.Services.AddSingleton<IApplicationThemeService, ApplicationThemeService>();
builder.Services.AddSingleton<IApplicationStateService, ApplicationStateService>();
builder.Services.AddSingleton<AuthenticationDataMemoryStorage>();

//builder.Services.AddScoped<UserService>();
//builder.Services.AddScoped<ProjectFabricAuthenticationStateProvider>();
//builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<ProjectFabricAuthenticationStateProvider>());
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddAuthorizationCore();

//builder.Services.AddScoped<AuthenticationStateProvider, TestAuthStateProvider>();

//builder.Services.AddScoped<CustomAuthenticationMessageHandler>();
//builder.Services.AddHttpClient("api", opt =>
//{
//    opt.BaseAddress = new Uri(authority);
//}).AddHttpMessageHandler<CustomAuthenticationMessageHandler>();
//builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("api"));

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("oidc", options.ProviderOptions);
});

// run
await builder.Build().RunAsync();
