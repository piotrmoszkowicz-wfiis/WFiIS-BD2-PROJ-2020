using Newtonsoft.Json;

namespace ProductSearchTests.Models
{
    public class ProductResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("products_name")]
        public string ProductsName { get; set; }
        [JsonProperty("products_description")]
        public string ProductsDescription { get; set; }
        [JsonProperty("products_price")]
        public float ProductsPrice { get; set; }
    }
}