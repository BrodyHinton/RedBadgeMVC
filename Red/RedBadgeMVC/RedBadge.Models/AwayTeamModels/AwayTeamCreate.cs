using System.ComponentModel.DataAnnotations;

namespace RedBadge.Models.AwayTeamModels
{
    public class AwayTeamCreate
    {
        [Required]
        public string Name { get; set; }=null!;
    }
}