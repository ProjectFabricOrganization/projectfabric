using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ProjectFabric.Blazor.Wasm.Services;
using ProjectFabric.Razor.Services.Interfaces;
using ProjectFabric.Razor.ViewModels;

namespace ProjectFabric.Blazor.Wasm.ViewModels;

public class IndexViewModel(IApplicationStateService applicationStateService,
        IApplicationThemeService applicationThemeService,
        BrowserService browserService, NavigationManager navigationManager)
    : ViewModelBase(applicationStateService, applicationThemeService, navigationManager)
{
    public string AccessToken { get; set; }
    public string Organization { get; set; }

    public ElementReference MyTarget { get; set; }

    public override Task OnInitializedAsync()
    {
        browserService.GetDimensions().ContinueWith(x =>
        {
            Console.WriteLine($"{nameof(IndexViewModel)}. Width: {x.Result.Width}. Height: {x.Result.Height}");
        });

        Console.WriteLine($"{nameof(IndexViewModel)}. {nameof(OnInitializedAsync)}");

        // TODO: get organization
        var organizationId = "Enterprise Automation System";
        Organization = organizationId;
        // TODO: get user cookie 
        AccessToken = Guid.NewGuid().ToString();

        // Log user interaction
        Console.WriteLine($"{nameof(Organization)}: {Organization}\n" +
                          $"{nameof(AccessToken)}: {AccessToken}\n");

        return base.OnInitializedAsync();
    }

    public override Task Loaded()
    {
        Console.WriteLine($"{nameof(IndexViewModel)}. {nameof(Loaded)}");
        return base.Loaded();
    }

    public void LeftClick(PointerEventArgs args)
    {
        // Get Dimensions
        browserService.GetDimensions().ContinueWith(x =>
        {
            Console.WriteLine($"{nameof(IndexViewModel)}. Width: {x.Result.Width}. Height: {x.Result.Height}");
        });
    }

    public void MouseOut()
    {
        //Console.WriteLine("MouseOut");
    }

    public void MouseOver()
    {
        // Console.WriteLine("MouseOver");
    }
}