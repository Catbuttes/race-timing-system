namespace backend.Database.Models
{
    using System.ComponentModel.DataAnnotations;    
    public class TagDefinition
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public TagCategory Category { get; set; } = null!;
        public String Value { get; set; } = null!;
    }
}