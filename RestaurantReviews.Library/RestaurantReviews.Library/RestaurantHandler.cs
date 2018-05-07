using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviews.Library.Models;


namespace RestaurantReviews.Library
{
    public static class RestaurantHandler
    {
        public static List<Restaurant> restaurants = new List<Restaurant>();
        static Restaurant selectedRestaurant;
        static bool restaurantIsSelected = false;

        public static Restaurant newRestaurant = new Restaurant();

        //List<Restaurant> currentRestaurantView;

        public static void SortRestaurantsBy(string param, bool descending)
        {
            if (param == "name")
            {
                if (descending == true)
                {
                    restaurants.OrderByDescending(x => x.RestaurantName);
                }
                else
                {
                    restaurants.OrderBy(x => x.RestaurantName);
                }
            }
            else if (param == "rating")
            {
                if (descending == true)
                {
                    restaurants.OrderByDescending(x => x.AvgRating);
                }
                else
                {
                    restaurants.OrderBy(x => x.AvgRating);
                }
            }
            else if (param == "type")
            {

                if (descending == true)
                {
                    restaurants.OrderByDescending(x => x.FoodType);
                }
                else
                {
                    restaurants.OrderBy(x => x.FoodType);
                }

            } else if (param == "address")
            {
                if (descending == true)
                {
                    restaurants.OrderByDescending(x => x.Country).OrderByDescending(x => x.State).OrderByDescending(x => x.City).OrderByDescending(x => x.Zipcode);

                }
                else
                {
                    restaurants.OrderBy(x => x.Country).OrderBy(x => x.State).OrderBy(x => x.City).OrderBy(x => x.Zipcode);
                }
            }
        }

        public static bool IsRestaurantSelected()
        {
            return restaurantIsSelected;
        }

        public static void DeselectRestaurant()
        {
            restaurantIsSelected = false;
        }

        public static void SelectRestaurant(string placeName)
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
                            place.DisplayRestaurantDetails();
                        }
                    }
                } else if (numExistingNames == 1)
                {
                    selectedRestaurant = restaurants.Find(x => x.RestaurantName.ToLower().Contains(placeName.ToLower()));
                    restaurantIsSelected = true;
                    Console.WriteLine("Restaurant found matching, "+ placeName + "\n");
                    selectedRestaurant.DisplayRestaurantDetails();
                }
            } 
        }

        public static void TopThree()
        {
            
            List<Restaurant> topThreeRestaurants = new List<Restaurant>();
            topThreeRestaurants = restaurants;
            topThreeRestaurants.OrderBy(x => x.AvgRating);

            if (topThreeRestaurants.Count < 3)
            {
                topThreeRestaurants = topThreeRestaurants.GetRange(0, topThreeRestaurants.Count - 1);
            }
            else
            {
                topThreeRestaurants = topThreeRestaurants.GetRange(0, 3);
            }

            Console.WriteLine("Top 3 Restaurants by Average Rating");
            foreach (Restaurant place in topThreeRestaurants)
            {
                place.DisplayRestaurantDetails();
            }
        }


        public static Restaurant AddRestaurantToDB()
        {
            newRestaurant = new Restaurant();
            return newRestaurant;
        }

        public static void AddRestaurant(Restaurant newPlace)
        {
            restaurants.Add(newPlace);
        }



        public static void AddRestaurant()
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

            Console.WriteLine("-----Address-----");
            Console.WriteLine("Street Number");
            input = Console.ReadLine();
            newRestaurant.Street1 = input;
            Console.WriteLine("Street Name");
            input = Console.ReadLine().ToString();
            newRestaurant.Street2 = input;
            Console.WriteLine("City");
            input = Console.ReadLine().ToString();
            newRestaurant.City = input;
            Console.WriteLine("State");
            input = Console.ReadLine().ToString();
            newRestaurant.State = input;
            Console.WriteLine("Country");
            input = Console.ReadLine().ToString();
            newRestaurant.Country = input;
            Console.WriteLine("Zipcode");
            input = Console.ReadLine();
            newRestaurant.Zipcode = input;
            Console.WriteLine("Phone");
            input = Console.ReadLine();
            newRestaurant.Phone = input;


            restaurants.Add(newRestaurant);


        }

        public static void SearchByName(string searchName)
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
                    placeMatchingName.DisplayRestaurantDetails();
                }
            }
        }

        public static void DisplayAll()
        {
            foreach (Restaurant place in restaurants)
            {
                place.DisplayRestaurantDetails();
            }
        }


        
        public static void DisplayTheseReviews()
        {
           ReviewHandler.PrintReviews(selectedRestaurant.Reviews);
        }

        public static void AddReviewToThisRestaurant()
        {
           ReviewHandler.AddReview(selectedRestaurant.Reviews);
        }

    }
}

