namespace Domain.Entities
{
    public class Experience
    {
        public int ID { get; set; }
        public string? Role { get; set; }
        public string? Company { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsCurrent { get; set; } = true;
        public string? ImageSrc { get; set; }
    }
}
