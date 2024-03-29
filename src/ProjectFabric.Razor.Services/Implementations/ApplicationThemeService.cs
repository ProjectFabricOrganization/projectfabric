﻿using System.Collections.ObjectModel;
using Blazored.LocalStorage;
using ProjectFabric.Razor.Models;
using ProjectFabric.Razor.Services.Interfaces;

namespace ProjectFabric.Razor.Services.Implementations;

public class ApplicationThemeService : IApplicationThemeService
{
    private const string OrganizationId = "organizationId";
    private const string DarkMode = "darkMode";

    private readonly ISyncLocalStorageService _localStorage;

    private readonly Dictionary<string, Theme> _themes = new()
    {
        {
            "Enterprise Automation System", new Theme
            {
                Organization = "Enterprise Automation System",
                Logo = "images/simple-logo.svg",
                Dark = "dark",
                NavItems = new ObservableCollection<NavItem>(new[]
                {
                    new NavItem { Name = "Home", Link = "./" },
                    new NavItem { Name = "Pricing", Link = "./pricing" },
                    new NavItem { Name = "About", Link = "./about" }
                }),
                AdminTheme = new AdminTheme
                {
                    NavMenuItems = new ObservableCollection<NavItem>(new[]
                    {
                        new NavItem() { Name = "Dashboard", Link = "./admin/dashboard" },
                        new NavItem() { Name = "Products", Link = "./products" },
                        new NavItem() { Name = "Services", Link = "./services" },
                        new NavItem() { Name = "Features", Link = "./features" },
                        new NavItem() { Name = "Analytics", Link = "./analytics" }
                    }),
                    SidebarMainItems = new ObservableCollection<NavItem>(new[]
                    {
                        new NavItem
                        {
                            Icon = "images/dashboard.svg", Name = "Dashboard", Link = "./admin/dashboard",
                            Notification = "Up"
                        },
                        new NavItem
                        {
                            Icon = "images/business-card.svg", Name = "Social Traffic", Link = "./admin/social-traffic",
                            Notification = "New"
                        },
                        new NavItem
                        {
                            Icon = "images/star.svg", Name = "Recent Activities",
                            Link = "./admin/recent-activities", Notification = "17"
                        },
                        new NavItem
                        {
                            Icon = "images/briefcase.svg", Name = "Clients",
                            Link = "./admin/clients", Notification = "+27"
                        },
                        new NavItem
                        {
                            Icon = "images/notifications.svg", Name = "Notifications",
                            Link = "./admin/notifications", Notification = "1.2k"
                        }
                    }),
                    SidebarSettingsItems = new ObservableCollection<NavItem>(new[]
                    {
                        new NavItem { Icon = "images/key.svg", Name = "Account", Link = "./profile" },
                        new NavItem { Icon = "images/settings.svg", Name = "Settings", Link = "./settings" },
                    }),
                    StatisticCards = new ObservableCollection<StatisticCard>(new[]
                    {
                        new StatisticCard
                            { Icon = "images/eye.svg", MetricName = "Visitors", MetricValue = "1,257" },
                        new StatisticCard { Icon = "images/order.svg", MetricName = "Orders", MetricValue = "557" },
                        new StatisticCard
                            { Icon = "images/sale.svg", MetricName = "Sales", MetricValue = "$11,257" },
                        new StatisticCard
                            { Icon = "images/wallet.svg", MetricName = "Wallet", MetricValue = "$75,257" }
                    })
                }
            }
        },
        {
            "IT Engineer Portfolio", new Theme
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
                AdminTheme = new AdminTheme
                {
                    NavMenuItems = new ObservableCollection<NavItem>(new[]
                    {
                        new NavItem() { Name = "Projects", Link = "./projects" },
                        new NavItem() { Name = "Accounts", Link = "./accounts" },
                        new NavItem() { Name = "Domains", Link = "./domains" },
                        new NavItem() { Name = "Achievements", Link = "./achievements" }
                    }),
                    SidebarMainItems = new ObservableCollection<NavItem>(new[]
                    {
                        new NavItem
                        {
                            Icon = "images/dashboard.svg", Name = "Dashboard", Link = "./admin/dashboard",
                            Notification = "Up"
                        },
                        new NavItem
                        {
                            Icon = "images/business-card.svg", Name = "Social Traffic", Link = "./admin/social-traffic",
                            Notification = "New"
                        },
                        new NavItem
                        {
                            Icon = "images/star.svg", Name = "Recent Activities",
                            Link = "./admin/recent-activities", Notification = "7"
                        },
                        new NavItem
                        {
                            Icon = "images/briefcase.svg", Name = "Clients",
                            Link = "./admin/clients", Notification = "+2"
                        },
                        new NavItem
                        {
                            Icon = "images/notifications.svg", Name = "Notifications",
                            Link = "./admin/notifications", Notification = "3"
                        }
                    }),
                    SidebarSettingsItems = new ObservableCollection<NavItem>(new[]
                    {
                        new NavItem { Icon = "images/key.svg", Name = "Account", Link = "./profile" },
                        new NavItem { Icon = "images/settings.svg", Name = "Settings", Link = "./settings" },
                    })
                }
            }
        }
    };
    
    public ApplicationThemeService(ISyncLocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }
    
    public Theme? FindTheme(string organizationId)
    {
        return _themes.TryGetValue(organizationId, out var theme) ? theme : null;
    }

    public void DarkModeSwitch(Theme theme)
    {
        theme.Dark = string.IsNullOrWhiteSpace(theme.Dark) ? "dark" : null;

        Console.WriteLine($"Organization theme changed. OrganizationName: {theme.Organization}. DarkMode: {theme.Dark == "dark"}");
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