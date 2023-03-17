using System.ComponentModel.DataAnnotations;

namespace RedBadge.Data.Entities
{
    public class AwayTeam
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }=null!;
    }
}