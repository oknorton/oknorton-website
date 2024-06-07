using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using PortfolioAPI.Models;
using Xunit;
using System.Text.Json;
public class IntegrationTests : IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly GithubService _githubService;

    public IntegrationTests()
    {
        _httpClient = new HttpClient();
        _githubService = new GithubService(_httpClient);
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
    [Fact]
    public async Task GithubApi_IsActive()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Get, "rate_limit");

        // Act
        var response = await _httpClient.SendAsync(request);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task GetGithubUserData_ValidUsername_ReturnsUserData()
    {
        // Arrange
        string username = "oknorton";

        // Act
        GitHubUser gitHubUser = await _githubService.GetGithubUserData(username);

        // Assert
        Assert.NotNull(gitHubUser); 
        Assert.Equal(username, gitHubUser.Login);
    }

    [Fact]
    public async Task GetGithubUserData_InvalidUsername_ThrowsException()
    {
        // Arrange
        string username = "invalidusername10101010101010101010101013333333";

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(async () => await _githubService.GetGithubUserData(username));
    }
    
}