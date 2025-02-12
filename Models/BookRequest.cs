namespace WebAPI_Library.Models
{
    public record BookRequest(string title, string author, bool available, int year);
}
