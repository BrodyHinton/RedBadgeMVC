using RedBadge.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace RedBadge.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<HomeTeam> HomeTeams { get; set; }
        public DbSet<AwayTeam> AwayTeams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<League>().HasData(
                new League
                {
                    Id=1,
                    Name="NFL",
                },
                new League
                {
                    Id=2,
                    Name="NBA",
                },
                new League
                {
                    Id=3,
                    Name="MLB",
                },
                new League
                {
                    Id=4,
                    Name="NHL",
                }
            );

            modelBuilder.Entity<Team>().HasData(
                new Team
                {
                    Id=1,
                    Name="Arizona Cardinals",
                    LeagueId=1,
                    Wins=4,
                    Loses=13,
                    Championships=2
                },
                new Team
                {
                    Id=2,
                    Name="Atlanta Falcons",
                    LeagueId=1,
                    Wins=7,
                    Loses=10,
                    Championships=0
                },
                new Team
                {
                    Id=3,
                    Name="Baltimore Ravens",
                    LeagueId=1,
                    Wins=10,
                    Loses=7,
                    Championships=2
                },
                new Team
                {
                    Id=4,
                    Name="Buffalo Bills",
                    LeagueId=1,
                    Wins=13,
                    Loses=3,
                    Championships=2
                },
                new Team
                {
                    Id=5,
                    Name="Carolina Panthers",
                    LeagueId=1,
                    Wins=7,
                    Loses=10,
                    Championships=0
                },
                new Team
                {
                    Id=6,
                    Name="Chicago Bears",
                    LeagueId=1,
                    Wins=3,
                    Loses=14,
                    Championships=9
                },
                new Team
                {
                    Id=7,
                    Name="Cincinnati Bengals",
                    LeagueId=1,
                    Wins=12,
                    Loses=4,
                    Championships=0
                },
                new Team
                {
                    Id=8,
                    Name="Cleveland Browns",
                    LeagueId=1,
                    Wins=7,
                    Loses=10,
                    Championships=8
                },
                new Team
                {
                    Id=9,
                    Name="Dallas Cowboys",
                    LeagueId=1,
                    Wins=12,
                    Loses=5,
                    Championships=5
                },
                new Team
                {
                    Id=10,
                    Name="Denver Broncos",
                    LeagueId=1,
                    Wins=5,
                    Loses=12,
                    Championships=3
                },
                new Team
                {
                    Id=11,
                    Name="Detroit Lions",
                    LeagueId=1,
                    Wins=9,
                    Loses=8,
                    Championships=4
                },
                new Team
                {
                    Id=12,
                    Name="Green Bay Packers",
                    LeagueId=1,
                    Wins=8,
                    Loses=9,
                    Championships=13
                },
                new Team
                {
                    Id=13,
                    Name="Houston Texans",
                    LeagueId=1,
                    Wins=3,
                    Loses=13,
                    Championships=0
                },
                new Team
                {
                    Id=14,
                    Name="Indianapolis Colts",
                    LeagueId=1,
                    Wins=4,
                    Loses=12,
                    Championships=4
                },
                new Team
                {
                    Id=15,
                    Name="Jacksonville Jaguars",
                    LeagueId=1,
                    Wins=9,
                    Loses=8,
                    Championships=0
                },
                new Team
                {
                    Id=16,
                    Name="Kansas City Chiefs",
                    LeagueId=1,
                    Wins=14,
                    Loses=3,
                    Championships=4
                },
                new Team
                {
                    Id=17,
                    Name="Las Vegas Raiders",
                    LeagueId=1,
                    Wins=6,
                    Loses=11,
                    Championships=3
                },
                new Team
                {
                    Id=18,
                    Name="Los Angeles Chargers",
                    LeagueId=1,
                    Wins=10,
                    Loses=7,
                    Championships=1
                },
                new Team
                {
                    Id=19,
                    Name="Los Angeles Rams",
                    LeagueId=1,
                    Wins=5,
                    Loses=12,
                    Championships=4
                },
                new Team
                {
                    Id=20,
                    Name="Miami Dolphins",
                    LeagueId=1,
                    Wins=9,
                    Loses=8,
                    Championships=2
                },
                new Team
                {
                    Id=21,
                    Name="Minnesota Vikings",
                    LeagueId=1,
                    Wins=13,
                    Loses=4,
                    Championships=0
                },
                new Team
                {
                    Id=22,
                    Name="New England Patriots",
                    LeagueId=1,
                    Wins=8,
                    Loses=9,
                    Championships=6
                },
                new Team
                {
                    Id=23,
                    Name="New Orleans Saints",
                    LeagueId=1,
                    Wins=7,
                    Loses=10,
                    Championships=1
                },
                new Team
                {
                    Id=24,
                    Name="New York Giants",
                    LeagueId=1,
                    Wins=9,
                    Loses=7,
                    Championships=8
                },
                new Team
                {
                    Id=25,
                    Name="New York Jets",
                    LeagueId=1,
                    Wins=7,
                    Loses=10,
                    Championships=1
                },
                new Team
                {
                    Id=26,
                    Name="Philadelphia Eagles",
                    LeagueId=1,
                    Wins=14,
                    Loses=3,
                    Championships=4
                },
                new Team
                {
                    Id=27,
                    Name="Pittsburgh Steelers",
                    LeagueId=1,
                    Wins=9,
                    Loses=8,
                    Championships=6
                },
                new Team
                {
                    Id=28,
                    Name="San Francisco 49ers",
                    LeagueId=1,
                    Wins=13,
                    Loses=4,
                    Championships=5
                },
                new Team
                {
                    Id=29,
                    Name="Seattle Seahawks",
                    LeagueId=1,
                    Wins=9,
                    Loses=8,
                    Championships=1
                },
                new Team
                {
                    Id=30,
                    Name="Tampa Bay Buccaneers",
                    LeagueId=1,
                    Wins=8,
                    Loses=9,
                    Championships=2
                },
                new Team
                {
                    Id=31,
                    Name="Tennessee Titans",
                    LeagueId=1,
                    Wins=7,
                    Loses=10,
                    Championships=2
                },
                new Team
                {
                    Id=32,
                    Name="Washington Commanders",
                    LeagueId=1,
                    Wins=8,
                    Loses=8,
                    Championships=5
                }
            );

            modelBuilder.Entity<Player>().HasData(
                new Player
                {
                    Id=1,
                    Name="Patrick Mahomes",
                    TeamId=16,
                    Championships=2
                },
                new Player
                {
                    Id=2,
                    Name="Justin Jefferson",
                    TeamId=21,
                    Championships=0
                },
                new Player
                {
                    Id=3,
                    Name="Joe Burrow",
                    TeamId=7,
                    Championships=0
                },
                new Player
                {
                    Id=4,
                    Name="Josh Allen",
                    TeamId=4,
                    Championships=0
                },
                new Player
                {
                    Id=5,
                    Name="Jalen Hurts",
                    TeamId=26,
                    Championships=0
                }
            );
            
            modelBuilder.Entity<HomeTeam>().HasData(
                new HomeTeam
                {
                    Id=1,
                    Name="Kansas City Chiefs"
                }
            );

            modelBuilder.Entity<AwayTeam>().HasData(
                new AwayTeam
                {
                    Id=1,
                    Name="Philadelphia Eagles"
                }
            );

            modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    Id=1,
                    LeagueName="NFL",
                    HomeTeamId=1,
                    AwayTeamId=1,
                    HomeTeamScore=38,
                    AwayTeamScore=35,
                    HighlightLink="https://www.youtube.com/watch?v=BWkt79xkd00&ab_channel=NFL"
                }
            );
        }
    }
}