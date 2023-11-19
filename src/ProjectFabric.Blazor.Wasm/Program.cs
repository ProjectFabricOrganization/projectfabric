// using
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProjectFabric.Blazor.Wasm;
using ProjectFabric.Blazor.Wasm.Services;
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
builder.Services.AddTransient<WallPapperViewModel>();
builder.Services.AddTransient<FooterViewModel>();
builder.Services.AddTransient<PricingViewModel>();
builder.Services.AddTransient<AboutViewModel>();
builder.Services.AddTransient<RegistrationViewModel>();

// services
builder.Services.AddBlazoredLocalStorageAsSingleton();
builder.Services.AddSingleton<IApplicationThemeService, ApplicationThemeService>();
builder.Services.AddSingleton<IApplicationStateService, ApplicationStateService>();
builder.Services.AddSingleton<AuthenticationDataMemoryStorage>();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ProjectFabricAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<ProjectFabricAuthenticationStateProvider>());
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddAuthorizationCore();

// run
await builder.Build().RunAsync();
