using RedBadge.Models.AwayTeamModels;

namespace RedBadge.Services.AwayTeamServices
{
    public interface IAwayTeamService
    {
        Task<bool> CreateAwayTeamAsync(AwayTeamCreate request); 
        Task<IEnumerable<AwayTeamListItem>> GetAllAwayTeamsAsync();
        Task<AwayTeamDetail> GetAwayTeamByIdAsync(int Id);
        Task<bool> UpdateAwayTeamAsync(AwayTeamUpdate request);
        Task<bool> DeleteAwayTeamAsync(int Id);
    }
}