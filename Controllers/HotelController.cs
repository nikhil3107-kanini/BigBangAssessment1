using BigBangAssessment.Models;
using BigBangAssessment.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BigBangAssessment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        [HttpGet]
        public IActionResult GetAllHotels()
        {
             var hotels = _hotelRepository.GetHotels();
                return Ok(hotels);
        }

        [HttpGet("{id}")]
        public IActionResult GetHotelById(int id)
        {
            try
            {
                var hotel = _hotelRepository.GetHotelById(id);
                if (hotel == null)
                    return NotFound();

                return Ok(hotel);
            }
            catch (Exception ex)
            {
                // Handle and log the exception
                Console.WriteLine("Error retrieving hotel by ID: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the hotel.");
            }
        }

        [HttpPost]
        public IActionResult CreateHotel([FromBody] Hotel hotel)
        {
            try
            {
                _hotelRepository.AddHotel(hotel);
                return CreatedAtAction(nameof(GetHotelById), new { id = hotel.HotelId }, hotel);
            }
            catch (Exception ex)
            {
                // Handle and log the exception
                Console.WriteLine("Error creating hotel: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the hotel.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateHotel(int id, [FromBody] Hotel hotel)
        {
            try
            {
                if (id != hotel.HotelId)
                    return BadRequest();

                _hotelRepository.UpdateHotel(hotel);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle and log the exception
                Console.WriteLine("Error updating hotel: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the hotel.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHotel(int id)
        {
            try
            {
                _hotelRepository.DeleteHotel(id);
                 return NoContent();
            }
            catch (Exception ex)
            {
                // Handle and log the exception
                Console.WriteLine("Error deleting hotel: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the hotel.");
            }
        }
    }
}
