using AutoMapper;
using RedBadge.Data.Entities;
using RedBadge.Models.LeagueModels;
using RedBadge.Models.TeamModels;
using RedBadge.Models.PlayerModels;
using RedBadge.Models.GameModels;
using RedBadge.Models.HomeTeamModels;
using RedBadge.Models.AwayTeamModels;

namespace RedBadge.Services.Configurations
{
    public class MapperConfigurations : Profile
    {
        public MapperConfigurations()
        {
            CreateMap<League,LeagueCreate>().ReverseMap();
            CreateMap<League,LeagueDetail>().ReverseMap();
            CreateMap<League,LeagueListItem>().ReverseMap();
            CreateMap<League,LeagueUpdate>().ReverseMap();


            CreateMap<Team,TeamCreate>().ReverseMap();
            CreateMap<Team,TeamDetail>().ReverseMap();
            CreateMap<Team,TeamListItem>().ReverseMap();
            CreateMap<Team,TeamUpdate>().ReverseMap();


            CreateMap<Player,PlayerCreate>().ReverseMap();
            CreateMap<Player,PlayerDetail>().ReverseMap();
            CreateMap<Player,PlayerListItem>().ReverseMap();
            CreateMap<Player,PlayerUpdate>().ReverseMap();


            CreateMap<Game,GameCreate>().ReverseMap();
            CreateMap<Game,GameDetail>().ReverseMap();
            CreateMap<Game,GameListItem>().ReverseMap();
            CreateMap<Game,GameUpdate>().ReverseMap();


            CreateMap<HomeTeam,HomeTeamCreate>().ReverseMap();
            CreateMap<HomeTeam,HomeTeamDetail>().ReverseMap();
            CreateMap<HomeTeam,HomeTeamListItem>().ReverseMap();
            CreateMap<HomeTeam,HomeTeamUpdate>().ReverseMap();


            CreateMap<AwayTeam,AwayTeamCreate>().ReverseMap();
            CreateMap<AwayTeam,AwayTeamDetail>().ReverseMap();
            CreateMap<AwayTeam,AwayTeamListItem>().ReverseMap();
            CreateMap<AwayTeam,AwayTeamUpdate>().ReverseMap();
        }
    }
}