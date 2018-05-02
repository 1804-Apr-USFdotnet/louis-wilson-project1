using System.Data.Entity;
using RestaurantReviews.Library;

namespace RestaurantReviews.DataAccessLayer
{
    public class RestaurantContext : DbContext
    {
        //public DbSet<RestaurantList> RestaurantLists { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<ReviewList> ReviewLists { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Location> Locations { get; set; }

        public RestaurantContext () : base("RestaurantDB") { }
    }

  
}
