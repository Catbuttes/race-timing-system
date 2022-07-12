namespace backend.Database.Models
{
    using System.ComponentModel.DataAnnotations;    
    public class LapTag
    {
        [Key]
        public Guid Id { get; set; }
        public Guid LapId { get; set; }
        public Lap Lap { get; set; } = null!;
        public Guid TagId { get; set; }
        public TagDefinition Tag { get; set; } = null!;
    }
}