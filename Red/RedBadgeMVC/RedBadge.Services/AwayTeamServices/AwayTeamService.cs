using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RedBadge.Data.Context;
using RedBadge.Data.Entities;
using RedBadge.Models.AwayTeamModels;

namespace RedBadge.Services.AwayTeamServices
{
    public class AwayTeamService : IAwayTeamService
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;
        
        public AwayTeamService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateAwayTeamAsync(AwayTeamCreate request)
        {
            var awayteam = new AwayTeam
            {
                Name = request.Name
            };

            _context.Add(awayteam);

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<AwayTeamListItem>> GetAllAwayTeamsAsync()
        {
             var awayteams = await _context.AwayTeams
                .Select(entity => new AwayTeamListItem
                    {
                        Id = entity.Id,
                        Name = entity.Name
                    })
                    .ToListAsync();

            return awayteams;
        }

        public async Task<AwayTeamDetail?> GetAwayTeamByIdAsync(int Id)
        {
            var awayteam = await _context.AwayTeams.FirstOrDefaultAsync(e =>
                e.Id == Id);
                return awayteam is null ? null : new AwayTeamDetail
                    {
                        Id = awayteam.Id,
                        Name = awayteam.Name
                    };
        }

        public async Task<bool> UpdateAwayTeamAsync(AwayTeamUpdate request)
        {
            var awayteam = await _context.AwayTeams.FindAsync(request.Id);
            
            awayteam.Name = request.Name;

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteAwayTeamAsync(int Id)
        {
            var awayteam = await _context.AwayTeams.FindAsync(Id);
            if (awayteam is null)
                return false;
            _context.AwayTeams.Remove(awayteam);
            var numberOfChanges = await _context.SaveChangesAsync();
            return (numberOfChanges == 1);
        }
    }
}