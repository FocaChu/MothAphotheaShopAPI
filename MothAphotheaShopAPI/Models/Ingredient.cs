using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MothAphotheaShopAPI
{

    public class Ingredient
    {
        public Guid Id { get; set; } = new Guid();

        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }


        [JsonIgnore]
        [JsonPropertyName("type")]
        public IngredientType Type { get; set; }  


        [JsonPropertyName("scientific_name")]
        public string ScientificName { get; set; }


        [JsonPropertyName("description")]
        public string Description { get; set; }


        [JsonIgnore]
        [JsonPropertyName("aromas")]
        public ICollection<Aroma> Aromas { get; set; } = new List<Aroma>();


        [JsonIgnore]
        [JsonPropertyName("textures")]
        public ICollection<Texture> Textures { get; set; } = new List<Texture>();


        [JsonIgnore]
        [JsonPropertyName("flavor_notes")]
        public ICollection<FlavorNote> FlavorNotes { get; set; } = new List<FlavorNote>();


        [JsonIgnore]
        [JsonPropertyName("effects")]
        public ICollection<Effect> Effects { get; set; } = new List<Effect>();


        [JsonIgnore]
        [JsonPropertyName("warnings")]
        public ICollection<Contraindication> Contraindications { get; set; } = new List<Contraindication>();

        [JsonIgnore]
        [JsonPropertyName("products")]
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }


}
