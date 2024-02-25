using ProjectFabric.Razor.Models;

namespace ProjectFabric.Razor.Services.Interfaces;

public interface IApplicationThemeService
{
    Theme Theme { get; }

    void Load(string organizationId);

    void DarkMode(bool isDark);

    Task<Theme> Generate();
}