using System.ComponentModel.DataAnnotations;

namespace RedBadge.Models.PlayerModels
{
    public class PlayerCreate
    {
        [Required]
        public string Name { get; set; }=null!;
        public int? Championships { get; set; }
        public int TeamId { get; set; }
    }
}