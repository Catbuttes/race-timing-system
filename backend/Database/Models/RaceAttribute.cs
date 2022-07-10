namespace backend.Database.Models
{
    using System.ComponentModel.DataAnnotations;    
    public class RaceAttribute
    {
        [Key]
        public int Id { get; set; }
        public String? Value { get; set; }

        public int RaceId { get; set; }
        public Race Race { get; set; } = null!;
        
        public int DefinitionId { get; set; }
        public AttributeDefinition Definition { get; set; } = null!;
    }
}