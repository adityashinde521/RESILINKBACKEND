//using AutoMapper;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RESILINK_BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CityController : ControllerBase
    {
        private readonly ICityService cityService;

        public CityController(ICityService cityService) 
        {
            this.cityService = cityService;
        }

        //Get All City
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cities = await cityService.GetAllAsync();
            return Ok(cities);
        }

        //Update the current city
        //https://localhost:port/api/City/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var city = await cityService.GetByIdAsync(id);
            if (city == null)
                return NotFound();

            return Ok(city);
        }


        //Post to create new City
        //https://localhost:port/api/City/
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCityRequestDto cityDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdCity = await cityService.CreateAsync(cityDto);
            return CreatedAtAction(nameof(GetById), new { id = createdCity.Id }, createdCity);
        }

   
        //  Update an existing city in the Cities table.
        //PUT : https://localhost:port/api/city/{id}
       
        //[Authorize(Roles = "PropertyManager")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCityRequestDto cityDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedCity = await cityService.UpdateAsync(id, cityDto);
            if (updatedCity == null)
                return NotFound();

            return Ok(updatedCity);
        }


        //Delete - Delete a city from the Cities table.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedCity = await cityService.DeleteAsync(id);
            if (deletedCity == null)
                return NotFound();

            return Ok(deletedCity);
        }
    }

}
