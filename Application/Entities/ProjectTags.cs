namespace Application.Entities
{
    public class ProjectTags//Bridging table
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public Project Project { get; set; }
        public int TagID { get; set; }
        public Tag Tag { get; set; }
    }
}
