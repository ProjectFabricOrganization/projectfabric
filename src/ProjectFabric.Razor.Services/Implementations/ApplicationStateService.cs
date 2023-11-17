using Blazored.LocalStorage;
using ProjectFabric.Razor.Models;
using ProjectFabric.Razor.Services.Interfaces;

namespace ProjectFabric.Razor.Services.Implementations;

public class ApplicationStateService : IApplicationStateService
{
    private readonly IApplicationThemeService _themeService;

    public ApplicationStateService(IApplicationThemeService themeService)
    {
        _themeService = themeService;
        State = new ApplicationState();
    }

    public ApplicationState State { get; }
    
    public async Task Load(string organizationId)
    {
        State.Theme = await _themeService.Load(organizationId);
    }

    public async Task ChangeTheme()
    {
        //var theme = await _localStorageService.GetItemAsStringAsync("theme");
        //if (theme == "dark")
        //{
        //    State.Theme.Dark = null;
        //    await _localStorageService.SetItemAsStringAsync("theme", "light");
        //}
        //else
        //{
        //    State.Theme.Dark = "dark";
        //    await _localStorageService.SetItemAsStringAsync("theme", "dark");
        //}
    }

    public void SubmitRegistrationForm()
    {
        State.UserSubmitForm = true;
    }
}