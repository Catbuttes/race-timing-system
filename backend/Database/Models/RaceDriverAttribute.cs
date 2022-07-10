namespace backend.Database.Models
{
    using System.ComponentModel.DataAnnotations;    
    public class RaceDriverAttribute
    {
        [Key]
        public int Id { get; set; }
        public String? Value { get; set; }

        public int RaceDriverId { get; set; }
        public RaceDriver RaceDriver { get; set; } = null!;
        
        public int DefinitionId { get; set; }
        public AttributeDefinition Definition { get; set; } = null!;
    }
}