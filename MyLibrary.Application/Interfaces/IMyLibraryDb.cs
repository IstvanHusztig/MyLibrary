using Microsoft.EntityFrameworkCore;
using MyLibrary.Domain.Models;

namespace MyLibrary.Inrastructure
{
    public interface IMyLibraryDb
    {
        DbSet<Book> Books { get; set; }
        DbSet<Shelf> Shelfs { get; set; }

        int SaveChanges();
    }
}