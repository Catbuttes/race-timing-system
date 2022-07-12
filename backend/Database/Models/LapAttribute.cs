namespace backend.Database.Models
{
    using System.ComponentModel.DataAnnotations;    
    public class LapAttribute
    {
        [Key]
        public Guid Id { get; set; }
        public String? Value { get; set; }

        public Guid LapId { get; set; }
        public Lap Lap { get; set; } = null!;
        
        public Guid DefinitionId { get; set; }
        public AttributeDefinition Definition { get; set; } = null!;
    }
}