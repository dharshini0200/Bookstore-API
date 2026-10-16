using bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace bookstore.Data;

public class BookstoreContext : DbContext
{
    public BookstoreContext(DbContextOptions<BookstoreContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books => Set<Book>();
}