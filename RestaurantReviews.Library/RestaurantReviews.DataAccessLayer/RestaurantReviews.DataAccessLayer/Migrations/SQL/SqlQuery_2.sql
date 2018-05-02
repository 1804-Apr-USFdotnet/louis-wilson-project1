using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviews.DataAccessLayer;
using RestaurantReviews.Library;

namespace RestaurantReviews.CRUD
{
    class Client
    {
        static void Main(string[] args)
        {
            RestaurantList listRestaurants = new RestaurantList();
            
            RestaurantCrud crud = new RestaurantCrud();
            

            var restaurants = crud.LoadRestaurants();

            foreach(var place in restaurants)
            {
                listRestaurants.AddRestaurant(place);
            }
            
            //crud.addRestaurant(listRestaurants);

            foreach (Restaurant place in listRestaurants.restaurants)
            {
                place.displayInfo();
            }

            /*RestaurantXMLHandler restaurantXMLHandler = new RestaurantXMLHandler();

            listRestaurants = restaurantXMLHandler.ReadListFromXML(); */

        }
    }
}
