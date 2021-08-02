using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestTutorial.Entities;
using RestTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestTutorial.RestaurantServices
{
    public class RestaurantService : IRestaurantService
    {
        private readonly RestuarantDbContext _dbContext;
        private readonly IMapper _mapper;

        public RestaurantService(RestuarantDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public RestaurantDto GetById(int id)
        {
            var restaurant = _dbContext
              .Resturants
              .Include(r => r.Adress)
              .Include(r => r.Dishes)
              .FirstOrDefault(r => r.Id == id);
            if (restaurant is null)
            {
                return null;

            }

            var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);
            return restaurantDto;

        }

        public IEnumerable<RestaurantDto> GetAll()
        {
            var restaurants = _dbContext
                .Resturants

                .Include(r => r.Adress)
                .Include(r => r.Dishes)
                .ToList();


            var restaurantsDtos = _mapper.Map<List<RestaurantDto>>(restaurants);
            return restaurantsDtos;

        }

        public int Create(CreateRestaurantDto dto)
        {
            var restaurant = _mapper.Map<Restaurant>(dto);
            _dbContext.Resturants.Add(restaurant);
            _dbContext.SaveChanges();

            return restaurant.Id;

        }

        public bool Update(int id, UpdateRestaurantDto dto)
        {
            var restaurant = _dbContext
                .Resturants
                .FirstOrDefault(r => r.Id == id);

            if (restaurant is null)
            {
                return false;

            }
            restaurant.Name = dto.Name;
            restaurant.Description = dto.Description;
            restaurant.hasDelivery = dto.hasDelivery;
            _dbContext.SaveChanges();
            return true;

        }
        public bool Delete (int id )
        {

            var restaurant = _dbContext
              .Resturants
              .FirstOrDefault(r => r.Id == id);
            if (restaurant is null)
            {
                return false;

            }
            _dbContext.Resturants.Remove(restaurant);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
