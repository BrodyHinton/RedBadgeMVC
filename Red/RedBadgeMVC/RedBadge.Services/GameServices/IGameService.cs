using RedBadge.Models.GameModels;

namespace RedBadge.Services.GameServices
{
    public interface IGameService
    {
        Task<bool> CreateGameAsync(GameCreate request);
        Task<IEnumerable<GameListItem>> GetAllGamesAsync();
        Task<GameDetail> GetGameByIdAsync(int Id);
        Task<bool> UpdateGameAsync(GameUpdate request);
        Task<bool> DeleteGameAsync(int Id);
    }
}