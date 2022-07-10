namespace backend.Database.Models
{
    using System.ComponentModel.DataAnnotations;    
    using System.Collections.Generic;
    public class Lap
    {
        [Key]
        public int Id { get; set; }

        public int RaceDriverId { get; set; }
        public RaceDriver RaceDriver { get; set; } = null!;

        public List<LapTag>? Tags { get; set; }
        public List<LapAttribute>? Attributes { get; set; }

    }

}