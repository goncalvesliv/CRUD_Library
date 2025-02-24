using WebAPI_Library.Data;
using WebAPI_Library.Routes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 
builder.Services.AddScoped<BookContext>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("booksApp", builder =>
    {
        builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("booksApp");

app.BookRoutes();

app.UseHttpsRedirection();


app.Run();