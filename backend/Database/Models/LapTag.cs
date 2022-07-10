namespace backend.Database.Models
{
    using System.ComponentModel.DataAnnotations;    
    public class LapTag
    {
        [Key]
        public int Id { get; set; }
        public int LapId { get; set; }
        public Lap Lap { get; set; } = null!;
        public int TagId { get; set; }
        public TagDefinition Tag { get; set; } = null!;
    }
}