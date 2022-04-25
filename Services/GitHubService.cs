namespace GitHubApi.Services
{
    public class GitHubService : IGitHubService
    {
        private readonly ILogger<GitHubService> _logger;
        private readonly HttpClient _httpClient;

        public GitHubService(HttpClient httpClient, ILogger<GitHubService> logger)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<string> GetUserAsync(string username)
        {
            var response = await _httpClient.GetAsync("/users/Slider16").ConfigureAwait(false);

            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
