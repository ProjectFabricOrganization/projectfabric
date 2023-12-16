using BrowserInterop.Extensions;
using BrowserInterop.Geolocation;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using ProjectFabric.Razor.ViewModels;
using ProjectFabric.Razor.Services.Interfaces;
using Microsoft.JSInterop;

namespace ProjectFabric.Blazor.Wasm.ViewModels;

public class IndexViewModel : ViewModelBase
{
    public IJSRuntime JsRuntime { get; }
    public string AccessToken { get; set; }
    public string Organization { get; set; }
    public GeolocationResult GeolocationResult { get; set; }
    public ElementReference MyTarget { get; set; }

    public IndexViewModel(IApplicationStateService applicationStateService,
        IApplicationThemeService applicationThemeService, IJSRuntime jsRuntime) : base(applicationStateService, applicationThemeService)
    {
        JsRuntime = jsRuntime;
    }

    public override async Task OnInitializedAsync()
    {
        var window = await JsRuntime.Window();
        var navigator = await window.Navigator();
        var geolocationWrapper = navigator.Geolocation;

        // get geolocation
        GeolocationResult = await geolocationWrapper.GetCurrentPosition(new PositionOptions()
        { 
            EnableHighAccuracy = true
        });

        //GeolocationResult = await geolocationWrapper.GetCurrentPosition();

        // TODO: get organization
        Organization = "Addinol Reseller";

        // TODO: get user cookie 
        AccessToken = Guid.NewGuid().ToString();

        // Log user interaction
        Console.WriteLine($"{nameof(Organization)}: {Organization}\n" +
                          $"{nameof(AccessToken)}: {AccessToken}\n" +
                          $"Latitude: {GeolocationResult.Location.Coords.Latitude}\n" +
                          $"Longitude: {GeolocationResult.Location.Coords.Longitude}\n" +
                          $"Accuracy: {GeolocationResult.Location.Coords.Accuracy}\n" +
                          $"Altitude: {GeolocationResult.Location.Coords.Altitude}\n" +
                          $"Altitude Accuracy: {GeolocationResult.Location.Coords.AltitudeAccuracy}\n" +
                          $"Heading: {GeolocationResult.Location.Coords.Heading}\n" +
                          $"Speed: {GeolocationResult.Location.Coords.Speed}\n"
        );
    }

    public void LeftClick(PointerEventArgs args)
    {
        // await JsRuntime.InvokeVoidAsync("myJsFunctions.capturePointer",
        //     myTarget, args.PointerId);
        Console.WriteLine("LeftClick");
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