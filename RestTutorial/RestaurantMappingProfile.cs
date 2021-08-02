using AutoMapper;
using RestTutorial.Entities;
using RestTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestTutorial
{
    public class RestaurantMappingProfile : Profile
    {
        public RestaurantMappingProfile()
        {

            CreateMap<Restaurant, RestaurantDto>()
                .ForMember(m => m.City, c => c.MapFrom(s => s.Adress.City))
              .ForMember(m => m.Street, c => c.MapFrom(s => s.Adress.Street))
              .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Adress.PostalCode));


            CreateMap<Dish, DishDto>();


            CreateMap<CreateRestaurantDto, Restaurant>()

                .ForMember(r => r.Adress, c => c.MapFrom(dto => new Address() { City = dto.City, PostalCode = dto.PostalCode, Street = dto.Street }));

        }
    }
}
