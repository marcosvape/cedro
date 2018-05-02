using CedroAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CedroAPI.Repository
{
    public class MenuRepository
    {

        protected static object _syncRoot = new Object();
        private static volatile MenuRepository instance;
        private static string[] args;

        private MenuRepository() { }

        public static MenuRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (instance == null)
                            instance = new MenuRepository();
                    }
                }
                return instance;
            }
        }

        public IQueryable<Menu> GetAll()
        {
            CedroContext context = new CedroContextFactory().CreateDbContext(args);
            var query = from sc in context.Menus
                        orderby sc.Id ascending
                        select sc;

            return query;
        }

        public Menu GetById(long menuId)
        {
            CedroContext context = new CedroContextFactory().CreateDbContext(args);
            var query = from sc in context.Menus
                        where sc.Id == menuId
                        select sc;

            return query.FirstOrDefault();
        }

        public IQueryable<Menu> GetByRestaurantId(long restaurantId)
        {
            CedroContext context = new CedroContextFactory().CreateDbContext(args);
            var query = from sc in context.Menus
                        where sc.RestaurantId == restaurantId
                        select sc;

            return query;
        }

        public Menu CreateMenu(Menu newEntity)
        {
            CedroContext context = new CedroContextFactory().CreateDbContext(args);
            context.Menus.Attach(newEntity);
            context.Entry(newEntity).State = EntityState.Added;
            context.SaveChanges();
            return newEntity;
        }


        public Menu UpdateMenu(Menu updatedEntity)
        {
            CedroContext context = new CedroContextFactory().CreateDbContext(args);
            context.Menus.Attach(updatedEntity);
            context.Entry(updatedEntity).State = EntityState.Modified;
            context.SaveChanges();
            return updatedEntity;
        }

        public void DeleteMenu(Menu deletedMenu)
        {
            CedroContext context = new CedroContextFactory().CreateDbContext(args);
            context.Menus.Attach(deletedMenu);
            context.Entry(deletedMenu).State = EntityState.Deleted;
            context.SaveChanges();
        }

    }
}
