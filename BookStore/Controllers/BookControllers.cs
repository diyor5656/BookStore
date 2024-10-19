using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public BookController(BookStoreContext context)
        {
            _context = context;
        }

        
        [HttpGet("{Id}")]
        public Book GetBook(int Id)
        {
            var book = _context.Books.FirstOrDefault(book => book.Id == Id);
            return book; 
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
    }
}
