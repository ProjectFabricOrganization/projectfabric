using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjectFabric.Razor.Models;

public partial class StatisticCard : ObservableObject
{
    [ObservableProperty] private string _icon;
    [ObservableProperty] private string _metricName;
    [ObservableProperty] private string _metricValue;
}