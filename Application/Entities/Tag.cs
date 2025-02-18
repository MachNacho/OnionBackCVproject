namespace Application.Entities
{
    public class Tag
    {
        public int ID { get; set; }
        public string? TagName { get; set; }
        public List<ProjectTags>? Projects { get; set; } = new List<ProjectTags>();
    }
}
