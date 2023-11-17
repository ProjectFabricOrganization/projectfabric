using ProjectFabric.Services;

namespace ProjectFabric.Tests;

public class ShowMainScreenTest
{
    public ShowMainScreenTest()
    {
    }

    [Theory]
    [InlineData("Adinol", "Oil")]
    public void GenerateMainScreen(string name, string domain)
    {
        // Arrange all clients
        // TODO: open browser, mobile, desktop UI clients
        var organizationService = new OrganizationService();

        // Act main screen logic
        // TODO: show main screen
        var organization = organizationService.Generate(name, domain).Result;
        
        // Assert main screen action
        Assert.NotNull(organization);
    }
}