namespace backend.Database.Models
{
    using System.ComponentModel.DataAnnotations;    
    public class DriverAttribute
    {
        [Key]
        public int Id { get; set; }
        public String Value { get; set; } = null!;

        public int DriverId { get; set; }
        public Driver Driver { get; set; } = null!;
        
        public int DefinitionId { get; set; }
        public AttributeDefinition Definition { get; set; } = null!;
    }
}