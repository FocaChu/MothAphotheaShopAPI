using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MothAphotheaShopAPI
{ 
    public class ProductType
    {
        public Guid Id { get; set; } = new Guid();


        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }


        [JsonIgnore]
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
