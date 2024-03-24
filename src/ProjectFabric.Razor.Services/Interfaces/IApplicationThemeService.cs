using ProjectFabric.Razor.Models;

namespace ProjectFabric.Razor.Services.Interfaces;

public interface IApplicationThemeService
{
    Theme Theme { get; }
    
    void ChangeTheme(string organizationId);

    void DarkModeSwitch();

    Task<Theme> Generate();
}