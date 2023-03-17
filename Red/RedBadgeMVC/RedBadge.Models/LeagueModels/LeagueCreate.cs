using System.ComponentModel.DataAnnotations;

namespace RedBadge.Models.LeagueModels
{
    public class LeagueCreate
    {
        [Required]
        public string Name { get; set; }=null!;
    }
}