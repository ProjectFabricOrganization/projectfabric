using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace ProjectFabric.Razor.ViewModels;

public abstract partial class RecipientViewModelBase<TMessage> : ObservableRecipient, 
    IViewModelBase,
    IRecipient<TMessage>
    where TMessage : class
{
    public virtual async Task OnInitializedAsync()
    {
        await Loaded().ConfigureAwait(true);
    }

    [RelayCommand]
    public virtual async Task Loaded()
    {
        await Task.CompletedTask.ConfigureAwait(false);
    }
    
    protected virtual void NotifyStateChanged()
    {
        OnPropertyChanged(default(string));
    }

    public abstract void Receive(TMessage message);
}