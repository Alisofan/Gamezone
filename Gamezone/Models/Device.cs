namespace GameZone.Models
{
    public class Device : BaseEntity
    {
        [MaxLength(length:50)]
        public  string icon { get; set; } = string.Empty;
    }
}
