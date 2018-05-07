using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviews.Library;
using RestaurantReviews.Library.Models;
using System.Data.Entity;


namespace RestaurantReviews.DataAccessLayer
{
    class CreateDb
    {
        static void Main(string[] args)
        {

                
            Restaurant restaurant = new Restaurant();

            Console.WriteLine("Creating DB...............");
            RestaurantContext restDb = new RestaurantContext();
            Console.WriteLine("Db Created..............");

            #region AddTestRest
            //example
            /* Console.WriteLine("Db Created..............");
            restaurant.Name = "Mod's";
            restaurant.City = "Reston";
            db.Restaurants.Add(restaurant);
            db.SaveChanges(); */

            //mine
            /*
            restaurant.RestaurantName = "Izzy's NY Pizza";
            restaurant.FoodType = "Pizza";
            restaurant.Street1 = "Hamilton E. Homles";
            restaurant.Street2 = "Drive";
            restaurant.City = "Stone Mountain";
            restaurant.State = "GA";
            restaurant.Zipcode = "43434";
            restaurant.Phone = "434 - 343 - 4343";

            restDb.Restaurants.Add(restaurant);
            restDb.SaveChanges();
            Console.WriteLine("Db Changes Saved..............");
            */
            #endregion

            #region UpdateRest
            //example
            /*
            var rest=db.Restaurants.Where(x => x.Id == 1).FirstOrDefault();
            rest.State = "VA";
            db.Entry<Restaurant>(rest).State = EntityState.Modified;
            db.SaveChanges();
            Console.WriteLine("Rest Updated.......");
    */
            #endregion




        }
    }
}
