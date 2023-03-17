using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RedBadge.Data.Entities
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }=null!;
        public List<Player> PlayerNames { get; set;}=null!;
        public int? Wins { get; set; }
        public int? Loses { get; set; }
        public int? Championships { get; set; }
        public int? Fans { get; set; }
        public int LeagueId { get; set; }
        [ForeignKey(nameof(LeagueId))]
        public virtual League League { get; set; }=null!;
    }
}