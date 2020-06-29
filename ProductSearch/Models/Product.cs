using System.ComponentModel.DataAnnotations;

namespace ProductSearch.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        
        [Required]
        public string products_name { get; set; }
        
        [Required]
        public string products_description { get; set; }
        
        [Required]
        public float products_price { get; set; }
    }
}