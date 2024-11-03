using System.ComponentModel.DataAnnotations;

namespace HomeLess.Models
{
    public class Testimonial
    {
        [Key]
        public int Id { get; set; }
        public string text { get; set; }
        public float Rating { get; set; }
        public DateTime date { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
