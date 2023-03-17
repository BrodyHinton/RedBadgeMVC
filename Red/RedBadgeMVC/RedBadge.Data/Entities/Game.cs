using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RedBadge.Data.Entities
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string LeagueName { get; set; }=null!;
        public int HomeTeamId { get; set; }
        [ForeignKey(nameof(HomeTeamId))]
        public virtual HomeTeam HomeTeam { get; set; }=null!;
        public int AwayTeamId { get; set; }
        [ForeignKey(nameof(AwayTeamId))]
        public virtual AwayTeam AwayTeam { get; set; }=null!;
        public int? HomeTeamScore { get; set; }
        public int? AwayTeamScore { get; set; }
        public string HighlightLink { get; set; }
        public int? HomeTeamVotes { get; set; }
        public int? AwayTeamVotes { get; set; }
    }
}