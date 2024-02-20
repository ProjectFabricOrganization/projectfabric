using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using ProjectFabric.Razor.Models;
using ProjectFabric.Razor.Services.Interfaces;

namespace ProjectFabric.Razor.ViewModels;

public partial class NavMenuViewModel(IApplicationStateService applicationStateService,
        IApplicationThemeService applicationThemeService, NavigationManager navigationManager)
    : ViewModelBase(applicationStateService, applicationThemeService)
{
    [ObservableProperty] private Theme _theme;
    [ObservableProperty] private ObservableCollection<NavItem> _navItems = new();

    public override Task OnInitializedAsync()
    {
        if (ApplicationStateService.State == null)
            throw new Exception("State is null");
      
        if (ApplicationThemeService.Theme == null)
            throw new Exception("Theme is null");

        Theme = ApplicationThemeService.Theme;

        foreach (var navItem in Theme.NavItems)
            NavItems.Add(navItem);

        return Task.CompletedTask;
    }

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
        navigationManager.NavigateToLogin("./authentication/login");
    }

    [RelayCommand]
    public void ChangeTheme()
    {
        var isDark = Theme.Dark == "dark";
        Theme.Dark = isDark ? null : "dark";
        Console.WriteLine($"Theme changed to {Theme.Dark}");
    }
}