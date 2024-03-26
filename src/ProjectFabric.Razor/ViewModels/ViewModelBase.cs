using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components;
using ProjectFabric.Razor.Models;
using ProjectFabric.Razor.Services.Interfaces;

namespace ProjectFabric.Razor.ViewModels;

public abstract partial class ViewModelBase : ObservableObject, IViewModelBase
{
    protected readonly IApplicationStateService ApplicationStateService;
    protected readonly IApplicationThemeService ApplicationThemeService;
    protected readonly NavigationManager NavigationManager;

    [ObservableProperty] private Theme _theme;
    
    protected ViewModelBase(IApplicationStateService applicationStateService, IApplicationThemeService applicationThemeService, NavigationManager navigationManager)
    {
        ApplicationStateService = applicationStateService;
        ApplicationThemeService = applicationThemeService;
        NavigationManager = navigationManager;

        var organizationId = "Enterprise Automation System";
        var theme = applicationThemeService.FindTheme(organizationId);
        if (theme == null)
        {
            Theme = applicationThemeService.Generate().Result;
        }
        else
        {
            Theme = theme;
            Theme.PropertyChanged += Theme_PropertyChanged;
        }
    }

    private void Theme_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        NotifyStateChanged();
    }

    protected virtual void NotifyStateChanged() => OnPropertyChanged(default(string));

    public virtual async Task OnInitializedAsync()
    {
        await Loaded().ConfigureAwait(true);
    }

    [RelayCommand]
    public virtual async Task Loaded()
    {
        await Task.CompletedTask.ConfigureAwait(true);
    }

    [RelayCommand]
    public void DarkModeSwitch()
    {
        ApplicationThemeService.DarkModeSwitch(_theme);
    }

}