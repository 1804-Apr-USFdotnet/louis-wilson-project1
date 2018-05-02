using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviews.Library;
using System.Data.Entity;

namespace RestaurantReviews.DataAccessLayer
{
    class RestaurantReviewsContext : DbContext
     {
        public RestaurantReviewsContext() : base()
        {

        }

        public DbSet<RestaurantList> RestaurantLists { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<ReviewList> ReviewLists { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
