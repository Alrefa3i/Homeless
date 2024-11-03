using System.ComponentModel.DataAnnotations;

namespace HomeLess.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<product> Products { get; set; } = new List<product>();
    }
}
