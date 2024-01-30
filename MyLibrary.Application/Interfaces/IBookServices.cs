using MyLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Interfaces
{
    public interface IBookServices
    {
        bool DeleteBook(int bookId);
        List<Book> GetBooks();
        Book GetBooksById(int bookId);
        List<Book> GetBooksByTitle(string title);
        bool RemoveBookFromShelf(int bookId);

        bool MoveBookToShelf(int bookId, int shelfId);

        Dictionary<string, List<Book>> GetBookTitlesListedByShelfs();

        bool CreateBook(Book book);

        List<Book> GetBooksThatAreOffTheShelve();
    }
}
