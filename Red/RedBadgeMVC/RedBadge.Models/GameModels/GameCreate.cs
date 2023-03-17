using System.ComponentModel.DataAnnotations;

namespace RedBadge.Models.GameModels
{
    public class GameCreate
    {
        [Required]
        public DateTime Date { get; set; }
        public string LeagueName { get; set; }=null!;
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
    }
}