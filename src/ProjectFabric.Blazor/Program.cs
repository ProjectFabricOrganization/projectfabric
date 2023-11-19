using ProjectFabric.Blazor.ViewModels;
using ProjectFabric.Razor.Services.Implementations;
using ProjectFabric.Razor.Services.Interfaces;
using ProjectFabric.Razor.ViewModels;
using ProjectFabric.Services;

namespace ProjectFabric.Blazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            // pages view models
            builder.Services.AddTransient<IndexViewModel>();
            builder.Services.AddTransient<NavMenuViewModel>();
            builder.Services.AddTransient<WallPaperViewModel>();

            //
            builder.Services.AddSingleton<OrganizationService>();
            builder.Services.AddSingleton<IApplicationThemeService, ApplicationThemeService>();
            builder.Services.AddSingleton<IApplicationStateService, ApplicationStateService>();
            //builder.Services.AddSingleton<AuthenticationDataMemoryStorage>();

            //builder.Services.AddScoped<UserService>();
            //builder.Services.AddScoped<ProjectFabricAuthenticationStateProvider>();
            //builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<ProjectFabricAuthenticationStateProvider>());
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}