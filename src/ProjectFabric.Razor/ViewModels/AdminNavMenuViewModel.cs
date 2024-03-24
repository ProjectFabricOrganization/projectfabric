using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components;
using ProjectFabric.Razor.Services.Interfaces;

namespace ProjectFabric.Razor.ViewModels;

public partial class AdminNavMenuViewModel(IApplicationStateService applicationStateService,
        IApplicationThemeService applicationThemeService, NavigationManager navigationManager)
    : ViewModelBase(applicationStateService, applicationThemeService, navigationManager)
{
    [RelayCommand]
    public void Logout()
    {
        navigationManager.NavigateTo("/");
    }

    [RelayCommand]
    public void DarkModeSwitch()
    {
        ApplicationThemeService.DarkModeSwitch();
        Console.WriteLine($"Theme changed to {Theme.Dark}");
    }
}