namespace Domain.Entities
{
    public class Hobby
    {
        public int ID { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string ImageSrc { get; set; }
    }
}
