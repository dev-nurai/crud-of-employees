using LearningAPI.Models.DTO;

namespace LearningAPI.Data
{
    public static class PlacesData
    {
        public static List<PlacesDTO> PlacesList = new List<PlacesDTO> { new PlacesDTO { Id = 1, Name = "Delhi", Sqft = 150, Occupancy = 2},
                new PlacesDTO { Id = 2, Name = "Kolkata", Sqft = 200, Occupancy = 3 } };
    }
}
