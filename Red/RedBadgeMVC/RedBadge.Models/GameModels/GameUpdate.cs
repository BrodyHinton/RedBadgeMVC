namespace RedBadge.Models.GameModels
{
    public class GameUpdate
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string LeagueName { get; set; }=null!;
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int? HomeTeamScore { get; set; }
        public int? AwayTeamScore { get; set; }
        public string HighlightLink { get; set; }
    }
}