using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RestaurantReviews.Library.Models
{
    
        public class Restaurant : IEntity
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            [Required]
            [StringLength(25, ErrorMessage = "Restaurant Name should be within 25 characters")]
            public string RestaurantName { get; set; }
            public string FoodType { get; set; }
            [Column("s1")]
            public string Street1 { get; set; }
            [Column("s2")]
            public string Street2 { get; set; }
            [Required]
            public string City { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            //[RegularExpression("[0-9]{5}")]
            [DataType(DataType.PostalCode)]
            public string Zipcode { get; set; }
            [DataType(DataType.PhoneNumber)]
            public string Phone { get; set; }

            //Related Models of Foreign Key Relationship

            public virtual List<Review> Reviews { get; set; }

            [NotMapped]
            public bool hasReviews = false;

            [NotMapped]
            public double? AvgRating
            {
             get { return ReviewHandler.AggregateRatings(Reviews); }
            // set { AvgRating = value; }

            //get;set;
            }

            [NotMapped]
            public string Address
            {
                get
                {
                    return Street1 + " " + Street2 + " ," + City + " ," + State + " ," + Country + " ," + Zipcode;
                }

            }

            public DateTime Created { get; set; }
            public DateTime? Modified { get; set; }

            public void DisplayRestaurantDetails()
        {
            Console.WriteLine(RestaurantName);
            Console.WriteLine(FoodType);
            if (AvgRating == 0)
            {
                Console.WriteLine("No Reviews Yet");
            } else
            {
                Console.WriteLine(AvgRating);
            }
            Console.WriteLine(Phone);
            Console.WriteLine(Address);
        }
        }

    
    }


