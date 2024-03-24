using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using PortfolioAPI.Models;

public class GithubService
{
    private readonly HttpClient _httpClient;

    public GithubService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://api.github.com/");
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "PortfolioApp");
    }

    public async Task<GitHubUser> GetGithubUserData(string username)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"users/{username}");

        if (response.IsSuccessStatusCode)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();
            GitHubUser gitHubUser = JsonSerializer.Deserialize<GitHubUser>(jsonResponse);
            return gitHubUser;
        }
        else
        {
            throw new HttpRequestException($"Failed to fetch user data. Status code: {response.StatusCode}");
        }
    }
}