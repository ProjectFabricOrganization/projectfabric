using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components;
using ProjectFabric.Razor.Services.Interfaces;

namespace ProjectFabric.Razor.ViewModels;

public partial class LoginViewModel : ViewModelBase
{
    [ObservableProperty] private string? _email;

    [ObservableProperty] private string? _password;

    public LoginViewModel(IApplicationStateService applicationStateService,
        IApplicationThemeService applicationThemeService, NavigationManager navigationManager) : base(
        applicationStateService, applicationThemeService, navigationManager)
    {
    }

    [RelayCommand]
    public void Submit()
    {
        NavigationManager.NavigateTo("./registration");
    }


    partial void OnEmailChanging(string? value)
    {
        Console.WriteLine($"Name is about to change to {value}");
    }

    partial void OnEmailChanged(string? value)
    {
        Console.WriteLine($"Name has changed to {value}");
    }

    partial void OnPasswordChanging(string? value)
    {
        Console.WriteLine($"Password is about to change to {value}");
    }

    partial void OnPasswordChanged(string? value)
    {
        Console.WriteLine($"Password has changed to {value}");
    }
}