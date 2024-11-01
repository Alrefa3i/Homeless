using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace HomeLess.Models
{
    public class product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string Image { get; set; }

        public Category Category { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
