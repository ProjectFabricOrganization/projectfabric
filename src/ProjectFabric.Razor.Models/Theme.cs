using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjectFabric.Razor.Models;

public partial class Theme : ObservableObject
{
    [ObservableProperty] private string _organization;
    [ObservableProperty] private string _logo;
    [ObservableProperty] private ObservableCollection<NavItem> _navItems;
    [ObservableProperty] private string _dark;
    [ObservableProperty] private AdminTheme _adminTheme;
}