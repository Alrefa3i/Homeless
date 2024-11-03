using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HomeLess.Models
{
    public class Comment
    {

        [Key] // This attribute specifies that this property is the primary key
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }=DateTime.Now;
        public float Rating { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ProductId { get; set; }
        public product Product { get; set; }
    }
}
