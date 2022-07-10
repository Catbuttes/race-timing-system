namespace backend.Models
{
    using System.Collections.Generic;
    public class Driver
    {
        public int? Id { get; set; }
        public Guid User { get; set; }
        public String? Name { get; set; }
        public IEnumerable<Attribute>? Attributes{ get; set; }
        public IEnumerable<Tag>? Tags{ get; set; }
    }

}