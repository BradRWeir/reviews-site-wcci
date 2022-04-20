using System;

namespace template_csharp_reviews_site.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public DateTime ReviewDate { get; set; }
        public string Content { get; set; }
        //5 Star rating, we can implement this as a Struct or Enum
        //For now we will let it be an int
        public int Rating { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

    }
}
