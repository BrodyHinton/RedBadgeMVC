using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RedBadge.Data.Context;
using RedBadge.Data.Entities;
using RedBadge.Models.PlayerModels;

namespace RedBadge.Services.PlayerServices
{
    public class PlayerService : IPlayerService
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;
        
        public PlayerService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreatePlayerAsync(PlayerCreate request)
        {
            var player = new Player
            {
                Name = request.Name,
                Championships = request.Championships,
                TeamId = request.TeamId
            };

            _context.Add(player);

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<PlayerListItem>> GetAllPlayersAsync()
        {
             var players = await _context.Players
                .Select(entity => new PlayerListItem
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Fans = entity.Fans,
                        Championships = entity.Championships,
                        TeamId = entity.TeamId
                    })
                    .ToListAsync();

            return players;
        }

        public async Task<PlayerDetail?> GetPlayerByIdAsync(int Id)
        {
            var player = await _context.Players.FirstOrDefaultAsync(e =>
                e.Id == Id);
                return player is null ? null : new PlayerDetail
                    {
                        Id = player.Id,
                        Name = player.Name,
                        TeamId = player.TeamId,
                        Championships = player.Championships
                    };
        }

        public async Task<bool> UpdatePlayerAsync(PlayerUpdate request)
        {
            var player = await _context.Players.FindAsync(request.Id);
            
            player.Name = request.Name;
            player.TeamId = request.TeamId;
            player.Championships = request.Championships;

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeletePlayerAsync(int Id)
        {
            var player = await _context.Players.FindAsync(Id);
            if (player is null)
                return false;
            _context.Players.Remove(player);
            var numberOfChanges = await _context.SaveChangesAsync();
            return (numberOfChanges == 1);
        }
    }
}