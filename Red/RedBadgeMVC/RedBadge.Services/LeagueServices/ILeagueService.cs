using RedBadge.Models.LeagueModels;

namespace RedBadge.Services.LeagueServices
{
    public interface ILeagueService
    {
        Task<bool> CreateLeagueAsync(LeagueCreate request);
        Task<IEnumerable<LeagueListItem>> GetAllLeaguesAsync();
        Task<LeagueDetail> GetLeagueByIdAsync(int Id);
        Task<bool> UpdateLeagueAsync(LeagueUpdate request);
        Task<bool> DeleteLeagueAsync(int Id);
    }
}