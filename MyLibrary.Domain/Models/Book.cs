using MyLibrary.Domain.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Domain.Models
{
    public class Book
    {
        public int Id { get; set; }
        public virtual Shelf? Shelf { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string AuthorName { get; set; }

        public static explicit operator Book(BookInput v)
        {
            return new Book { Title = v.Title, AuthorName = v.AuthorName, Description = v.Description };
        }
    }
}
