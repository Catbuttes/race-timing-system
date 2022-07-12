namespace backend.Database.Models
{
    using System.ComponentModel.DataAnnotations;    
    public class RaceAttribute
    {
        [Key]
        public Guid Id { get; set; }
        public String? Value { get; set; }

        public Guid RaceId { get; set; }
        public Race Race { get; set; } = null!;
        
        public Guid DefinitionId { get; set; }
        public AttributeDefinition Definition { get; set; } = null!;
    }
}