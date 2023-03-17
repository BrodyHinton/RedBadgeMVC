using System.ComponentModel.DataAnnotations;

namespace RedBadge.Data.Entities
{
    public class HomeTeam
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }=null!;
    }
}