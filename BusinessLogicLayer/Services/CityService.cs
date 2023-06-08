using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Exceptions;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class CityService : ICityService

    {
        private readonly ICityRepository cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }

        public async Task<List<CityDto>> GetAllAsync()
        {
            var cities = await cityRepository.GetAllAsync();
            return cities.Select(city => new CityDto
            {
                Id = city.Id,
                Name = city.Name,
                Country = city.Country
            }).ToList();
        }

        public async Task<CityDto> GetByIdAsync(Guid id)
        {
            var city = await cityRepository.GetByIdAsync(id);
            if (city == null)
                return null;

            return new CityDto
            {
                Id = city.Id,
                Name = city.Name,
                Country = city.Country
            };
        }

        public async Task<CityDto> CreateAsync(CreateCityRequestDto cityDto)
        {
            if (cityDto.Name.Length > 25)
                throw new BadRequestException("City name exceeds the maximum length of 25 characters.");

            if (cityDto.Country.Length > 25)
                throw new BadRequestException("Country name exceeds the maximum length of 25 characters.");

            var city = new City
            {
                Name = cityDto.Name,
                Country = cityDto.Country
            };

            var createdCity = await cityRepository.CreateAsync(city);

            return new CityDto
            {
                Id = createdCity.Id,
                Name = createdCity.Name,
                Country = createdCity.Country
            };
        }

        public async Task<CityDto> UpdateAsync(Guid id, UpdateCityRequestDto cityDto)
        {
            var existingCity = await cityRepository.GetByIdAsync(id);
            if (existingCity == null)
                return null;

            existingCity.Name = cityDto.Name ?? existingCity.Name;
            existingCity.Country = cityDto.Country ?? existingCity.Country;

            var updatedCity = await cityRepository.UpdateAsync(id, existingCity);

            return new CityDto
            {
                Id = updatedCity.Id,
                Name = updatedCity.Name,
                Country = updatedCity.Country
            };
        }
        public async Task<CityDto> DeleteAsync(Guid id)
        {
            var city = await cityRepository.DeleteAsync(id);
            if (city == null)
            {
                return null;
            }

            return new CityDto
            {
                Id = city.Id,
                Name = city.Name,
                Country = city.Country
            };
        }
    }
}
