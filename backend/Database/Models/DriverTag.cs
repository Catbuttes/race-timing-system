namespace backend.Database.Models
{
    using System.ComponentModel.DataAnnotations;    
    public class DriverTag
    {
        [Key]
        public Guid Id { get; set; }
        public Guid DriverId { get; set; }
        public Driver Driver { get; set; } = null!;
        
        public Guid TagId { get; set; }
        public TagDefinition Tag { get; set; } = null!;
    }
}