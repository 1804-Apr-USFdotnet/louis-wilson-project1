using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviews.Library;
using RestaurantReviews.Library.Models;
using RestaurantReviews.DataAccessLayer.Repositories;

namespace RestaurantReviews.DBMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository<Restaurant> crud;
            IDbContext restDB;

            restDB = new RestaurantContext();
            crud = new RestaurantCrud<Restaurant>(restDB);


        }
    }
}
