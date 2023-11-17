using ProjectFabric.Razor.Models;
using ProjectFabric.Razor.Services.Interfaces;

namespace ProjectFabric.Razor.Services.Implementations;

public class ApplicationThemeService : IApplicationThemeService
{
    private readonly Dictionary<string, Theme> _themes = new()
    {
        {
            "addinol reseller", new Theme
            {
                Organization = "Carmarket",
                Logo = "images/logo.svg",
                Styles = new Dictionary<string, string>
                {
                    { "bg", "bg-white dark:bg-gray-900" }
                },
                Dark = "dark",
                Tenant = "dev",
                Content = "",
                Footer = "",
                NavItems = new List<NavItem>(new[]
                {
                    new NavItem { Name = "Home", Link = "/" },
                    new NavItem { Name = "Pricing", Link = "/pricing" },
                    new NavItem { Name = "About", Link = "/about" },
                    new NavItem { Name = "Join", Link = "/join" }
                })
            }
        },
        { "game portal", new Theme() }
    };

    public Task<Theme> Load(string organizationId)
    {
        if (_themes.TryGetValue(organizationId, out var theme)) return Task.FromResult(theme);

        // default theme
        //var theme = new Theme
        //{
        //    LogoImg = "images/document-svgrepo-com.svg",
        //    Dashboard = "Dashboard",
        //    Team = "Teams",
        //    Projects = "Games",
        //    CartImg = "images/pie-chart-svgrepo-com.svg",
        //    AvatarImg = "images/cell-phone-svgrepo-com.svg",
        //    ThemeImg = "images/creativity-svgrepo-com.svg",
        //    HeadMessage = "The unique games portal",
        //    DetailsMessage = "Free games, teams and servers",
        //    ButtonText = "Join",
        //    MainColor = "bg-fuchsia-100"
        //};

        //return theme;

        throw new Exception($"Unknown {nameof(organizationId)}: {organizationId}");
    }

    public Task<Theme> Generate()
    {
        //var theme = new Theme
        //{
        //    LogoImg = "images/document-svgrepo-com.svg",

        //    Dashboard = "Pes",
        //    Team = "Kot",
        //    Projects = "Ezik",

        //    CartImg = "images/pie-chart-svgrepo-com.svg",
        //    AvatarImg = "images/cell-phone-svgrepo-com.svg",
        //    ThemeImg = "images/creativity-svgrepo-com.svg",

        //    HeadMessage = "Family",
        //    DetailsMessage = "Forever",
        //    ButtonText = "Join",

        //    MainColor = "bg-[#FBFBFB]"
        //};

        //return theme;

        return Task.FromResult(new Theme());
    }
}