using BookManager.Data;
using BookManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BookManagerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }

      
        [HttpPost]
        [Route("/addBook")]
        public async Task AddBook(Book book)
        {
            _context.BooksData.Add(book);
            await _context.SaveChangesAsync();
        }

        [HttpGet]
        [Route("/getBookById")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var book = await _context.BooksData.FindAsync(id);
            if (book == null) return NotFound();
            return book;
        }

        [HttpDelete]
        [Route("/deleteBookById")]

        public async Task<ActionResult> DeleteBookById(int id)
        {
            var findbook = await _context.BooksData.FindAsync(id);
            if (findbook == null)
            {
                return NotFound();
            }
            else
            {
                _context.BooksData.Remove(findbook);
                await _context.SaveChangesAsync();
                return Ok("book deleted");
            }
        }

        [HttpPost]
        [Route("updateBookById")]
        public async Task<ActionResult<Book>> UpdateBookByID(int id, Book book)
        {
            var findbook = await _context.BooksData.FindAsync(id);
            if (findbook == null)
            {
                return NotFound();
            }
            else
            {
                findbook.Title = book.Title;
                findbook.Author = book.Author;
                findbook.Description = book.Description;
                await _context.SaveChangesAsync();
                return Ok(findbook);

            }
        }
    }
}
