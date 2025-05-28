using BooksApi.Models;
using BooksApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly BookService bookService;
      public BookController(BookService book)
        {
            this.bookService = book;
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult AddBook(Books book)
        {
            this.bookService.AddBook(book);
            return Ok("book created");
        }

        [HttpGet]
        [Route("GetAll")]

        public ActionResult GetAllBook()
        {
            return Ok(this.bookService.getAll());
        }

        [HttpGet]
        [Route("GetById")]

        public ActionResult getByIdBook(int id)
        {
            var ispresent=this.bookService.getById(id);
            if (ispresent!=null) { return Ok(ispresent); }
            return NotFound("Book not found");
        }

        [HttpDelete]
        [Route("Delete")]

        public ActionResult DeleteBook(int id)
        {
            bool delete = this.bookService.DeleteBook(id);
            if (delete)
            {
                return Ok("book is deleted");
            }
            else
            {
                return NotFound("Book not found");
            }
        }

        [HttpPost]
        [Route("update")]

        public ActionResult UpdateBook(int id, Books book)
        {
            bool bookexists = this.bookService.UpdateBook(id, book);
            if (!bookexists) { return NotFound("book not found"); }
            else { return Ok("book updated"); }
        }
    }
}
