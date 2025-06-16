using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MothAphotheaShopAPI
{
    public class Contraindication
    {
        public Guid Id { get; set; } = new Guid();


        [Required]
        public string Name { get; set; }


        [Required]
        public string Description { get; set; }


        [JsonIgnore]
        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();


        [JsonIgnore]
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
