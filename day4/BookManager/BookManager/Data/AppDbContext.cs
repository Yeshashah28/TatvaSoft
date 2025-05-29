using Microsoft.EntityFrameworkCore;
using BookManager.Models;

namespace BookManager.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> BooksData { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}
