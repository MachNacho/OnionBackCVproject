namespace Domain.Entities
{
    public class Project
    {
        public int ID { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required DateTime ProjectDate { get; set; } = DateTime.Now;
        public required string Link { get; set; }
        public required bool HasPublicLink { get; set; } = false;
        public List<ProjectTags>? Tags { get; set; } = new List<ProjectTags>();
    }
}
