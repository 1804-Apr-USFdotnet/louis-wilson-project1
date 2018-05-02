using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Library
{
    public class Location
    {
        public int ID { get; set; }
        //string _state;

        public int StreetNumber { get; set; }

        public string StreetName { get; set; }

        public string City { get; set; }

       /* public string State
        {
            get { return _state; }
            set { _state = value; }
        } */

        public String State { get; set; }

        public int Zipcode { get; set; }

       

        public override string ToString()
        {

            return StreetNumber + " " + StreetName + " " + City + "," + State + " " + Zipcode;

        }

       

    }
}
