namespace RedBadge.Models.TeamModels
{
    public class TeamDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }=null!;
        public int? Wins { get; set; }
        public int? Loses { get; set; }
        public int? Championships { get; set; }
        public int? Fans { get; set; }
        public int LeagueId { get; set; }
    }
}