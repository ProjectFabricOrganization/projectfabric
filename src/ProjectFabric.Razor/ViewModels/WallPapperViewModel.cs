using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components;
using ProjectFabric.Razor.Models;
using ProjectFabric.Razor.Services.Interfaces;

namespace ProjectFabric.Razor.ViewModels;

public partial class WallPapperViewModel : ViewModelBase
{
    private readonly NavigationManager _navigationManager;

    [ObservableProperty] private Theme _theme = new();
    [ObservableProperty] private ObservableCollection<NavItem> _navItems = new();

    public WallPapperViewModel(IApplicationStateService applicationStateService,
        IApplicationThemeService applicationThemeService, NavigationManager navigationManager) : base(
        applicationStateService, applicationThemeService)
    {
        _navigationManager = navigationManager;
    }

    public override Task OnInitializedAsync()
    {
        if (ApplicationStateService.State == null)
            throw new Exception("State is null");

        if (ApplicationStateService.State.Theme == null)
            throw new Exception("Theme is null");

        Theme = ApplicationStateService.State.Theme;

        foreach (var navItem in Theme.NavItems)
            NavItems.Add(navItem);

        return Task.CompletedTask;
    }

    [RelayCommand]
    public void GetStarted()
    {
        _navigationManager.NavigateTo("registration");
    }
}