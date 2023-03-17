using RedBadge.Models.PlayerModels;

namespace RedBadge.Services.PlayerServices
{
    public interface IPlayerService
    {
        Task<bool> CreatePlayerAsync(PlayerCreate request);
        Task<IEnumerable<PlayerListItem>> GetAllPlayersAsync();
        Task<PlayerDetail> GetPlayerByIdAsync(int Id);
        Task<bool> UpdatePlayerAsync(PlayerUpdate request);
        Task<bool> DeletePlayerAsync(int Id);
    }
}