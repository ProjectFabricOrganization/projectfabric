using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjectFabric.Razor.Models;

public partial class Feature : ObservableObject
{
    [ObservableProperty] private string _actionText;
    [ObservableProperty] private string _description;
    [ObservableProperty] private string _name;
}