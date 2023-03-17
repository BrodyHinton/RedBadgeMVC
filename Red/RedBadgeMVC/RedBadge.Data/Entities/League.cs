using System.ComponentModel.DataAnnotations;

namespace RedBadge.Data.Entities
{
    public class League
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }=null!;
        public List<Team> TeamNames { get; set;}=null!;
    }
}