using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using ProjectFabric.Razor.Models;
using ProjectFabric.Razor.Services.Interfaces;

namespace ProjectFabric.Razor.ViewModels;

public partial class AdminNavMenuViewModel(IApplicationStateService applicationStateService,
        IApplicationThemeService applicationThemeService, NavigationManager navigationManager)
    : ViewModelBase(applicationStateService, applicationThemeService)
{
    [ObservableProperty] private Theme _theme;

    public override Task OnInitializedAsync()
    {
        if (ApplicationStateService.State == null)
            throw new Exception("State is null");
      
        if (ApplicationThemeService.Theme == null)
            throw new Exception("Theme is null");

        Theme = ApplicationThemeService.Theme;
        
        return Task.CompletedTask;
    }

    [RelayCommand]
    public void Logout()
    {
        navigationManager.NavigateTo("/");
    }
    
    [RelayCommand]
    public void ChangeTheme()
    {
        var isDark = Theme.Dark == "dark";
        ApplicationThemeService.DarkMode(!isDark);
        Console.WriteLine($"Theme changed to {Theme.Dark}");
    }
}