namespace RedBadge.Models.PlayerModels
{
    public class PlayerListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }=null!;
        public int? Fans { get; set; }
        public int? Championships { get; set; }
        public int TeamId { get; set; }
    }
}