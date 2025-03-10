namespace Domain.Entities
{
    public class Experience
    {
        public int ID { get; set; }
        public required string Role { get; set; }
        public required string Company { get; set; }
        public required DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public required bool IsCurrent { get; set; } = true;
        public required string ImageSrc { get; set; }
    }
}
