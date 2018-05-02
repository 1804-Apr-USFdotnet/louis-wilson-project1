using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace RestaurantReviews.Library
{
    public class Restaurant : IItem
    {
        public int RestaurantID { get; set; }
        //public int ReviewListID { get; set; } //foreign key

         /*
        public class Location
        {
            string _state;

            public int StreetNumber { get; set; }

            public string StreetName { get; set; }

            public string City { get; set; }

            public string State
            {
                 get { return _state; }
                 set { _state = value; }
            }

            public int Zipcode { get; set; }

            public override string ToString()
            {
                return StreetNumber + " " + StreetName + " " + City + "," + State + " " + Zipcode;
            }

        }
        */
        
        public string RestaurantName { get; set; }
        public string FoodType { get; set; }


    /*
        public double AverageRating {
            get { return reviewList.AggregateScore(); }
            set { value = reviewList.AggregateScore();
                AverageRating = value;
            }
        }
        */

        public double AverageRating { get; set; }


        //public Location restaurantLocation = new Location();
        // public Location restaurantLocation { get; set; }

        [Required]
        public Location restaurantLocation { get; set; }

        //public ReviewList reviewList = new ReviewList();

        [Required]
        public ReviewList reviewList { get; set; }

        
  public Restaurant()
        {
            reviewList = new ReviewList();
            restaurantLocation = new Location();
        }

        public void displayInfo()
        {
            Double rating = AverageRating;
            Console.WriteLine(RestaurantName);
            Console.WriteLine(FoodType);

            if (rating != 0)
            {
                Console.WriteLine("Rating out of 5" + AverageRating);
            }
            else
            {
                Console.WriteLine("No reviews");
            }

            Console.WriteLine(restaurantLocation.StreetName);
            Console.WriteLine(restaurantLocation.ToString() + "\n");
        }
        
        public void DisplayRestaurantReviews()
        {
            reviewList.printReviews();
        }

       

        




    }
}
