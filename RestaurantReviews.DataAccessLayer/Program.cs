using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using RestaurantReviews.Library;

namespace RestaurantReviews.DataAccessLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new RestaurantReviewsContext())
            {
                var RestaurantList = new RestaurantList();
                context.RestaurantLists.Add(RestaurantList);
                context.SaveChanges();
            }
        }
    }
}
