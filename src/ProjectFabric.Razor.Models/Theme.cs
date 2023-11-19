using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjectFabric.Razor.Models;

public partial class Theme : ObservableObject
{
    [ObservableProperty] private string _organization;
    [ObservableProperty] private string _tenant;
    [ObservableProperty] private Dictionary<string, string> _styles;
    [ObservableProperty] private string _logo;
    [ObservableProperty] private ObservableCollection<NavItem> _navItems;
    [ObservableProperty] private string _dark;
    [ObservableProperty] private string _content;
    [ObservableProperty] private string _footer;
}