namespace backend.Models
{

    public class Tag
    {
        public int? DriverTagId { get; set; }
        public int TagId { get; set; }
        public string Category { get; set; } = null!;
        public string Value { get; set; } = null!;
    }
}