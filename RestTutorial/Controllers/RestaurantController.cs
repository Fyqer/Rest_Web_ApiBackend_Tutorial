using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestTutorial.Entities;
using RestTutorial.Models;
using RestTutorial.RestaurantServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestTutorial.Controllers
{  [Route("api/restaurant")]
    public class RestaurantController : ControllerBase
    {
        private readonly RestuarantDbContext _dbContext;
        private readonly IMapper _mapper;

        public IRestaurantService _restaurantService { get; }

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateRestaurantDto dto, [FromRoute] int id)
        {

            if(!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            var isUpdated = _restaurantService.Update(id, dto);
            if(!isUpdated)
            {

                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id )
        {

            var isDeleted = _restaurantService.Delete(id);

            if (isDeleted)
            {
                return Ok();
            }

            return NotFound();

        }
        [HttpPost]

        public ActionResult CreateRestaurant([FromBody] CreateRestaurantDto dto)
        {

            var ID = _restaurantService.Create(dto); 

            return Created($"/api/restaurant/{ID}", null);

        }

        [HttpGet]
        public ActionResult<IEnumerable<RestaurantDto>> GetAll()
        {

            var restaurantDtos = _restaurantService.GetAll();

                return Ok(restaurantDtos);

        }
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<RestaurantDto>> Get([FromRoute] int id)
        {

            var restaurant = _restaurantService.GetById(id);

           if(restaurant is null )
            {
                return NotFound();

            }

      
            return Ok(restaurant);

        }
    }
}
