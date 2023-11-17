namespace ProjectFabric.Models;

public class Organization
{
    public Organization(string name, string logo)
    {
        Name = name;
        Logo = logo;
    }

    public string Name { get; set; }

    public string Logo { get; set; }
}