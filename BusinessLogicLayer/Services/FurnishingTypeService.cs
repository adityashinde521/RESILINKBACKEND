using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class FurnishingTypeService
    {
        private readonly IFurnishingTypeRepository furnishingType;

        public FurnishingTypeService(IFurnishingTypeRepository furnishingType)
        {
            this.furnishingType = furnishingType;
        }

        //public async Task<List<FurnishingType>> GetFurnishingTypes();

        
        
    }
}
