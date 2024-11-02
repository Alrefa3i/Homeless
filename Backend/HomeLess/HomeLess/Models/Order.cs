using System.ComponentModel.DataAnnotations;

namespace HomeLess.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime Seles_date { get; set; } = DateTime.Now;
        public float total_amount { get; set; }

        public string status { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<Order_Product> Order_Product { get; set; } = new List<Order_Product>();


    }
}
