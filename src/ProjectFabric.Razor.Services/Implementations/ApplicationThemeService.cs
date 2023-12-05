using System.Collections.ObjectModel;
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
                Organization = "Addinol Reseller",
                OrganizationDetails = "We are provide AI-generated business digital maintenance in seconds",
                Logo = "images/logo.svg",
                //Styles = new Dictionary<string, string>
                //{
                //    { "bg", "bg-white dark:bg-gray-900 text-black dark:text-white" },
                //    { "logo", "bg-white dark:bg-yellow-400" },
                //    { "text", "text-neutral-600 dark:text-white" }
                //},
                Dark = "dark",
                Tenant = "dev",
                NavItems = new ObservableCollection<NavItem>(new[]
                {
                    new NavItem { Name = "Home", Link = "./" },
                    new NavItem { Name = "Pricing", Link = "./pricing" },
                    new NavItem { Name = "About", Link = "./about" }
                }),

            }
        },
        { "game portal", new Theme() }
    };

    public Theme Theme { get; private set; }

    public Task<Theme> Load(string organizationId)
    {
        if (_themes.TryGetValue(organizationId, out var theme))
        {
            Theme = theme;
            return Task.FromResult(theme);
        }

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