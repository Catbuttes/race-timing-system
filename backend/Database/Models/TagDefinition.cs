namespace backend.Database.Models
{
    using System.ComponentModel.DataAnnotations;    
    public class TagDefinition
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public TagCategory Category { get; set; } = null!;
        public String Value { get; set; } = null!;
    }
}