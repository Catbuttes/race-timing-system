namespace backend.Database.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AttributeDefinition
    {
        [Key]
        public int Id { get; set; }
        public String? Name { get; set; }
        public String? Description { get; set; }
        public String? Type { get; set; }
        public Boolean DriverValid { get; set; }
        public Boolean RaceValid { get; set; }
        public Boolean RaceDriverValid { get; set; }
        public Boolean LapValid { get; set; }
    }
}