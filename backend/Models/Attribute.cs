namespace backend.Models
{

    public class Attribute
    {
        public int? DriverAttributeId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Value { get; set; } = null!;
    }
}