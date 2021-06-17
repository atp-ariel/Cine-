using System.ComponentModel.DataAnnotations;

namespace DomainLayer
{
    public class Configurations
    {
        [Key]
        public string KeyConfig { get; set; }
        public string Value { get; set; }
    }
}
