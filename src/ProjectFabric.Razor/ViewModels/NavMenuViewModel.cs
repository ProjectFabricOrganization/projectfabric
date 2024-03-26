using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using ProjectFabric.Razor.Models;
using ProjectFabric.Razor.Services.Interfaces;

namespace ProjectFabric.Razor.ViewModels;

public partial class NavMenuViewModel(IApplicationStateService applicationStateService,
        IApplicationThemeService applicationThemeService, NavigationManager navigationManager)
    : ViewModelBase(applicationStateService, applicationThemeService, navigationManager)
{
    [RelayCommand]
    public void GetStarted()
    {
        navigationManager.NavigateTo("./registration");
    }
    
    [RelayCommand]
    public void Logout()
    {
        navigationManager.NavigateToLogout("./authentication/logout-callback");
    }

    [RelayCommand]
    public void Login()
    {
        //navigationManager.NavigateToLogin("./authentication/login");
        navigationManager.NavigateTo("./admin");
    }
    
    [RelayCommand]
    public void SwitchDarkMode()
    {
        ApplicationThemeService.DarkModeSwitch(Theme);
        Console.WriteLine($"Theme changed to {Theme.Dark}");
    }
}