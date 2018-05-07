using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviews.Library.Models;

namespace RestaurantReviews.Library
{
    public static class ReviewHandler 
    {
        

        public static double AggregateRatings(List<Review> reviews)
        {
            if ((reviews.Any() == true) & (reviews != null))
            {
                double netScore = reviews.Sum(x => x.Rating);
                double avgScore = netScore / reviews.Count;


                return avgScore;
            } else 
            {
                return 0;
            }
        }

        public static void PrintReviews(List<Review> reviews)
        {
            if (reviews.Any() == false)
            {
                Console.WriteLine("There are no reviews for this restaurant");
            }
            else
            {
                foreach (Review rev in reviews)
                {
                    rev.DisplayReview();
                }
            }
        }

        public static void AddReview(List<Review> reviews)
        {
            Review newReview = new Review();

            string input;
            Console.WriteLine("Adding new review");
            bool validRating = false;

            
           
            Console.WriteLine("Reviewer Name?");
            input = Console.ReadLine().ToString();
            newReview.ReviewerName = input;

            Console.WriteLine("Rating out of 5 (1-5)");

            while (validRating == false)
            {
                input = Console.ReadLine();
                if ((Convert.ToDouble(input) >= 1) & (Convert.ToDouble(input) <= 5))
                {
                    validRating = true;
                    newReview.Rating = Convert.ToDouble(input);
                }
                else
                {
                    Console.WriteLine("Please enter a valid rating between 1 and 5");
                }
            }

            
            Console.WriteLine("Additional feedback, comments, experience etc.:");
            input = Console.ReadLine().ToString();
            newReview.Description = input;
            newReview.Created = DateTime.Now;

            reviews.Add(newReview);
        }

    }
}

