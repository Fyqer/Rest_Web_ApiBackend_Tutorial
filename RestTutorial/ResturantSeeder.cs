using RestTutorial.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestTutorial
{
    public class ResturantSeeder
    {
        private readonly RestuarantDbContext _dbContext;

        public ResturantSeeder(RestuarantDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public void Seed()
        {

            if (_dbContext.Database.CanConnect())
            {

                if (!_dbContext.Resturants.Any())
                {

                    var restaurants = GetRestaurants();
                    _dbContext.Resturants.AddRange(restaurants);
                    _dbContext.SaveChanges();

                }

            }
        }

            private IEnumerable<Restaurant> GetRestaurants()
            {

                var restaurants = new List<Restaurant>()
                { new Restaurant()
                {
                    Name=  "KFC",
                    Category = "FastFood",
                    Description = "kfc to jest to",
                    ContactEmail = "contact@kfc.pl",
                    hasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Nashville hot chicken",
                            Price = 10.5M,

                        },


                        new Dish()
                        {
                            Name = "Burger",
                            Price = 15.5M,

                        },

                },
                    Adress = new Address()
                    {

                        City = "Krakow",
                        Street = "Długa",
                        PostalCode = "30-01"
                    }


                },
                new Restaurant()
                {
                    Name=  "KING BURGER",
                    Category = "FastFood",
                    Description = "burgeroo",
                    ContactEmail = "king@kfc.pl",
                    hasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "cheeseburger",
                            Price = 11.5M,

                        },


                        new Dish()
                        {
                            Name = "Burger2",
                            Price = 25.5M,

                        },

                },
                    Adress = new Address()
                    {

                        City = "Krakow",
                        Street = "Długa",
                        PostalCode = "30-01"
                    }


            }

    };
                return restaurants;
         }
       }
    }

    
