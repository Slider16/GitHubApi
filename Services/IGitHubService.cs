namespace GitHubApi.Services
{
    public interface IGitHubService
    {
       
        Task<string> GetUserAsync(string username);

    }
}
