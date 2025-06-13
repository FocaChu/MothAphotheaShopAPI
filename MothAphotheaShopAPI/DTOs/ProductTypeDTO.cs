using System.ComponentModel.DataAnnotations;

namespace MothAphotheaShopAPI
{
    public class ProductTypeDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
