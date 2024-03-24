using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components;
using ProjectFabric.Razor.Models;
using ProjectFabric.Razor.Services.Interfaces;

namespace ProjectFabric.Razor.ViewModels;

public partial class RecentActivitiesViewModel(IApplicationStateService applicationStateService,
        IApplicationThemeService applicationThemeService, NavigationManager navigationManager)
    : ViewModelBase(applicationStateService, applicationThemeService, navigationManager)
{
    [ObservableProperty] private Theme _theme;

    public override Task OnInitializedAsync()
    {
        if (ApplicationStateService.State == null)
            throw new Exception("State is null");

        if (ApplicationThemeService.Theme == null)
            throw new Exception("Theme is null");

        Theme = ApplicationThemeService.Theme;
        Theme.PropertyChanged += Theme_PropertyChanged;
        return Task.CompletedTask;
    }

    private void Theme_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        NotifyStateChanged();
    }

    [RelayCommand]
    public void GetStarted()
    {
        navigationManager.NavigateTo("./registration");
    }
}