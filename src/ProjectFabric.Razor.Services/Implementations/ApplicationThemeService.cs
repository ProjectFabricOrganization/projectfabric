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
                Logo = "images/logo.svg",
                Dark = "dark",
                NavItems = new ObservableCollection<NavItem>(new[]
                {
                    new NavItem { Name = "Home", Link = "./" },
                    new NavItem { Name = "Pricing", Link = "./pricing" },
                    new NavItem { Name = "About", Link = "./about" }
                }),

            }
        },
        {
            "portfolio", new Theme
            {
                Organization = "IT Engineer Portfolio",
                Logo = "images/rocket.svg",
                Dark = null,
                NavItems = new ObservableCollection<NavItem>(new[]
                {
                    new NavItem { Name = "About me", Link = "./" },
                    new NavItem { Name = "Technical skills", Link = "./pricing" },
                    new NavItem { Name = "Portfolio", Link = "./about" },
                    new NavItem { Name = "CV", Link = "./about" }
                }),

            }
        },
    };

    public Theme Theme { get; private set; }

    public void Load(string organizationId)
    {
        if (!_themes.TryGetValue(organizationId, out var theme))
            throw new Exception($"Load theme. Unknown {nameof(organizationId)}: {organizationId}");

        Theme = theme;
    }

    public void DarkMode(bool isDark)
    {
        Theme.Dark = isDark ? "dark" : null;
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