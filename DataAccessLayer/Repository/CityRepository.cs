using DataAccessLayer.Data;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly DataContext dbContext;

        public CityRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<City>> GetAllAsync()
        {
            return await dbContext.Cities.ToListAsync();
         
        }

        public async Task<City> GetByIdAsync(Guid id)
        {
            return await dbContext.Cities.FirstOrDefaultAsync(city => city.Id == id);
            
        }

        public async Task<City> CreateAsync(City city)
        {
            dbContext.Cities.Add(city);
            await dbContext.SaveChangesAsync();
            return city;
         
        }

        public async Task<City> UpdateAsync(Guid id, City city)
        {
            var existingCity = await dbContext.Cities.FirstOrDefaultAsync(c => c.Id == id);
            if (existingCity == null)
                return null;

            existingCity.Name = city.Name;
            existingCity.Country = city.Country;

            await dbContext.SaveChangesAsync();
            return existingCity;

        }

        public async Task<City> DeleteAsync(Guid id)
        {
            var existingCity = await dbContext.Cities.FirstOrDefaultAsync(c => c.Id == id);
            if (existingCity == null)
            {
                return null;
            }

            dbContext.Cities.Remove(existingCity);
            await dbContext.SaveChangesAsync();
            return existingCity;
        }
    }
}
