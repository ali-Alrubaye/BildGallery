using System.Data.Entity;
using Repositories.Models;
using static System.Data.Entity.Database;

namespace Repositories
{
    public class BildGalleryContext : DbContext
    {
        public BildGalleryContext() : base("Gallery")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Photo> Photos { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            SetInitializer(new DropCreateDatabaseIfModelChanges<BildGalleryContext>());
        }
    }
}