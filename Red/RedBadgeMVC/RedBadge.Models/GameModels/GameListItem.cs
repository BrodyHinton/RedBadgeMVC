namespace RedBadge.Models.GameModels
{
    public class GameListItem
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string LeagueName { get; set; }=null!;
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int? HomeTeamScore { get; set; }
        public int? AwayTeamScore { get; set; }
        public string HighlightLink { get; set; }
        public string MVP { get; set; }
        public int? HomeTeamVotes { get; set; }
        public int? AwayTeamVotes { get; set; }
    }
}