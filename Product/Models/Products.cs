using System.ComponentModel.DataAnnotations;

namespace Product.Models
{
    public class Products
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Prize { get; set; }
    }
}
