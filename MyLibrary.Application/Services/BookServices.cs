using MyLibrary.Application.Interfaces;
using MyLibrary.Domain.Models;
using MyLibrary.Inrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Services
{
 

    public class BookServices : IBookServices
    {
        IMyLibraryDb _myLibraryDb;

        public BookServices(IMyLibraryDb myLibraryDb)
        {
            _myLibraryDb = myLibraryDb;
        }

        public List<Book> GetBooks()
        {
            return _myLibraryDb.Books.ToList();
        }

        public Dictionary<string,List<Book>> GetBookTitlesListedByShelfs()
        {
            var books = _myLibraryDb.Books.ToList();

            var booksByShelf= new Dictionary<string, List<Book>>();

            foreach (var book in books)
            {
                if (book.Shelf != null)
                {
                    if (booksByShelf.ContainsKey(book.Shelf.Name) == false)
                    {
                        booksByShelf.Add(book.Shelf.Name, new List<Book> { book });
                    }
                    else
                    {
                        booksByShelf[book.Shelf.Name].Add(book);
                    }
                }
            }

            return booksByShelf;
        }

        public List<Book> GetBooksByTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return new List<Book>();
            }

            try
            {
                var result = _myLibraryDb.Books.Where(b => b.Title.Contains(title));

                return result.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Book GetBooksById(int bookId)
        {
            if (bookId > 0)
            {
                try
                {
                    return _myLibraryDb.Books.Single(b => b.Id == bookId);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return new Book();
        }

        public List<Book> GetBooksThatAreOffTheShelve()
        {
            try
            {
                return _myLibraryDb.Books.Where(b => b.Shelf == null).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteBook(int bookId)
        {
            if (bookId > 0)
            {
                try
                {
                    var foundBook = GetBooksById(bookId);

                    if (foundBook != null)
                    {
                        _myLibraryDb.Books.Remove(foundBook);
                        var result = _myLibraryDb.SaveChanges();

                        return result > 0;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return false;
        }

        public bool RemoveBookFromShelf(int bookId)
        {
            if (bookId > 0)
            {
                try
                {
                    var foundBook = GetBooksById(bookId);

                    if (foundBook != null)
                    {
                        foundBook.Shelf = null;
                        var result = _myLibraryDb.SaveChanges();

                        return result > 0;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return false;
        }

        public bool MoveBookToShelf(int bookId, int shelfId)
        {
            if (bookId > 0)
            {
                try
                {
                    var foundBook = GetBooksById(bookId);

                    var shelfService = new ShelfServices(_myLibraryDb);

                    if (foundBook != null)
                    {
                        foundBook.Shelf = shelfService.GetShelfById(shelfId);
                        var result = _myLibraryDb.SaveChanges();

                        return result > 0;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return false;
        }


        public bool CreateBook(Book book)
        {
                try
                {
                _myLibraryDb.Books.Add(book);
                _myLibraryDb.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
           

            return false;
        }

    }
}
