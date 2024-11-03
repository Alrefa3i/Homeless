using System.ComponentModel.DataAnnotations;

namespace HomeLess.Models
{
    public class ContactUs
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
