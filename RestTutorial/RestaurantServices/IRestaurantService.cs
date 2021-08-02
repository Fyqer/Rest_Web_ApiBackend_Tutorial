using RestTutorial.Models;
using System.Collections.Generic;

namespace RestTutorial.RestaurantServices
{
    public interface IRestaurantService
    {
        public bool Update(int id, UpdateRestaurantDto dto);
        public bool Delete(int id);
        int Create(CreateRestaurantDto dto);
        IEnumerable<RestaurantDto> GetAll();
        RestaurantDto GetById(int id);
    }
}