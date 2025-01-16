using Microsoft.AspNetCore.Authorization.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Urls.Add("http://localhost:5279");
app.Urls.Add("http://*:5279");

List<Teacher> teachers = [
    new() {Name = "Micke"},
    new() {Name = "Martin"},
    new() {Name = "Lena"},
];

List<Book> books = [
    new () {Title = "1984"},
    new () {Title = "Crime & Punishment"},
];

app.MapGet("/", GetMe);
app.MapGet("/orb", GetAlso);
app.MapGet("/micke", GetMicke);
app.MapPost("/hello", SayHello);
app.MapGet("/teachers", GetTeachers);
app.MapGet("/teacher/{n}", GetTeacher);

app.MapGet("/books", GetBooks);
app.MapGet("/book/{t}", GetBook);

app.Run();

List<Book> GetBooks()
{
    return books;
}

IResult GetBook(int t)
{
    if (t >= 0 && t < books.Count)
    {
        return Results.Ok(books[t]);
    }
    else
    {
        return Results.NotFound();
    }
}


List<Teacher> GetTeachers()
{
    return teachers;
}

IResult GetTeacher(int n)
{
    if (n >= 0 && n < teachers.Count)
    {
        return Results.Ok(teachers[n]);
    }
    else
    {
        return Results.NotFound();
    }
}


static void SayHello(string message)
{
    Console.WriteLine(message);
}

static Teacher GetMicke ()
{
    Teacher micke = new() { Name = "Micke" };
    return micke;
}

static string GetAlso ()
{
    return "Hi, orb!";
}

static string GetMe ()
{
    return "Hello, World!";
}

// http://10.151.172.119:5227/hello?message=...