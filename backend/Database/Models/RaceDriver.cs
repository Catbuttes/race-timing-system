namespace backend.Database.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    public class RaceDriver
    {
        [Key]
        public Guid Id { get; set; }

        public Guid DriverId { get; set; }
        public Driver Driver { get; set; } = null!;

        public Guid RaceId { get; set; }
        public Race Race { get; set; } = null!;

        public List<RaceDriverTag>? Tags { get; set; }
        public List<RaceDriverAttribute>? Attributes { get; set; }

    }

}