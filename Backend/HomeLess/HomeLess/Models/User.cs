using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.ComponentModel.DataAnnotations;

namespace HomeLess.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Testimonial> Testimonials { get; set; } = new List<Testimonial>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
 