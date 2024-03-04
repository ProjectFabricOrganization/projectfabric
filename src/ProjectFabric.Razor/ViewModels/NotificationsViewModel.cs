using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components;
using ProjectFabric.Razor.Models;
using ProjectFabric.Razor.Services.Interfaces;

namespace ProjectFabric.Razor.ViewModels;

public partial class NotificationsViewModel : ViewModelBase
{
    private readonly NavigationManager _navigationManager;

    [ObservableProperty] private Theme _theme = new();

    public NotificationsViewModel(IApplicationStateService applicationStateService,
        IApplicationThemeService applicationThemeService, NavigationManager navigationManager) : base(
        applicationStateService, applicationThemeService)
    {
        _navigationManager = navigationManager;
    }

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

    private void Theme_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        NotifyStateChanged();
    }

    [RelayCommand]
    public void Submit()
    {
        _navigationManager.NavigateTo("/");
    }
}