using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace HomeLess.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
 