
using bookstore.Data;
using bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bookstore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly BookstoreContext _context;

    public BooksController(BookstoreContext context)
    {
        _context = context;
    }

    // 1. Sort by Publisher, Author Last Name,
    // Author First Name, and Title.
    [HttpGet("sorted-by-publisher")]
    public async Task<IActionResult> GetBooksSortedByPublisher()
    {
        var books = await _context.Books
            .OrderBy(b => b.Publisher)
            .ThenBy(b => b.AuthorLastName)
            .ThenBy(b => b.AuthorFirstName)
            .ThenBy(b => b.Title)
            .ToListAsync();

        return Ok(books);
    }

    // 2. Sort by Author Last Name, Author First Name,
    // and Title.
    [HttpGet("sorted-by-author")]
    public async Task<IActionResult> GetBooksSortedByAuthor()
    {
        var books = await _context.Books
            .OrderBy(b => b.AuthorLastName)
            .ThenBy(b => b.AuthorFirstName)
            .ThenBy(b => b.Title)
            .ToListAsync();

        return Ok(books);
    }

    // 3. Calculate the total price of all books.
    [HttpGet("total-price")]
    public async Task<IActionResult> GetTotalPrice()
    {
        var total = await _context.Books
            .SumAsync(b => (decimal?)b.Price) ?? 0m;

        return Ok(new { TotalPrice = total });
    }

    [HttpPost]
    public async Task<IActionResult> AddBook(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return Ok(book);

    }
    [HttpPost("bulk")]
    public async Task<IActionResult> BulkAddBooks(
       [FromBody] List<Book> books)
    {
        if (books == null || books.Count == 0)
        {
            return BadRequest("Please provide at least one book.");
        }

        await _context.Books.AddRangeAsync(books);
        await _context.SaveChangesAsync();

        return Ok(new
        {
            Message = "Books saved successfully.",
            books.Count
        });


    }
  
}