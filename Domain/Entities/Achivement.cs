namespace Domain.Entities
{
    public class Achivement
    {
        public int ID { get; set; }
        public required string Title { get; set; }
        public required DateTime Date { get; set; }
        public required string Description { get; set; }
    }
}
