using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RedBadge.Data.Context;
using RedBadge.Data.Entities;
using RedBadge.Models.TeamModels;

namespace RedBadge.Services.TeamServices
{
    public class TeamService : ITeamService
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;
        
        public TeamService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateTeamAsync(TeamCreate request)
        {
            var team = new Team
            {
                Name = request.Name,
                Wins = request.Wins,
                Loses = request.Loses,
                Championships = request.Championships,
                LeagueId = request.LeagueId
            };

            _context.Add(team);

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<TeamListItem>> GetAllTeamsAsync()
        {
             var teams = await _context.Teams
                .Select(entity => new TeamListItem
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Fans = entity.Fans,
                        LeagueId = entity.LeagueId,
                        Championships = entity.Championships,
                        Wins = entity.Wins,
                        Loses = entity.Loses
                    })
                    .ToListAsync();

            return teams;
        }

        public async Task<TeamDetail?> GetTeamByIdAsync(int Id)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(e =>
                e.Id == Id);
                return team is null ? null : new TeamDetail
                    {
                        Id = team.Id,
                        Name = team.Name,
                        LeagueId = team.LeagueId,
                        Wins = team.Wins,
                        Loses= team.Loses,
                        Championships = team.Championships
                    };
        }

        public async Task<bool> UpdateTeamAsync(TeamUpdate request)
        {
            var team = await _context.Teams.FindAsync(request.Id);
            
            team.Name = request.Name;
            team.LeagueId = request.LeagueId;
            team.Wins = request.Wins;
            team.Loses = request.Loses;
            team.Championships = request.Championships;

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteTeamAsync(int Id)
        {
            var team = await _context.Teams.FindAsync(Id);
            if (team is null)
                return false;
            _context.Teams.Remove(team);
            var numberOfChanges = await _context.SaveChangesAsync();
            return (numberOfChanges == 1);
        }
    }
}