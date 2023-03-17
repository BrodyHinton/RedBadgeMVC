using System.ComponentModel.DataAnnotations;

namespace RedBadge.Models.TeamModels
{
    public class TeamCreate
    {
        [Required]
        public string Name { get; set; }=null!;
        public int? Wins { get; set; }
        public int? Loses { get; set; }
        public int? Championships { get; set; }
        [Required]
        public int LeagueId { get; set; }
    }
}