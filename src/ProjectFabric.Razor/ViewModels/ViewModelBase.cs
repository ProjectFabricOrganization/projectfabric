using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ProjectFabric.Razor.ViewModels;

public abstract partial class ViewModelBase : ObservableObject, IViewModelBase
{
    protected virtual void NotifyStateChanged() => OnPropertyChanged(default(string));

    public virtual async Task OnInitializedAsync()
    {
        await Loaded().ConfigureAwait(true);
    }

    [RelayCommand]
    public virtual async Task Loaded()
    {
        await Task.CompletedTask.ConfigureAwait(true);
    }
}