using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components;
using ProjectFabric.Razor.Services.Interfaces;

namespace ProjectFabric.Razor.ViewModels;

public partial class SettingsViewModel : ViewModelBase
{
    public SettingsViewModel(IApplicationStateService applicationStateService,
        IApplicationThemeService applicationThemeService, NavigationManager navigationManager) : base(
        applicationStateService, applicationThemeService, navigationManager)
    {
    }

    [RelayCommand]
    public void Submit()
    {
        NavigationManager.NavigateTo("/");
    }
}