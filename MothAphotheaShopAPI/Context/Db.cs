using Microsoft.EntityFrameworkCore;

namespace MothAphotheaShopAPI
{
    public class Db : DbContext
    {
        public Db(DbContextOptions<Db> options) : base(options)
        {
        }

        public DbSet<Aroma> Aromas { get; set; }

        public DbSet<Contraindication> Contraindications { get; set; } 

        public DbSet<Effect> Effects { get; set; }

        public DbSet<FlavorNote> FlavorNotes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<IngredientType> IngredientTypes { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<Texture> Textures { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ingredient ↔️ Aroma (Many-to-Many)
            modelBuilder.Entity<Ingredient>()
                .HasMany(i => i.Aromas)
                .WithMany(a => a.Ingredients);

            // Ingredient ↔️ Texture
            modelBuilder.Entity<Ingredient>()
                .HasMany(i => i.Textures)
                .WithMany(t => t.Ingredients);

            // Ingredient ↔️ FlavorNote
            modelBuilder.Entity<Ingredient>()
                .HasMany(i => i.FlavorNotes)
                .WithMany(f => f.Ingredients);

            // Ingredient ↔️ Effect
            modelBuilder.Entity<Ingredient>()
                .HasMany(i => i.Effects)
                .WithMany(e => e.Ingredients);

            // Ingredient ↔️ Contraindication
            modelBuilder.Entity<Ingredient>()
                .HasMany(i => i.Contraindications)
                .WithMany(c => c.Ingredients);

            // Product ↔️ Ingredient (Many-to-Many)
            modelBuilder.Entity<Product>()
                .HasMany(p => p.IngredientList)
                .WithMany(i => i.Products);


            // Product ↔️ Aroma
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Aromas)
                .WithMany(a => a.Products);

            // Product ↔️ Texture
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Textures)
                .WithMany(t => t.Products);

            // Product ↔️ Effect
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Effects)
                .WithMany(e => e.Products);

            // Product ↔️ FlavorNote
            modelBuilder.Entity<Product>()
                .HasMany(p => p.FlavorNotes)
                .WithMany(fn => fn.Products);

            // Product ↔️ Contraindication
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Contraindications)
                .WithMany(c => c.Products);
        }

    }
}
