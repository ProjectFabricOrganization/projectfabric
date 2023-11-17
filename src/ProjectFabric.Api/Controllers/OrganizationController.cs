using Microsoft.AspNetCore.Mvc;
using ProjectFabric.Api.Query.Company;
using ProjectFabric.Models;
using ProjectFabric.Services;

namespace ProjectFabric.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrganizationController : ControllerBase
{
    private readonly ILogger<OrganizationController> _logger;
    private readonly OrganizationService _organizationService;

    public OrganizationController(ILogger<OrganizationController> logger, OrganizationService organizationService)
    {
        _logger = logger;
        _organizationService = organizationService;
    }

    [HttpGet(Name = "generate")]
    public Organization Get([FromQuery]GenerateCompanyQuery query)
    {
        var name = query.Name;
        var domain = query.Domain;

        var organization = _organizationService.Generate(name, domain).Result;
        return organization ?? throw new Exception($"Can't generate organization with name '{name}' in domain '{domain}'");
    }
}