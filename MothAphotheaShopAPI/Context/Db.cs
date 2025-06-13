using Microsoft.EntityFrameworkCore;

namespace MothAphotheaShopAPI
{
    public class Db : DbContext
    {
        public Db(DbContextOptions<Db> options) : base(options)
        {
        }

        public DbSet<ActiveCompound> ActiveCompounds { get; set; }

        public DbSet<Aroma> Aromas { get; set; }

        public DbSet<Contraindication> Contraindications { get; set; } 

        public DbSet<Effect> Effects { get; set; }

        public DbSet<FlavorNote> FlavorNotes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<IngredientType> IngredientTypes { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductType> productTypes { get; set; }

        public DbSet<Texture> Textures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Db).Assembly);
        }
    }
}
