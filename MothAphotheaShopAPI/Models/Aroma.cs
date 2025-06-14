using System.Text.Json.Serialization;

namespace MothAphotheaShopAPI
{
    public class Aroma
    {
        public int Id { get; set; }


        public string Name { get; set; }


        public string Description { get; set; }


        [JsonIgnore]
        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();


        [JsonIgnore]
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
