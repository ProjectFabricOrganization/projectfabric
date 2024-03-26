using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;
using ProjectFabric.Razor.ViewModels;

namespace ProjectFabric.Razor;

public abstract class MvvmComponentBase<TViewModel> : ComponentBase where TViewModel : ViewModelBase
{
    [Inject]
    [NotNull]
#pragma warning disable CSB618
    protected TViewModel ViewModel { get; set; }
#pragma warning restore CSB618

    protected override void OnInitialized()
    {
        ViewModel.PropertyChanged += (_, _) => StateHasChanged();
        base.OnInitialized();
    }

    protected override Task OnInitializedAsync()
    {
        return ViewModel.OnInitializedAsync();
    }
}