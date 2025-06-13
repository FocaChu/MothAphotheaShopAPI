using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MothAphotheaShopAPI
{
    public class IngredientType
    {
        public int Id { get; set; }


        [Required]
        public string Name { get; set; }


        [JsonIgnore]
        ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }

}
