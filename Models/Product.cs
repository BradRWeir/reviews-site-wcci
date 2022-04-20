using System;
using System.Collections.Generic;
using System.Linq;

namespace template_csharp_reviews_site.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public string Brand { get; set; }

        public string OSVer { get; set; }

        public string Processor { get; set; }

        public string RamSize { get; set; }

        public string Storage { get; set; }

        public double Price { get; set; }

        public DateTime ReleaseDate { get; set; }

        public virtual List<Review> Reviews { get; set; }

        public string Picture {get; set; }

        public virtual string PictureOrDefault
        {
            get => String.IsNullOrEmpty(Picture) ? "/images/default_phone.jpg" : Picture;
        }

        public virtual double AverageReviewRating
        {
            get
            {
                return Reviews.Count > 0 ? Reviews.Select(r => r.Rating).Average() : 0;
            }
        }

        public virtual string Name
        {
            get
            {
                return $"{Brand} {Model}";
            }
        }
    }
}
