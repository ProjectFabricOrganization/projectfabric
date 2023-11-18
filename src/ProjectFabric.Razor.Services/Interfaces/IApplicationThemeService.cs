using ProjectFabric.Razor.Models;

namespace ProjectFabric.Razor.Services.Interfaces;

public interface IApplicationThemeService
{
    Theme Theme { get; }

    Task<Theme> Load(string organizationId);

    Task<Theme> Generate();
}