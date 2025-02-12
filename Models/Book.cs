namespace WebAPI_Library.Models
{
    public class Book
    {
        public Book(string title, string author, bool available, int year)
        {
            Title = title; Author = author; Year = year;
            Available = available; Id = Guid.NewGuid();
        }
        public Guid Id { get; init; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; }
        public int Year { get; set; }
        public bool Available { get; set; }

        public void UpdateBook(BookRequest req)
        {
            Title = req.title;
            Author = req.author;
            Year = req.year;
            Available = req.available;
        }
    }
}
