namespace backend.Models
{

    public class TagCategory
    {
        public Guid? Id { get; set; }
        public String Name { get; set; } = null!;
        public String Description { get; set; } = null!;
        public Boolean DriverValid { get; set; }
        public Boolean RaceValid { get; set; }
        public Boolean RaceDriverValid { get; set; }
        public Boolean LapValid { get; set; }
    }
}