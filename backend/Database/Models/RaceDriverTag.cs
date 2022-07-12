namespace backend.Database.Models
{
    using System.ComponentModel.DataAnnotations;    
    public class RaceDriverTag
    {
        [Key]
        public Guid Id { get; set; }
        public Guid RaceDriverId { get; set; }
        public RaceDriver RaceDriver { get; set; } = null!;
        public Guid TagId { get; set; }
        public TagDefinition Tag { get; set; } = null!;
    }
}