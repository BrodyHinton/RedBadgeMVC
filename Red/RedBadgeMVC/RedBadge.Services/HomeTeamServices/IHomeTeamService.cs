using RedBadge.Models.HomeTeamModels;

namespace RedBadge.Services.HomeTeamServices
{
    public interface IHomeTeamService
    {
        Task<bool> CreateHomeTeamAsync(HomeTeamCreate request); 
        Task<IEnumerable<HomeTeamListItem>> GetAllHomeTeamsAsync();
        Task<HomeTeamDetail> GetHomeTeamByIdAsync(int Id);
        Task<bool> UpdateHomeTeamAsync(HomeTeamUpdate request);
        Task<bool> DeleteHomeTeamAsync(int Id);
    }
}