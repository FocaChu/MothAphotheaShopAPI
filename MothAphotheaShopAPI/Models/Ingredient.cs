using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MothAphotheaShopAPI
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class Ingredient
    {
        public int Id { get; set; }

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
        [JsonPropertyName("active_compounds")]
        public ICollection<ActiveCompound> ActiveCompounds { get; set; } = new List<ActiveCompound>();

        [JsonIgnore]
        [JsonPropertyName("aromas")]
        public ICollection<Aroma> Aromas { get; set; } = new List<Aroma>();


        [JsonIgnore]
        [JsonPropertyName("textures")]
        public ICollection<Texture> Textures { get; set; } = new List<Texture>();


        [JsonIgnore]
        [JsonPropertyName("flavor_profile")]
        public ICollection<FlavorNote> FlavorProfile { get; set; } = new List<FlavorNote>();


        [JsonIgnore]
        [JsonPropertyName("effects")]
        public ICollection<Effect> Effects { get; set; } = new List<Effect>();


        [JsonIgnore]
        [JsonPropertyName("warnings")]
        public ICollection<Contraindication> Warnings { get; set; } = new List<Contraindication>();
    }


}
