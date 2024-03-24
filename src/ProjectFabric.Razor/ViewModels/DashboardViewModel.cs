using Microsoft.AspNetCore.Components;
using ProjectFabric.Razor.Services.Interfaces;

namespace ProjectFabric.Razor.ViewModels;

public partial class DashboardViewModel(IApplicationStateService applicationStateService,
        IApplicationThemeService applicationThemeService, NavigationManager navigationManager)
    : ViewModelBase(applicationStateService, applicationThemeService, navigationManager)
{
}