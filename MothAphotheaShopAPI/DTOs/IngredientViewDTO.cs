using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MothAphotheaShopAPI
{
    public class IngredientViewDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }


        [JsonPropertyName("type")]
        public IngredientType Type { get; set; }


        [JsonPropertyName("scientific_name")]
        public string ScientificName { get; set; }


        [JsonPropertyName("description")]
        public string Description { get; set; }


        [JsonPropertyName("active_compounds")]
        public List<ActiveCompound> ActiveCompounds { get; set; } = new List<ActiveCompound>();


        [JsonPropertyName("aromas")]
        public List<Aroma> Aromas { get; set; } = new List<Aroma>();


        [JsonPropertyName("textures")]
        public List<Texture> Textures { get; set; } = new List<Texture>();


        [JsonPropertyName("flavors")]
        public List<FlavorNote> Flavors { get; set; } = new List<FlavorNote>();


        [JsonPropertyName("effects")]
        public List<Effect> Effects { get; set; } = new List<Effect>();


        [JsonPropertyName("contraindications")]
        public List<Contraindication> Contraindications { get; set; } = new List<Contraindication>();
    }
}
