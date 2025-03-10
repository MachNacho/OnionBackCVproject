namespace Domain.Entities
{
    public class Tag
    {
        public int ID { get; set; }
        public required string TagName { get; set; }
        public List<ProjectTags>? Projects { get; set; } = new List<ProjectTags>();
    }
}
