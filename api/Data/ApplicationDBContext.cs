using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<User>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Tag> Tags { get; set; }

        //public DbSet<ProductTag> ProductsTags { get; set; }

        public DbSet<Lustre> Lustres {get; set;}

        public DbSet<Lamp> Lamps { get; set; }

        public DbSet<Flashlight> Flashlights { get; set; }

        public DbSet<Nightlight> Nightlights { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>()
                .HasMany(p => p.Tags)
                .WithMany(t => t.Products)
                .UsingEntity(j => j.ToTable("ProductsTagsComparer"));
                

            //many-to-many relationship; составной первичный ключ
            //builder.Entity<ProductTag>(t => t.HasKey(p => new { p.ProductId, p.TagId }));

            //builder.Entity<ProductTag>()
            //    .HasOne(e => e.Product)
            //    .WithMany(p => p.Tags)
            //    .HasForeignKey(p => p.ProductId);

            //builder.Entity<ProductTag>()
            //    .HasOne(e => e.Tag)
            //    .WithMany(t => t.ProductTags)
            //    .HasForeignKey(t => t.TagId);

            //Table-per-Type (TPT) ierarchy
            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Flashlight>().ToTable("Flashlights");
            builder.Entity<Lamp>().ToTable("Lamps");
            builder.Entity<Lustre>().ToTable("Lustres");
            builder.Entity<Nightlight>().ToTable("Nightlights");

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}