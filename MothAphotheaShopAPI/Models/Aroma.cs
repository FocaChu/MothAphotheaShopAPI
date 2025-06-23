using System.Text.Json.Serialization;

namespace MothAphotheaShopAPI
{
    public class Aroma
    {
        public Guid Id { get; set; } = new Guid();


        public string Name { get; set; }


        [JsonIgnore]
        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();


        [JsonIgnore]
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
