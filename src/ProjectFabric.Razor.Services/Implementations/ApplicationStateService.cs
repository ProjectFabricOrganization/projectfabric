using Blazored.LocalStorage;
using ProjectFabric.Razor.Models;
using ProjectFabric.Razor.Services.Interfaces;

namespace ProjectFabric.Razor.Services.Implementations;

public class ApplicationStateService(ILocalStorageService localStorageService) : IApplicationStateService
{
    public ApplicationState State { get; } = new();

    public async Task ChangeTheme(string theme)
    {
        if (string.IsNullOrWhiteSpace(theme))
            throw new ArgumentNullException(nameof(theme));

        await localStorageService.SetItemAsStringAsync("theme", theme);
        Console.WriteLine($"Theme changed to {theme}");
    }

    public async Task<string> LoadOrganizationId(string clientId)
    {
        var theme = await localStorageService.GetItemAsStringAsync("theme");
        return theme ?? "addinol reseller";
    }

    public void SubmitRegistrationForm()
    {
        State.UserSubmitForm = true;
    }
}