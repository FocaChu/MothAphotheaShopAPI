using System.ComponentModel.DataAnnotations;

namespace MothAphotheaShopAPI
{
    public class FlavorNoteDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
