namespace BookApi.Models
{
    public class BookRequest
    {
        public string SortBy { get; set; }= "Title";
        public string SortDirection { get; set; } = "asc";

        public string Search { get; set; } = string.Empty;

        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 0;
    }
}
