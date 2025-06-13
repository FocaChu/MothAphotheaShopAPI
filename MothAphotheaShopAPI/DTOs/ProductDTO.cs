using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MothAphotheaShopAPI
{
    public class ProductDTO
    {
        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }


        [Required]
        [JsonPropertyName("type")]
        public ProductType Type { get; set; }


        [Required]
        [JsonPropertyName("price")]
        public double Price { get; set; }


        [Required]
        [JsonPropertyName("origin")]
        public string Origin { get; set; }


        [Required]
        [JsonPropertyName("caffeine_level")]
        public CaffeineLevel CaffeineLevel { get; set; }


        [JsonPropertyName("preparation_instructions")]
        public string Preparation { get; set; }


        public List<int> IngridientsIds { get; set; } = new List<int>();


        public List<int> EffectsIds { get; set; } = new List<int>();


        public List<int> FlavorsIds { get; set; } = new List<int>();


        public List<int> WarningsIds { get; set; } = new List<int>();
    }
}
