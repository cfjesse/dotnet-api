using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class BaseBikeEntityDto
    {
        [Required]
        public int Manufacturer { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public int FrameSize { get; set; }

        [Required]
        public float Price { get; set; }
    }

    public class BikeEntityDto: BaseBikeEntityDto
    {
        [Required]
        public int Id { get; set; }
    }
}
