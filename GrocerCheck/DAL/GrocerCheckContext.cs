using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using GrocerCheck.Models;

namespace GrocerCheck.DAL
{
    public class GrocerCheckContext:DbContext
    {
        public GrocerCheckContext():base("DefaultConnection")
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<ItemByQuantity> ItemsByQuantity { get; set; }
        public DbSet<ItemBySize> ItemsBySize { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Grocer> Grocers { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<User> Users { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


            modelBuilder.Entity<Item>()
                .HasMany(c => c.Brands).WithMany(i => i.Items )
                .Map(t => t.MapLeftKey("ItemID")
                .MapRightKey("BrandID")
                .ToTable("ItemBrand"));

            modelBuilder.Entity<Item>()
                .HasMany(c => c.Sizes).WithMany(i => i.Items)
                .Map(t => t.MapLeftKey("ItemID")
                .MapRightKey("SizeID")
                .ToTable("ItemSize"));
        }
    }

}