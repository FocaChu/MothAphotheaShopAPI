using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MothAphotheaShopAPI
{
    public class IngredientType
    {
        public Guid Id { get; set; } = new Guid();


        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }


        [JsonIgnore]
        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }

}
