using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MothAphotheaShopAPI
{
    public class IngredientCreateDTO
    {
        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }


        [Required]
        [JsonPropertyName("type")]
        public Guid TypeId { get; set; }


        [JsonPropertyName("scientific_name")]
        public string ScientificName { get; set; }


        [JsonPropertyName("description")]
        public string Description { get; set; }


        public List<Guid> ActiveCompoundsIds { get; set; } = new List<Guid>();


        public List<Guid> AromasIds { get; set; } = new List<Guid>();


        public List<Guid> TexturesIds { get; set; } = new List<Guid>();


        public List<Guid> FlavorsIds { get; set; } = new List<Guid>();


        public List<Guid> EffectsIds { get; set; } = new List<Guid>();


        public List<Guid> ContraindicationingsIds { get; set; } = new List<Guid>();
    }
}
