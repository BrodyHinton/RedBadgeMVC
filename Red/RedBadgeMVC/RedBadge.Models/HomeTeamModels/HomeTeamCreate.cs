using System.ComponentModel.DataAnnotations;

namespace RedBadge.Models.HomeTeamModels
{
    public class HomeTeamCreate
    {
        [Required]
        public string Name { get; set; }=null!;
    }
}