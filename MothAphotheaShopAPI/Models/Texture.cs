namespace MothAphotheaShopAPI
{
    public class Texture
    {
        public int Id { get; set; }


        public string Name { get; set; }


        public string Description { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
