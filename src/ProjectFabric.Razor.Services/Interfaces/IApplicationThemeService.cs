using ProjectFabric.Razor.Models;

namespace ProjectFabric.Razor.Services.Interfaces;

public interface IApplicationThemeService
{
    Theme? FindTheme(string organizationId);

    void DarkModeSwitch(Theme theme);

    Task<Theme> Generate();
}