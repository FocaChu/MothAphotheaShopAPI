using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MothAphotheaShopAPI
{
    public class Product
    {
        public int Id { get; set; }  // Também gerado pelo banco


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


        [JsonPropertyName("ingredient_list")]
        public ICollection<Ingredient> IngredientList { get; set; } = new List<Ingredient>();


        [JsonPropertyName("aromas")]
        public ICollection<Aroma> Aromas { get; set; } = new List<Aroma>();


        [JsonPropertyName("textures")]
        public ICollection<Texture> Textures { get; set; } = new List<Texture>();


        [JsonPropertyName("effect_list")]
        public ICollection<Effect> Effects { get; set; } = new List<Effect>();


        [JsonPropertyName("flavor_notes")]
        public ICollection<FlavorNote> FlavorNotes { get; set; } = new List<FlavorNote>();


        [JsonPropertyName("contraindications")]
        public ICollection<Contraindication> Contraindications { get; set; } = new List<Contraindication>();

    }

}
