using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components;
using ProjectFabric.Razor.Models;
using ProjectFabric.Razor.Services.Interfaces;

namespace ProjectFabric.Razor.ViewModels;

public partial class AboutViewModel : ViewModelBase
{
    public AboutViewModel(IApplicationStateService applicationStateService,
        IApplicationThemeService applicationThemeService, NavigationManager navigationManager) : base(
        applicationStateService, applicationThemeService, navigationManager)
    {
    }

    [RelayCommand]
    public void GetStarted()
    {
        NavigationManager.NavigateTo("registration");
    }
}