namespace backend.Models
{

    public class Attribute
    {
        public Guid? DriverAttributeId { get; set; } = null!;
        public Guid DefinitionId { get; set; }
        public string Name { get; set; } = null!;
        public string Value { get; set; } = null!;
    }
}