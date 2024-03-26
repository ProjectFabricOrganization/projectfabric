﻿using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components;
using ProjectFabric.Razor.Services.Interfaces;

namespace ProjectFabric.Razor.ViewModels;

public partial class NotificationsViewModel : ViewModelBase
{
    public NotificationsViewModel(IApplicationStateService applicationStateService,
        IApplicationThemeService applicationThemeService, NavigationManager navigationManager) : base(
        applicationStateService, applicationThemeService, navigationManager)
    {
    }


    [RelayCommand]
    public void Submit()
    {
        NavigationManager.NavigateTo("./registration");
    }
}