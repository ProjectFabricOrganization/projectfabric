using ProjectFabric.Razor.Models;

namespace ProjectFabric.Razor.Services.Interfaces;

public interface IApplicationStateService
{
    public ApplicationState State { get; }
    
    void SubmitRegistrationForm();

    Task ChangeTheme(string theme);

    Task<string> LoadOrganizationId(string clientId);
}