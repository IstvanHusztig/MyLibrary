using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using MyLibrary.Application.Services;
using MyLibrary.Domain.Models;
using MyLibrary.Inrastructure;
using Xunit;

public class LibraryServiceTests
{
    [Fact]
    public void GetBooksThatAreOffTheShelf_ReturnsBooksWithNoShelfAssigned()
    {
        // Arrange

        var books = new List<Book>{
            new Book { Shelf = new Shelf { Id = 1, Name = "A0" } },
            new Book { Shelf = null } };

        var mockBooks = new Mock<IQueryable<Book>>();
        mockBooks.Setup(m => m.ToList()).Returns(books);

        var mockContext = new Mock<IMyLibraryDb>();
        mockContext.Setup(c => c.Books).Returns((DbSet<Book>)mockBooks.Object);

        var service = new BookServices(mockContext.Object);

        // Act
        var booksOffShelf = service.GetBooksThatAreOffTheShelve();

        // Assert
        booksOffShelf.Should().Contain(b => b.Shelf == null);
        booksOffShelf.Should().NotContain(bookOnShelf); 
    }
}
