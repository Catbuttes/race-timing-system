namespace backend.Database.Models
{
    using System.ComponentModel.DataAnnotations;    
    public class RaceDriverAttribute
    {
        [Key]
        public Guid Id { get; set; }
        public String? Value { get; set; }

        public Guid RaceDriverId { get; set; }
        public RaceDriver RaceDriver { get; set; } = null!;
        
        public Guid DefinitionId { get; set; }
        public AttributeDefinition Definition { get; set; } = null!;
    }
}