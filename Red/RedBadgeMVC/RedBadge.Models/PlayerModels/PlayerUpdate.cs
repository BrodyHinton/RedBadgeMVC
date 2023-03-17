namespace RedBadge.Models.PlayerModels
{
    public class PlayerUpdate
    {
        public int Id { get; set; }
        public string Name { get; set; }=null!;
        public int? Championships { get; set; }
        public int TeamId { get; set; }
    }
}