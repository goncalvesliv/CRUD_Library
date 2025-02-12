using Microsoft.EntityFrameworkCore;
using WebAPI_Library.Models;
namespace WebAPI_Library.Data
{
    public class BookContext: DbContext
    {
        public DbSet<Book> Library {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString: "Data Source = book.sqlite");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
