using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface ICityService
    {
        Task<List<CityDto>> GetAllAsync();
        Task<CityDto> GetByIdAsync(Guid id);
        Task<CityDto> CreateAsync(CreateCityRequestDto cityDto);
        Task<CityDto> UpdateAsync(Guid id, UpdateCityRequestDto cityDto);
        Task<CityDto> DeleteAsync(Guid id);
    }
}
