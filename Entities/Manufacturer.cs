using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Manufacturer
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}
