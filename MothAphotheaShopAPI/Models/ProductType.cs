using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MothAphotheaShopAPI
{ 
    public class ProductType
    {
        public int Id { get; set; }


        [Required]
        public string Name { get; set; }


        [JsonIgnore]
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
