using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RedBadge.Data.Context;
using RedBadge.Data.Entities;
using RedBadge.Models.LeagueModels;

namespace RedBadge.Services.LeagueServices
{
    public class LeagueService : ILeagueService
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;
        
        public LeagueService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateLeagueAsync(LeagueCreate request)
        {
            var league = new League
            {
                Name = request.Name
            };

            _context.Add(league);

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<LeagueListItem>> GetAllLeaguesAsync()
        {
             var leagues = await _context.Leagues
                .Select(entity => new LeagueListItem
                    {
                        Id = entity.Id,
                        Name = entity.Name
                    })
                    .ToListAsync();

            return leagues;
        }

        public async Task<LeagueDetail?> GetLeagueByIdAsync(int Id)
        {
            var league = await _context.Leagues.FirstOrDefaultAsync(e =>
                e.Id == Id);
                return league is null ? null : new LeagueDetail
                    {
                        Id = league.Id,
                        Name = league.Name
                    };
        }

        public async Task<bool> UpdateLeagueAsync(LeagueUpdate request)
        {
            var league = await _context.Leagues.FindAsync(request.Id);
            
            league.Name = request.Name;

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteLeagueAsync(int Id)
        {
            var league = await _context.Leagues.FindAsync(Id);
            if (league is null)
                return false;
            _context.Leagues.Remove(league);
            var numberOfChanges = await _context.SaveChangesAsync();
            return (numberOfChanges == 1);
        }
    }
}