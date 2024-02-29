using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace ProjectFabric.Razor.Models;

public partial class AdminTheme : ObservableObject
{
    [ObservableProperty] private ObservableCollection<NavItem> _sidebarMainItems;
    [ObservableProperty] private ObservableCollection<NavItem> _sidebarSettingsItems;
}