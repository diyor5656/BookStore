using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class AboutController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public AboutController(BookStoreContext context)
        {
            _context = context;
        }


        [HttpGet("{Id}")]
        public About Getabout(int Id)
        {
            var about = _context.Abouts.FirstOrDefault(about => about.Id == Id);
            return about;
        }


        [HttpGet]
        public List<Book> GetBooks()
        {
            var books = _context.Books.ToList();
            return books;
        }


        [HttpPost]
        public int PostBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book.Id;
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, Book book)
        {
            var existingBook = _context.Books.FirstOrDefault(b => b.Id == id);
            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Price = book.Price;
            existingBook.CategoryId = book.CategoryId;


            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public void DeleteBook([FromBody] Book book)
        {
            var updBook = _context.Books.FirstOrDefault(b => b.Title == book.Title);

            if (updBook != null)
            {
                _context.Books.Remove(updBook);
                _context.SaveChanges();
            }
        }

    }
}
