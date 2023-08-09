using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Bike
    {
        [Required]
        public int Manufacturer { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public int FrameSize { get; set; }

        [Required]
        public float Price { get; set; }

        public int Id { get; set; }
    }
}
