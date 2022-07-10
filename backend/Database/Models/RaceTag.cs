namespace backend.Database.Models
{
    using System.ComponentModel.DataAnnotations;    
    public class RaceTag
    {
        [Key]
        public int Id { get; set; }
        public int RaceId { get; set; }
        public Race Race { get; set; } = null!;
        public int TagId { get; set; }
        public TagDefinition Tag { get; set; } = null!;
    }
}