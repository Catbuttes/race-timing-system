namespace backend.Models
{

    public class TagDefinition
    {
        public Guid? Id { get; set; }
        public Guid CategoryId { get; set; }
        public String Value { get; set; } = null!;
    }
}