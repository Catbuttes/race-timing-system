namespace backend.Database.Models
{
    using System.ComponentModel.DataAnnotations;    
    public class RaceTag
    {
        [Key]
        public Guid Id { get; set; }
        public Guid RaceId { get; set; }
        public Race Race { get; set; } = null!;
        public Guid TagId { get; set; }
        public TagDefinition Tag { get; set; } = null!;
    }
}