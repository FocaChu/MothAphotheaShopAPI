using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MothAphotheaShopAPI
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class Ingredient
    {
        public Guid Id { get; set; }

        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }


        [Required]
        [JsonPropertyName("type")]
        public IngredientType Type { get; set; }  


        [JsonPropertyName("scientific_name")]
        public string ScientificName { get; set; }


        [JsonPropertyName("description")]
        public string Description { get; set; }


        [JsonPropertyName("aromas")]
        public ICollection<Aroma> Aromas { get; set; } = new List<Aroma>();


        [JsonPropertyName("textures")]
        public ICollection<Texture> Textures { get; set; } = new List<Texture>();


        [JsonPropertyName("flavor_profile")]
        public ICollection<FlavorNote> FlavorProfile { get; set; } = new List<FlavorNote>();


        [JsonPropertyName("effects")]
        public ICollection<Effect> Effects { get; set; } = new List<Effect>();


        [JsonPropertyName("warnings")]
        public ICollection<Contraindication> Warnings { get; set; } = new List<Contraindication>();
    }


}
