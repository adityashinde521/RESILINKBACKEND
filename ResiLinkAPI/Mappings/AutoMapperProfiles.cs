using AutoMapper;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace HSPA_BACKEND.Mappings
{
    public class AutoMapperProfiles : Profile 
    {
        public AutoMapperProfiles() { 
        
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<City, UpdateCityRequestDto>().ReverseMap();
            CreateMap<City, UpdateCityRequestDto>().ReverseMap();

            CreateMap<FurnishingType, FurnishingTypeDto>().ReverseMap();
            CreateMap<PropertyType, PropertyTypeDto>().ReverseMap();

            CreateMap<Property, PropertyListingDto>().ReverseMap();
            CreateMap<ApplicationUser, RegisterDto>().ReverseMap();
            CreateMap<ApplicationUser, LoginDto>().ReverseMap();
            CreateMap<ApplicationUser, UserDto>().ReverseMap();

        }


    }
}
