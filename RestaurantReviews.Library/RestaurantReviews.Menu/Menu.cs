using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviews.Library;

namespace RestaurantReviews.Menu
{
    public class Menu
    {
        public static void Main(string[] args)
        {

            XMLSerialization xmlSerializer = new XMLSerialization();
            RestaurantHandler.restaurants = xmlSerializer.ReadListFromXML();




            string input;
            string menuInput;
            string reviewMenuInput;
            string exitFlag = "!";
            bool exitMenu = false;



            while (exitMenu == false)
            {
                if (RestaurantHandler.IsRestaurantSelected() == false)
                {
                    Console.WriteLine("1 Select a Restaurant,  2 display all Restaurants, 3 add Restaurant, 4 Search for a Restaurant, 5 Top 3 Restaurants, 6 Sort Restaurants ! = quit \n");

                    menuInput = Console.ReadLine().ToString();
                    Console.WriteLine(menuInput);

                    if (menuInput.Equals(exitFlag))
                    {
                        Console.WriteLine("Quitting");
                        exitMenu = true;

                    }
                    else if (menuInput == "1")
                    {
                        
                        Console.WriteLine("Enter a name or partial restaurant name to select");
                        input = Console.ReadLine().ToString();
                        RestaurantHandler.SelectRestaurant(input);
                    }
                    else if (menuInput == "2")
                    {
                        Console.WriteLine("Display all Restaurants \n");
                        RestaurantHandler.DisplayAll();

                    }
                    else if (menuInput == "3")
                    {
                        Console.WriteLine("Add Restaurant \n");
                        RestaurantHandler.AddRestaurant();
                        xmlSerializer.WriteListToXML(RestaurantHandler.restaurants);

                    } else if (menuInput == "4")
                    {
                        Console.WriteLine("Enter the name or partial name of a restaurant to search for");
                        input = Console.ReadLine().ToString();
                        RestaurantHandler.SearchByName(input);
                    }
                    else if (menuInput == "5")
                    {
                        RestaurantHandler.TopThree();
                    } else if (menuInput == "6")
                    {
                        
                        Console.WriteLine("Sort restaurants by 'name', 'rating', 'type', 'address'");
                      
                    }

                    else
                    {
                        Console.WriteLine("select a menu option \n");

                    }
                }

                else if (RestaurantHandler.IsRestaurantSelected() == true)

                {
                    Console.WriteLine("1 Display Reviews, 2 Review this Restaurant, 3 Return to main menu \n");
                    reviewMenuInput = Console.ReadLine().ToString();

                    if (reviewMenuInput == "1")
                    {
                        Console.WriteLine("Display Reviews");
                        RestaurantHandler.DisplayTheseReviews();
                    }
                    else if (reviewMenuInput == "2")
                    {
                        Console.WriteLine("Add Review \n");
                        RestaurantHandler.AddReviewToThisRestaurant();
                        xmlSerializer.WriteListToXML(RestaurantHandler.restaurants);
                    }
                    else if (reviewMenuInput == "3")
                    {
                        RestaurantHandler.DeselectRestaurant();
                        //unselect restaurant
                    }
                    else
                    {
                        Console.WriteLine(reviewMenuInput);
                        Console.WriteLine("select a menu option \n");
                    }
                }



            }
        }
    }
}
