using CedroAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CedroAPI.Repository
{
    public class RestaurantRepository
    {

        protected static object _syncRoot = new Object();
        private static volatile RestaurantRepository instance;
        private static string[] args;

        private RestaurantRepository() { }

        public static RestaurantRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (instance == null)
                            instance = new RestaurantRepository();
                    }
                }
                return instance;
            }
        }

        public IQueryable<Restaurant> GetAll()
        {
            CedroContext context = new CedroContextFactory().CreateDbContext(args);
            var query = from sc in context.Restaurants
                        orderby sc.Id ascending
                        select sc;

            return query;
        }

        public Restaurant GetById(long restaurantId)
        {
            CedroContext context = new CedroContextFactory().CreateDbContext(args);
            var query = from sc in context.Restaurants
                        where sc.Id == restaurantId
                        select sc;

            return query.FirstOrDefault();
        }

        public Restaurant CreateRestaurant(Restaurant newEntity)
        {
            CedroContext context = new CedroContextFactory().CreateDbContext(args);
            context.Restaurants.Attach(newEntity);
            context.Entry(newEntity).State = EntityState.Added;
            context.SaveChanges();
            return newEntity;
        }

        public Restaurant UpdateRestaurant(Restaurant updatedEntity)
        {
            CedroContext context = new CedroContextFactory().CreateDbContext(args);
            context.Restaurants.Attach(updatedEntity);
            context.Entry(updatedEntity).State = EntityState.Modified;
            context.SaveChanges();

            return updatedEntity;
        }

        public void DeleteRestaurant(Restaurant deletedRestaurant)
        {
            CedroContext context = new CedroContextFactory().CreateDbContext(args);
            context.Restaurants.Attach(deletedRestaurant);
            context.Entry(deletedRestaurant).State = EntityState.Deleted;
            context.SaveChanges();
        }

    }
}
