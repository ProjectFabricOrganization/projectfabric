using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components;
using ProjectFabric.Razor.Models;
using ProjectFabric.Razor.Services.Interfaces;

namespace ProjectFabric.Razor.ViewModels;

public partial class WallPaperViewModel(IApplicationStateService applicationStateService,
        IApplicationThemeService applicationThemeService, NavigationManager navigationManager)
    : ViewModelBase(applicationStateService, applicationThemeService)
{
    [ObservableProperty] private Theme _theme = new();
    [ObservableProperty] private string _startUsingText;
    [ObservableProperty] private string _joinText;
    [ObservableProperty] private string _subscribeText;

    public override Task OnInitializedAsync()
    {
        if (ApplicationStateService.State == null)
            throw new Exception("State is null");

        if (ApplicationThemeService.Theme == null)
            throw new Exception("Theme is null");

        Theme = ApplicationThemeService.Theme;

        Theme.PropertyChanged += Theme_PropertyChanged;

        StartUsingText = "Start using for free";
        JoinText = "Join";
        SubscribeText = "Subscribe";

        return Task.CompletedTask;
    }

    private void Theme_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        NotifyStateChanged();
    }

    [RelayCommand]
    public void StartUsing()
    {
        navigationManager.NavigateTo("registration");
    }

    [RelayCommand]
    public void Join()
    {
        navigationManager.NavigateTo("registration");
    }

    [RelayCommand]
    public void Subscribe()
    {
        navigationManager.NavigateTo("registration");
    }

    [RelayCommand]
    public void Submit(string par)
    {
        navigationManager.NavigateTo("registration");
    }
}