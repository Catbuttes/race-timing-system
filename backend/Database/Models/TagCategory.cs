namespace backend.Database.Models
{
    using System.ComponentModel.DataAnnotations;    
    public class TagCategory
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; } = null!;
        public String Description { get; set; } = null!;
        public Boolean DriverValid { get; set; }
        public Boolean RaceValid { get; set; }
        public Boolean RaceDriverValid { get; set; }
        public Boolean LapValid { get; set; }
    }
}