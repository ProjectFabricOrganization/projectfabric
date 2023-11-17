using System.ComponentModel;

namespace ProjectFabric.Razor.ViewModels;

public interface IViewModelBase : INotifyPropertyChanged
{
    Task OnInitializedAsync();
    Task Loaded();
}