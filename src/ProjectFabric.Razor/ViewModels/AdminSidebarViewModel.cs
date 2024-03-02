using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.AspNetCore.Components;
using ProjectFabric.Razor.Models;
using ProjectFabric.Razor.Services.Interfaces;
using System.ComponentModel;

namespace ProjectFabric.Razor.ViewModels;

public partial class AdminSidebarViewModel(IApplicationStateService applicationStateService,
        IApplicationThemeService applicationThemeService, NavigationManager navigationManager)
    : ViewModelBase(applicationStateService, applicationThemeService)
{
    [ObservableProperty] private Theme theme;

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


    //[RelayCommand]
    //public void ShowDashboard()
    //{
    //    navigationManager.NavigateTo("./admin");
    //}

    //[RelayCommand]
    //public void ShowSocialTraffic()
    //{
    //    navigationManager.NavigateTo("./social-traffic");
    //}

    //[RelayCommand]
    //public void ShowRecentActivities()
    //{
    //    navigationManager.NavigateTo("./recent-activities");
    //}
}