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
        [JsonPropertyName("typeId")]
        public Guid TypeId { get; set; }


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


        public List<Guid> IngridientsIds { get; set; } = new List<Guid>();


        public List<Guid> AromasIds { get; set; } = new List<Guid>();


        public List<Guid> TexturesIds { get; set; } = new List<Guid>();


        public List<Guid> EffectsIds { get; set; } = new List<Guid>();


        public List<Guid> FlavorsIds { get; set; } = new List<Guid>();


        public List<Guid> ContraindicationsIds { get; set; } = new List<Guid>();
    }
}
