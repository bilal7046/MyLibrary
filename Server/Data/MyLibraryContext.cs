using Microsoft.EntityFrameworkCore;
using Server.Entities;

namespace Server.Data
{
    public class MyLibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        public MyLibraryContext(DbContextOptions<MyLibraryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = Guid.Parse("c9e38b7c-6a8d-4dbc-b80d-9106f7581534"), Name = "Science Fiction" },
                new Category() { Id = Guid.Parse("c7c25e71-1522-443f-b8ac-a0973ee5c7c8"), Name = "Fantasy" },
                new Category() { Id = Guid.Parse("d2a3c710-ce95-4099-85e8-5e77d5dbdd2b"), Name = "Mystery" }

                );
        }
    }
}