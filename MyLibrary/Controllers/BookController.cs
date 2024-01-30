using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.Application.Interfaces;
using MyLibrary.Domain.InputModels;
using MyLibrary.Domain.Models;

namespace MyLibrary.Controllers
{
    [ApiController]
    [EnableCors]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        IBookServices _bookServices;

        public BookController(IBookServices bookServices)
        {
            _bookServices= bookServices;
        }

        [HttpGet("GetAllBooks")]
        public IActionResult GetBooks()
        {
            var success = _bookServices.GetBooks();

            return Ok(success);
        }

        [HttpGet("GetBookByTitle")]
        public IActionResult GetBookByTitle(string bookTitle)
        {
            return Ok(_bookServices.GetBooksByTitle(bookTitle));
        }

        [HttpGet("GetBooksThatAreOffTheShelve")]
        public IActionResult GetBooksThatAreOffTheShelve()
        {
            return Ok(_bookServices.GetBooksThatAreOffTheShelve());
        }

        [HttpGet("GetBookTitelsByShelfs")]
        public IActionResult GetBookTitelsByShelfs()
        {
            return Ok(_bookServices.GetBookTitlesListedByShelfs());
        }

        [HttpPut("RemoveBookFromShelf")]
        public IActionResult RemoveBookFromShelf(int bookId)
        {
            var success = _bookServices.RemoveBookFromShelf(bookId);

            if (success)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut("MoveBookToShelf")]
        public IActionResult MoveBookToShelf(int bookId, int shelfId)
        {
            var success = _bookServices.MoveBookToShelf(bookId,shelfId);

            if (success)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("CreateBook")]
        public IActionResult CreateBook(BookInput book)
        {
            var success = _bookServices.CreateBook((Book)book);

            if (success)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}