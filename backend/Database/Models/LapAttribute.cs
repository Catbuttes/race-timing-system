namespace backend.Database.Models
{
    using System.ComponentModel.DataAnnotations;    
    public class LapAttribute
    {
        [Key]
        public int Id { get; set; }
        public String? Value { get; set; }

        public int LapId { get; set; }
        public Lap Lap { get; set; } = null!;
        
        public int DefinitionId { get; set; }
        public AttributeDefinition Definition { get; set; } = null!;
    }
}