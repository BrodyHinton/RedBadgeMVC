using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RedBadge.Data.Context;
using RedBadge.Data.Entities;
using RedBadge.Models.GameModels;

namespace RedBadge.Services.GameServices
{
    public class GameService : IGameService
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;
        
        public GameService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateGameAsync(GameCreate request)
        {
            var game = new Game
            {
                Date = request.Date,
                LeagueName = request.LeagueName,
                HomeTeamId = request.HomeTeamId,
                AwayTeamId = request.AwayTeamId
            };

            _context.Add(game);

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<GameListItem>> GetAllGamesAsync()
        {
             var games = await _context.Games
                .Select(entity => new GameListItem
                    {
                        Id = entity.Id,
                        Date = entity.Date,
                        LeagueName = entity.LeagueName,
                        HomeTeamId = entity.HomeTeamId,
                        AwayTeamId = entity.AwayTeamId,
                        HomeTeamScore = entity.HomeTeamScore,
                        AwayTeamScore = entity.AwayTeamScore,
                        HighlightLink = entity.HighlightLink,
                        HomeTeamVotes = entity.HomeTeamVotes,
                        AwayTeamVotes = entity.AwayTeamVotes
                    })
                    .ToListAsync();

            return games;
        }

        public async Task<GameDetail?> GetGameByIdAsync(int Id)
        {
            var game = await _context.Games.FirstOrDefaultAsync(e =>
                e.Id == Id);
                return game is null ? null : new GameDetail
                    {
                        Id = game.Id,
                        Date = game.Date,
                        LeagueName = game.LeagueName,
                        HomeTeamId = game.HomeTeamId,
                        AwayTeamId = game.AwayTeamId,
                        HomeTeamScore = game.HomeTeamScore,
                        AwayTeamScore = game.AwayTeamScore,
                        HighlightLink = game.HighlightLink
                    };
        }

        public async Task<bool> UpdateGameAsync(GameUpdate request)
        {
            var game = await _context.Games.FindAsync(request.Id);
            
            game.Date = request.Date;
            game.LeagueName = request.LeagueName;
            game.HomeTeamId = request.HomeTeamId;
            game.AwayTeamId = request.AwayTeamId;
            game.HomeTeamScore = request.HomeTeamScore;
            game.AwayTeamScore = request.AwayTeamScore;
            game.HighlightLink = request.HighlightLink;

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteGameAsync(int Id)
        {
            var game = await _context.Games.FindAsync(Id);
            if (game is null)
                return false;
            _context.Games.Remove(game);
            var numberOfChanges = await _context.SaveChangesAsync();
            return (numberOfChanges == 1);
        }
    }
}