using ProjectFabric.Razor.Models;

namespace ProjectFabric.Razor.Services.Interfaces;

public interface IApplicationStateService
{
    public ApplicationState State { get; }
    
    void SubmitRegistrationForm();
}