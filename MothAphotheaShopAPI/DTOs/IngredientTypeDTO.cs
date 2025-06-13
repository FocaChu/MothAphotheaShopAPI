using System.ComponentModel.DataAnnotations;

namespace MothAphotheaShopAPI
{
    public class IngredientTypeDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
