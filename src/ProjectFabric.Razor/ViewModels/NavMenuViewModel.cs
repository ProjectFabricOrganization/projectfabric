using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components;
using ProjectFabric.Razor.Models;
using ProjectFabric.Razor.Services.Interfaces;

namespace ProjectFabric.Razor.ViewModels;

public partial class NavMenuViewModel : ViewModelBase
{
    private readonly IApplicationStateService _applicationStateService;
    private readonly NavigationManager _navigationManager;

    [ObservableProperty] private Theme _theme = new();
    [ObservableProperty] private ObservableCollection<NavItem> _navItems = new();

    public NavMenuViewModel(IApplicationStateService applicationStateService, NavigationManager navigationManager)
    {
        _applicationStateService = applicationStateService;
        _navigationManager = navigationManager;
    }
    
    public override Task OnInitializedAsync()
    {
        if (_applicationStateService.State == null)
            throw new Exception("State is null");

        if (_applicationStateService.State.Theme == null)
            throw new Exception("Theme is null");

        Theme = _applicationStateService.State.Theme;

        foreach (var navItem in Theme.NavItems)
            NavItems.Add(navItem);

        return Task.CompletedTask;
    }

    [RelayCommand]
    public void GetStarted()
    {
        _navigationManager.NavigateTo("registration");
    }

    [RelayCommand]
    public async Task ChangeTheme()
    {
        await _applicationStateService.ChangeTheme();
    }
}