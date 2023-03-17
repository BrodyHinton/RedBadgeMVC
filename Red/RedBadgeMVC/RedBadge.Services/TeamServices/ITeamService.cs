using RedBadge.Models.TeamModels;

namespace RedBadge.Services.TeamServices
{
    public interface ITeamService
    {
        Task<bool> CreateTeamAsync(TeamCreate request);
        Task<IEnumerable<TeamListItem>> GetAllTeamsAsync();
        Task<TeamDetail> GetTeamByIdAsync(int Id);
        Task<bool> UpdateTeamAsync(TeamUpdate request);
        Task<bool> DeleteTeamAsync(int Id);
    }
}