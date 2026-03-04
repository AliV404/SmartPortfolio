using Microsoft.AspNetCore.Mvc;
using SmartPortfolio.Application.Abstractions.Services;
using SmartPortfolio.Application.DTOs;
using SmartPortfolio.Domain.Entities;

namespace SmartPortfolio.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProjectsController : Controller
{
    private readonly IPortfolioService _portfolioService;

    public ProjectsController(IPortfolioService portfolioService)
    {
        _portfolioService = portfolioService;
    }
    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<StudentDetailDto>>> Search([FromQuery] PortfolioSearchRequest request)
    {
        try
        {
            var results = await _portfolioService.GetFilteredPortfoliosAsync(request);

            return Ok(results);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}