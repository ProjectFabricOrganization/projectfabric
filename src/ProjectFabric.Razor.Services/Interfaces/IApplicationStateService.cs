using ProjectFabric.Razor.Models;

namespace ProjectFabric.Razor.Services.Interfaces;

public interface IApplicationStateService
{
    public ApplicationState State { get; }
    
    public Task Load(string organizationId);

    public Task ChangeTheme();

    void SubmitRegistrationForm();
}