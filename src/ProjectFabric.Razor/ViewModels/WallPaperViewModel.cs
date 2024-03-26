using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components;
using ProjectFabric.Razor.Services.Interfaces;

namespace ProjectFabric.Razor.ViewModels;

public partial class WallPaperViewModel(IApplicationStateService applicationStateService,
        IApplicationThemeService applicationThemeService, NavigationManager navigationManager)
    : ViewModelBase(applicationStateService, applicationThemeService, navigationManager)
{
    [ObservableProperty] private string _joinText;
    [ObservableProperty] private string _startUsingText;
    [ObservableProperty] private string _subscribeText;

    public override Task OnInitializedAsync()
    {
        StartUsingText = "Start using for free";
        JoinText = "Join";
        SubscribeText = "Subscribe";

        return Task.CompletedTask;
    }

    [RelayCommand]
    public void StartUsing()
    {
        navigationManager.NavigateTo("registration");
    }

    [RelayCommand]
    public void Join()
    {
        Console.WriteLine("Joined");
    }

    [RelayCommand]
    public void Subscribe()
    {
        Console.WriteLine("Subscribed");
    }

    [RelayCommand]
    public void Submit(string par)
    {
        Console.WriteLine("Submitted");
    }
}