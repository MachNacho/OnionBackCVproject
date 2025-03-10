namespace Domain.Entities
{
    public class Education
    {
        public int ID { get; set; }
        public required string Title { get; set; }
        public required string EducationLevel { get; set; }
        public required string Institution { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public required string Description { get; set; }
        public required string ImageSrc { get; set; }
    }
}
