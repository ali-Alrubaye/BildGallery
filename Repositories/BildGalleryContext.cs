using static System.Data.Entity.Database;
using System.Data.Entity;
using Repositories.Models;

namespace Repositories
{
    public class BildGalleryContext : DbContext
    {
        public BildGalleryContext() : base("Gallery_UI")
        {

        }

        public DbSet<Photo> Photos { get; set; }
        public DbSet<Album> Albums { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            SetInitializer<BildGalleryContext>(new DropCreateDatabaseIfModelChanges<BildGalleryContext>());
        }
    }
}
