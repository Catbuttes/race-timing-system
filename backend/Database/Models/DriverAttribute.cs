namespace backend.Database.Models
{
    using System.ComponentModel.DataAnnotations;    
    public class DriverAttribute
    {
        [Key]
        public Guid Id { get; set; }
        public String Value { get; set; } = null!;

        public Guid DriverId { get; set; }
        public Driver Driver { get; set; } = null!;
        
        public Guid DefinitionId { get; set; }
        public AttributeDefinition Definition { get; set; } = null!;
    }
}