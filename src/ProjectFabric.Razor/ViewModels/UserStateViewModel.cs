using Blazored.LocalStorage;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components;
using ProjectFabric.Razor.Services.Interfaces;

namespace ProjectFabric.Razor.ViewModels;

public partial class UserStateViewModel(IApplicationStateService applicationStateService,
    IApplicationThemeService applicationThemeService, NavigationManager navigationManager, ILocalStorageService localStorageService) : ViewModelBase(
    applicationStateService, applicationThemeService, navigationManager)
{
    public ILocalStorageService LocalStorageService { get; } = localStorageService;

    public bool IsDark { get; set; }

    public override async Task OnInitializedAsync()
    {
        var isDark = await LocalStorageService.GetItemAsync<bool>("darkMode");
        IsDark = isDark;
    }

    [RelayCommand]
    public void GetStarted()
    {
        NavigationManager.NavigateTo("./registration");
    }

    [RelayCommand]
    public void ChangeTheme()
    {
        ApplicationThemeService.ChangeTheme("Enterprise Automation System");
    }

    [RelayCommand]
    public void DarkMode()
    {
        var darkMode = !IsDark;

        IsDark = darkMode;
        ApplicationThemeService.DarkModeSwitch();
        localStorageService.SetItemAsync("darkMode", darkMode);
    }

    [RelayCommand]
    public void Logout()
    {
        throw new NotImplementedException();
    }

    [RelayCommand]
    public void Login()
    {
        throw new NotImplementedException();
    }

    
}