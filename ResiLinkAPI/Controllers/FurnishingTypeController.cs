﻿using BusinessLogicLayer.DTOs;
using DataAccessLayer.Data;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ResiLinkAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class FurnishingTypeController : ControllerBase
    {
        private readonly DataContext dbContext;
        private readonly IFurnishingTypeRepository furnishingTypeRepository;

        public FurnishingTypeController(DataContext dbContext, IFurnishingTypeRepository furnishingTypeRepository)
        {
            this.dbContext = dbContext;
            this.furnishingTypeRepository = furnishingTypeRepository;
        }

        [HttpGet("list")]
        [AllowAnonymous]
        [Authorize(Roles = "ADMIN, PROPERTYMANAGER")]
        public async Task<IActionResult> GetFurnishingTypes()
        {
            var furnishingTypes = await furnishingTypeRepository.GetFurnishingTypesAsync();
            var furnishingTypeDtos = new List<FurnishingTypeDto>();

            foreach (var furnishingType in furnishingTypes)
            {
                var furnishingTypeDto = new FurnishingTypeDto
                {
                    Id = furnishingType.Id,
                    Name = furnishingType.Name
                };

                furnishingTypeDtos.Add(furnishingTypeDto);
            }

            return Ok(furnishingTypeDtos);
        }
    }
}
