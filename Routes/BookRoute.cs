using Microsoft.EntityFrameworkCore;
using WebAPI_Library.Data;
using WebAPI_Library.Models;

namespace WebAPI_Library.Routes
{
    public static class BookRoute
    {
        public static void BookRoutes(this WebApplication app)
        {
            var route = app.MapGroup("book");

            route.MapPost(pattern: "",
             async (BookRequest req, BookContext context) =>
            {
                var book = new Book(req.title, req.author, req.available, req.year);
                await context.AddAsync(book);
                await context.SaveChangesAsync();
            });

            route.MapGet("", async (BookContext context) =>
            {
                var library = await context.Library.ToListAsync();
                var response = new
                {
                    dados = library
                };

                return Results.Ok(response);
            });

            route.MapGet("{id:guid}", async (Guid id, BookContext context) =>
            {
                var book = await context.Library.FirstOrDefaultAsync(x => x.Id == id);

                if (book == null)
                {
                    return Results.NotFound(new { message = "Livro não encontrado" });
                }

                return Results.Ok(new { dados = book });
            });


            route.MapPut("{id:guid}",
               async (Guid id, BookRequest req, BookContext context) =>
                {
                    var book = await context.Library.FirstOrDefaultAsync(x => x.Id == id);

                    if (book == null)
                        return Results.NotFound();

                    book.UpdateBook(req);

                    await context.SaveChangesAsync();
                    return Results.Ok(book);
                });

            route.MapDelete("{id:guid}", async (Guid id, BookContext context) =>
            {
                var book = await context.Library.FirstOrDefaultAsync(x => x.Id == id);

                if (book == null)
                {
                    return Results.NotFound();
                }

                context.Library.Remove(book);

                await context.SaveChangesAsync();

                return Results.Ok($"Livro com id {id} deletado com sucesso.");
            });

        }
    }
}
