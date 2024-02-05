using Microsoft.EntityFrameworkCore;
using MyLibrary.Domain.Models;
using System.Reflection.Metadata;

namespace MyLibrary.Inrastructure
{
    public class MyLibraryDb : DbContext, IMyLibraryDb
    {
        public MyLibraryDb(DbContextOptions options) : base(options) { }

        public DbSet<Book> Books { get; set; } = null!;

        public DbSet<Shelf> Shelfs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Navigation(e => e.Shelf)
                .AutoInclude();
        }
    }
}