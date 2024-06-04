using Microsoft.AspNetCore.Mvc;
using PortfolioAPI.Models;
//Author: Oliver Norton

namespace PortfolioAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class GithubController : ControllerBase
{
    private readonly GithubService _gitHubService;

    public GithubController(GithubService gitHubService)
    {
        _gitHubService = gitHubService;
    }

    [HttpGet("{username}")]
    public async Task<ActionResult<int>> GetUserData(string username)
    {
        try
        {
            var userdata = await _gitHubService.GetGithubUserData(username);
            return Ok(userdata);
        }
        catch (HttpRequestException)
        {
            return StatusCode(500, "Error retrieving GitHub statistics.");
        }
    }
}