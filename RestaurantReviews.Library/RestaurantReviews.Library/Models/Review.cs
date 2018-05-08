using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;


namespace RestaurantReviews.Library.Models
{
        public class Review : IEntity
        {
            [Column("Id")]
            public int ReviewId { get; set; }
            public string ReviewerName { get; set; }
            [Required]
            [Range(1.0, 5.0, ErrorMessage = "Rating should be between 1 and 5")]
            public double Rating { get; set; }
            [StringLength(200, ErrorMessage = "Comment should not be exceed more than 200 characters")]
            [DataType(DataType.MultilineText)]
            public string Description { get; set; }

            public int RestaurantId { get; set; }
            public virtual Restaurant Restaurant { get; set; }
            

            public DateTime Created { get; set; }
            public DateTime? Modified { get; set; }


        public void DisplayReview()
        {
            Console.Write(ReviewerName);
            Console.WriteLine(Created);
            Console.WriteLine("Rating " + Rating);
            Console.WriteLine(Description);
        }

    }


    }
