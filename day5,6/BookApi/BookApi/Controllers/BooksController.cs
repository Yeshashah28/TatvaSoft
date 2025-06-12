using BookApi.Data;
using BookApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly AppDbContext _context;

    public BookController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("/getAllBooks")]
    public async Task<IActionResult> GetAllBooks()
    {
        var books = await _context.Books.ToListAsync();
        return Ok(books);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [Route("/addBook")]
    public async Task<IActionResult> AddBook([FromBody] Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return Ok(book);
    }
    [HttpPost]
    [Route("/getBooks")]
    public async Task<ActionResult<BookDetails>> getAllBooks(BookRequest model)
    {
        var query = _context.Books.AsQueryable();

        if (!string.IsNullOrWhiteSpace(model.Search))
        {
            query = query.Where(u => u.Title.ToLower().Contains(model.Search.ToLower()));
        }

        if (!string.IsNullOrWhiteSpace(model.SortBy) && model.SortBy == "Title")
        {
            if (model.SortDirection == "asc")
                query = query.OrderBy(u => u.Title);
            else
                query = query.OrderByDescending(u => u.Title);
        }
        else if (!string.IsNullOrWhiteSpace(model.SortBy) && model.SortBy == "Author")
        {
            if (model.SortDirection == "asc")
                query = query.OrderBy(u => u.Author);
            else
                query = query.OrderByDescending(u => u.Author);
        }

        //query = query.Skip(model.PageNumber * model.PageSize).Take(model.PageSize);

        var books = await query.ToListAsync();

        var result = books.Select(u => new BookDetails
        {
            Title = u.Title,
            Author = u.Author
        }).ToList();

        return Ok(result);
    }
}

