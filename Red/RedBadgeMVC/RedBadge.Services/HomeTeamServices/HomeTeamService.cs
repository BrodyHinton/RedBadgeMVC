using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RedBadge.Data.Context;
using RedBadge.Data.Entities;
using RedBadge.Models.HomeTeamModels;

namespace RedBadge.Services.HomeTeamServices
{
    public class HomeTeamService : IHomeTeamService
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;
        
        public HomeTeamService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateHomeTeamAsync(HomeTeamCreate request)
        {
            var hometeam = new HomeTeam
            {
                Name = request.Name
            };

            _context.Add(hometeam);

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }
        
        public async Task<IEnumerable<HomeTeamListItem>> GetAllHomeTeamsAsync()
        {
             var hometeams = await _context.HomeTeams
                .Select(entity => new HomeTeamListItem
                    {
                        Id = entity.Id,
                        Name = entity.Name
                    })
                    .ToListAsync();

            return hometeams;
        }

        public async Task<HomeTeamDetail?> GetHomeTeamByIdAsync(int Id)
        {
            var hometeam = await _context.HomeTeams.FirstOrDefaultAsync(e =>
                e.Id == Id);
                return hometeam is null ? null : new HomeTeamDetail
                    {
                        Id = hometeam.Id,
                        Name = hometeam.Name
                    };
        }

        public async Task<bool> UpdateHomeTeamAsync(HomeTeamUpdate request)
        {
            var hometeam = await _context.HomeTeams.FindAsync(request.Id);
            
            hometeam.Name = request.Name;

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteHomeTeamAsync(int Id)
        {
            var hometeam = await _context.HomeTeams.FindAsync(Id);
            if (hometeam is null)
                return false;
            _context.HomeTeams.Remove(hometeam);
            var numberOfChanges = await _context.SaveChangesAsync();
            return (numberOfChanges == 1);
        }
    }
}