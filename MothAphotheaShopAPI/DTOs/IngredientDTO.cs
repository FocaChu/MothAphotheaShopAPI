using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MothAphotheaShopAPI
{
    public class IngredientDTO
    {
        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }


        [Required]
        [JsonPropertyName("type")]
        public int TypeId { get; set; }


        [JsonPropertyName("scientific_name")]
        public string ScientificName { get; set; }


        [JsonPropertyName("description")]
        public string Description { get; set; }


        public List<int> ActiveCompoundsIds { get; set; } = new List<int>();


        public List<int> AromasIds { get; set; } = new List<int>();


        public List<int> TexturesIds { get; set; } = new List<int>();


        public List<int> FlavorsIds { get; set; } = new List<int>();


        public List<int> EffectsIds { get; set; } = new List<int>();


        public List<int> WarningsIds { get; set; } = new List<int>();
    }
}
