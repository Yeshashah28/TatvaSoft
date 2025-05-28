using BooksApi.Models;
namespace BooksApi.Services
{
    public class BookService
    {
        private List<Books> _books;
        public BookService() {
            _books = new List<Books>();
        }

        public void AddBook(Books book)
        {
            _books.Add(book);
        }

        public List<Books> getAll()
        {
            return _books;
        }

        public Books? getById(int id)
        {
            return _books.Find(x => x.Id == id);
        }

        public bool DeleteBook(int id)
        {
            var booktodelete = _books.Find(x => x.Id == id);
            if (booktodelete == null) { return false; }
            _books.Remove(booktodelete);
            return true;
        }

        public bool UpdateBook(int id, Books updateddetails)
        {
            var bookexists = _books.Find(x => x.Id == id);
            if (bookexists==null) { return false; }
            bookexists.Id = updateddetails.Id;
            bookexists.Title = updateddetails.Title;
            bookexists.Description = updateddetails.Description;
            bookexists.Author = updateddetails.Author;
            return true;


        }
    }

}
