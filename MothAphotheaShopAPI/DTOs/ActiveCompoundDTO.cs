using System.ComponentModel.DataAnnotations;

namespace MothAphotheaShopAPI
{
    public class ActiveCompoundDTO
    {
        [Required]
        public string Name { get; set; }


        [Required]
        public string Description { get; set; }


        [Required]
        public string ChemicalFormula { get; set; }
    }
}
