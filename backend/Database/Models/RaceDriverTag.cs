namespace backend.Database.Models
{
    using System.ComponentModel.DataAnnotations;    
    public class RaceDriverTag
    {
        [Key]
        public int Id { get; set; }
        public int RaceDriverId { get; set; }
        public RaceDriver RaceDriver { get; set; } = null!;
        public int TagId { get; set; }
        public TagDefinition Tag { get; set; } = null!;
    }
}