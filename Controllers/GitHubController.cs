using GitHubApi.Models;
using GitHubApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GitHubApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GitHubController : ControllerBase
{
    private readonly IGitHubService _gitHubService;
    private readonly ILogger<GitHubController> _logger;
    
    public GitHubController(IGitHubService gitHubService, ILogger<GitHubController> logger)
    {
        _gitHubService = gitHubService;
        _logger = logger;      
    }

    [HttpGet(Name = "GetGitHubUser")]
    public async Task<GitHubUser?> GetAsync(string username)
    {
        var jsonString = await _gitHubService.GetUserAsync(username).ConfigureAwait(false);

        if (jsonString == null) return null;

        return JsonSerializer.Deserialize<GitHubUser>(jsonString);       
    }
}
