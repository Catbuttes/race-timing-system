namespace backend.Database.Models
{
    using System.ComponentModel.DataAnnotations;    
    using System.Collections.Generic;
    public class Driver
    {
        [Key]
        public Guid Id { get; set; }
        public Guid User { get; set; }
        public String Name { get; set; } = null!;

        public List<DriverTag>? Tags { get; set; }
        public List<DriverAttribute>? Attributes { get; set; }

        public List<RaceDriver>? RaceEntries { get; set; }
    }

}