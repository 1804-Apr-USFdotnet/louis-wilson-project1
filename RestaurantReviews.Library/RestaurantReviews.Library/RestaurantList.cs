using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Library
{
    public class RestaurantList : IItemList
    {
        //public int RestaurantListID { get; set; }
        //public List<Restaurant> restaurants = new List<Restaurant>();
        public List<Restaurant> restaurants { get; set; }
        //List<Restaurant> currentRestaurantView;
        Restaurant selectedRestaurant;
        bool restaurantIsSelected = false;

       public RestaurantList ()
        {
            restaurants = new List<Restaurant>();
        }

        public bool IsRestaurantSelected()
        {
            return restaurantIsSelected;
        }

        public void SelectRestaurant(string placeName)
        {
            bool nameExists;
            int numExistingNames;

            nameExists = restaurants.Any(x => x.RestaurantName.ToLower().Contains(placeName.ToLower()));

            if (nameExists == false)
            {
                Console.WriteLine("Restaurant not found in list");
            } else if (nameExists == true)
            {
                numExistingNames = restaurants.Count(x => x.RestaurantName.ToLower().Contains(placeName.ToLower()));

                if (numExistingNames > 1)
                {
                    Console.WriteLine("Multiple restaurant names matching, " + placeName + " found:\n Select from these restaurants");
                    foreach(Restaurant place in restaurants)
                    {
                        if (place.RestaurantName.ToLower().Contains(placeName.ToLower()))
                        {
                            place.displayInfo();
                        }
                    }
                } else if (numExistingNames == 1)
                {
                    selectedRestaurant = restaurants.Find(x => x.RestaurantName.ToLower().Contains(placeName.ToLower()));
                    restaurantIsSelected = true;
                    Console.WriteLine("Restaurant found matching, "+ placeName + "\n");
                    selectedRestaurant.displayInfo();
                }
            } 
        }

        public void GetLeadersByProperty(string property, int numLeaders)
        {
            //throw new NotImplementedException();
            List<Restaurant> topNumRestaurants = new List<Restaurant>();
            topNumRestaurants = restaurants;
            topNumRestaurants.OrderBy(chosenProperty => chosenProperty.AverageRating);

            topNumRestaurants = topNumRestaurants.GetRange(0, 3);

            Console.WriteLine("Top 3 Restaurants by Average Rating");
            foreach (Restaurant place in topNumRestaurants)
            {
                place.displayInfo();
            }
        }


        public void AddRestaurant(Restaurant newPlace)
        {
            restaurants.Add(newPlace);
        }



        public void AddRestaurant()
        {
            Restaurant newRestaurant = new Restaurant();
            string input;
            Console.WriteLine("Adding new restaurant");

            Console.WriteLine("Restaurant Name?");
            input = Console.ReadLine().ToString();
            newRestaurant.RestaurantName = input;

            Console.WriteLine("Food Type?");
            input = Console.ReadLine().ToString();
            newRestaurant.FoodType = input;

            Console.WriteLine("-----Location-----");
            Console.WriteLine("Street Number");
            input = Console.ReadLine();
            newRestaurant.restaurantLocation.StreetNumber = Convert.ToInt32(input);
            Console.WriteLine("Street Name");
            input = Console.ReadLine().ToString();
            newRestaurant.restaurantLocation.StreetName = input;
            Console.WriteLine("City");
            input = Console.ReadLine().ToString();
            newRestaurant.restaurantLocation.City = input;
            Console.WriteLine("State");
            input = Console.ReadLine().ToString();
            newRestaurant.restaurantLocation.State = input;
            Console.WriteLine("Zipcode");
            input = Console.ReadLine();
            newRestaurant.restaurantLocation.Zipcode = Convert.ToInt32(input);

          

            restaurants.Add(newRestaurant);
        }

        public void SearchByName(string searchName)
        {
            bool nameExists = false;
            List<Restaurant> tempRestaurantsView = new List<Restaurant>();

            foreach (Restaurant place in restaurants)
            {
                if (place.RestaurantName.ToLower().Contains(searchName))
                {
                    nameExists = true;
                    //Console.WriteLine(place.RestaurantName);
                    tempRestaurantsView.Add(place);
                }
            }

            if (nameExists == false)
            {
                Console.WriteLine("No restaurant found");
            } else
            {
                foreach(Restaurant placeMatchingName in tempRestaurantsView)
                {
                    placeMatchingName.displayInfo();
                }
            }
        }

        public void DisplayAll()
        {
            foreach (Restaurant place in restaurants)
            {
                place.displayInfo();
            }
        }

        public void DisplayTheseReviews()
        {
            selectedRestaurant.DisplayRestaurantReviews();
        }

        public void AddReviewToThisRestaurant()
        {
            selectedRestaurant.reviewList.AddReview();
        }

        public void DeselectRestaurant()
        {
            restaurantIsSelected = false;
        }

    }
}

