using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Library
{
    public class Review : IItem
    {
        public int ID { get; set; }
        //public int ReviewListID { get; set; } //foreign key
        //public enum SortFieldType { SortNumber, SortString }




        public string ReviewerName { get; set; }
        
        public double Rating { get; set; }
        public string Description { get; set; }

        /*
        public struct ReviewDate
        {
            int _day;
            int _month;
            int _year;

            public int Day
            {
                get { return _day; }
                set { _day = value; }
            }

            public int Month
            {
                get { return _month; }
                set { _month = value; }
            }

            public int Year
            {
                get { return _year; }
                set { _year = value; }
            }

            public override string ToString()
            {
                return Day + " " + Month + " " + Year;
            }

        }
        public ReviewDate reviewDate = new ReviewDate();
        */

        public DateTime reviewDate { get; set; }
        
        public Review()
        {
            reviewDate = DateTime.Today;
        }

        public void displayInfo()
        {
            Console.Write(ReviewerName);
            Console.WriteLine(reviewDate.ToString());
            Console.WriteLine("Rating " + Rating);
            Console.WriteLine(Description);
        }
    }


}
