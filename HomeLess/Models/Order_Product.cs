using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeLess.Models
{
    [Table("Order_Products")]
    public class Order_Product
    {
        [Key]
        [Column(Order = 0)]
        public int OrderId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ProductId { get; set; }

        public int Quantity { get; set; }
        public float Price { get; set; }

        public Order Order { get; set; }
        public product Product { get; set; }
    }
}
