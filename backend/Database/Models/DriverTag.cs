namespace backend.Database.Models
{
    using System.ComponentModel.DataAnnotations;    
    public class DriverTag
    {
        [Key]
        public int Id { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; } = null!;
        
        public int TagId { get; set; }
        public TagDefinition Tag { get; set; } = null!;
    }
}