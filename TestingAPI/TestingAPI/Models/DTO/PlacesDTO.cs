using System.ComponentModel.DataAnnotations;

namespace LearningAPI.Models.DTO
{
    public class PlacesDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)] //with the help of ApiController attributes, it will validate the input in the Name;
        public string Name { get; set; }

        public string Details { get; set; }
        [Required]
        public double Rate { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }
        public int Occupancy { get; set; }

        public int Sqft { get; set; }
    }
}

/*
    DTO is intermediate between Api and models
     - Use to hide private property if not want to expose.

*/