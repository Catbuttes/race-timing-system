namespace backend.Database.Models
{
    using System.ComponentModel.DataAnnotations;    
    using System.Collections.Generic;
    public class Race
    {
        [Key]
        public int Id { get; set; }
        public Guid User { get; set; }
        public String Name { get; set; } = null!;

        public List<RaceTag>? Tags { get; set; } 
        public List<RaceAttribute>? Attributes { get; set; }
        public List<RaceDriver>? RaceEntries { get; set; }

    }

}