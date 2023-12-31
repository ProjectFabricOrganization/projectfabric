﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectFabric.Razor.Services.Interfaces;

namespace ProjectFabric.Razor.ViewModels;

public abstract partial class ViewModelBase : ObservableObject, IViewModelBase
{
    protected readonly IApplicationStateService ApplicationStateService;
    protected readonly IApplicationThemeService ApplicationThemeService;

    protected ViewModelBase(IApplicationStateService applicationStateService, IApplicationThemeService applicationThemeService)
    {
        ApplicationStateService = applicationStateService;
        ApplicationThemeService = applicationThemeService;
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

}