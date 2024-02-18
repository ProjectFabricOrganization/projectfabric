using Microsoft.JSInterop;
using ProjectFabric.Razor.Models;

namespace ProjectFabric.Blazor.Wasm.Services;

public class BrowserService
{
    private readonly IJSRuntime _jsRuntime;

    private IJSObjectReference _mainModule;
    private IJSObjectReference _dimensionModule;

    public BrowserService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task Initialize()
    {
        _mainModule = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", new[] { "./js/index.js" });
        _dimensionModule = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", new[] { "./js/window.js" });
    }

    public async Task<BrowserDimension> GetDimensions()
    {
        var dimension = await _dimensionModule.InvokeAsync<BrowserDimension>("getDimensions");
        return dimension;
    }

    public async Task ShowDimensions()
    {
        var dimension = await GetDimensions();

        await _mainModule.InvokeVoidAsync("showAlert", $"Width: {dimension.Width}. Height: {dimension.Height}");
    }
}