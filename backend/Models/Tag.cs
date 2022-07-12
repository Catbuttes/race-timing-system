namespace backend.Models
{

    public class Tag
    {
        public Guid? DriverTagId { get; set; }
        public Guid TagId { get; set; }
        public string Category { get; set; } = null!;
        public string Value { get; set; } = null!;
    }
}