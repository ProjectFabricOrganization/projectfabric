using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ProjectFabric.Razor.ViewModels;

namespace ProjectFabric.Blazor.ViewModels;

public class IndexViewModel : ViewModelBase
{
    public string AccessToken { get; set; }
    public string Organization { get; set; }

    public ElementReference MyTarget { get; set; }

    public override Task OnInitializedAsync()
    {
        // TODO: get organization
        Organization = "Addinol Reseller";

        // TODO: get user cookie 
        AccessToken = Guid.NewGuid().ToString();

        // Log user interaction
        Console.WriteLine($"{nameof(Organization)}: {Organization}\n" +
                          $"{nameof(AccessToken)}: {AccessToken}\n");

        return base.OnInitializedAsync();
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