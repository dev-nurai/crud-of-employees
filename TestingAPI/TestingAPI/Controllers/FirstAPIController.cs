using LearningAPI.Data;
using LearningAPI.Logging;
using LearningAPI.Models;
using LearningAPI.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningAPI.Controllers
{

    [Route("api/FirstAPI")] //api/controllername
    //[Route("api/[controller]")] //for automatic select of controller
    [ApiController]
    public class FirstAPIController : ControllerBase
    {
        //private readonly ILogger<FirstAPIController> _logger;
        //private readonly ILogging _logger;
        //public FirstAPIController(ILogger<FirstAPIController> logger)

        private readonly ApplicationdbContext _db;
        public FirstAPIController(ApplicationdbContext db)
        {
            _db = db;
        }

        [HttpGet] //Http get end point
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<PlacesDTO>> GetPlaces ()
        {
            
            return Ok(_db.Places.ToList());
        }

        //[HttpGet("id")] //If we don't use id over here then api will get confused which one to call.
        [HttpGet("{id:int}", Name = "GetTest")] // Explicit int type for Id
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("/kuchbhi")]
        public ActionResult< PlacesDTO > GetPlace(int id)
        {
            if(id == 0)
            {
                
                return BadRequest();
            }
            var place = _db.Places.FirstOrDefault(x => x.Id == id);
            if(place == null)
            {
                return NotFound();
            }

            return Ok(place);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PlacesDTO> AddPlace([FromBody] PlacesDTO placeDTO)
        {
            //Custom validation for unique Name
            if(_db.Places.FirstOrDefault(x => x.Name.ToLower() == placeDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("Custom Error", "Place already Exists!");
                return BadRequest(ModelState);  
            }
            
            if(placeDTO == null)
            {
                return Ok (BadRequest(placeDTO));
            }
            if(placeDTO.Id > 0)
            {
                return Ok(StatusCodes.Status500InternalServerError);
            }
            Places placesDTO = new()
            {
                Id = placeDTO.Id,
                Name = placeDTO.Name,
                Details = placeDTO.Details,
                Occupancy = placeDTO.Occupancy,
                Rate = placeDTO.Rate,
                Sqft = placeDTO.Sqft,
                Amenity = placeDTO.Amenity

            };
            _db.Places.Add(placesDTO);
            _db.SaveChanges(); //push the changes when the SaveChanges() call.

            //return Ok(placeDTO);
            return CreatedAtRoute("GetPlace", new {id = placeDTO.Id }, placeDTO);
                //GetPlace will invoke and require an id

        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeletePlace(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var place = _db.Places.FirstOrDefault(x => x.Id == id);
            if(place == null)
            {
                return NotFound();
            }
            _db.Places.Remove(place);
            _db.SaveChanges();

            return NoContent();
        }
        //IActionResult is use when there is no data to return

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)] 
        public IActionResult UpdatePlace(int id, [FromBody]PlacesDTO placesDTO)
        {
            if(placesDTO == null || placesDTO.Id == 0)
            {
                return BadRequest();
            }
            //var updatePlace = PlacesData.PlacesList.FirstOrDefault(x => x.Id == id);
            //updatePlace.Name = placesDTO.Name;
            //updatePlace.Sqft= placesDTO.Sqft;
            //updatePlace.Occupancy = placesDTO.Occupancy;
            Places place = new()
            {
                Id = placesDTO.Id,
                Name = placesDTO.Name,
                Details = placesDTO.Details,
                Occupancy = placesDTO.Occupancy,
                Rate = placesDTO.Rate,
                Sqft = placesDTO.Sqft,
                Amenity = placesDTO.Amenity
            };
            _db.Places.Update(place);
            _db.SaveChanges();

            return NoContent();

        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPatch("/update-1")]
        public IActionResult UpdatePartialDetail(int id, JsonPatchDocument<PlacesDTO> patchDTO)
        {
            if(patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var updatePlace = _db.Places.AsNoTracking().FirstOrDefault(x=>x.Id == id);

            PlacesDTO placeDTO = new()
            {
                Id = updatePlace.Id,
                Name = updatePlace.Name,
                Details = updatePlace.Details,
                Occupancy = updatePlace.Occupancy,
                Rate = updatePlace.Rate,
                Sqft = updatePlace.Sqft,
                Amenity = updatePlace.Amenity
            };

            if (updatePlace == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(placeDTO, ModelState);


            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Places places = new Places()
            {
                Id = updatePlace.Id,
                Name = updatePlace.Name,
                Details = updatePlace.Details,
                Occupancy = updatePlace.Occupancy,
                Rate = updatePlace.Rate,
                Sqft = updatePlace.Sqft,
                Amenity = updatePlace.Amenity
            };
            _db.Places.Update(places);
            _db.SaveChanges();
            return NoContent();
        }

    }
}
