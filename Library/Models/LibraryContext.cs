using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Library.Models
{
  public class LibraryContext : IdentityDbContext<LibrarianUser>
  {
    public virtual DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<AuthorBook> AuthorBook { get; set; }
    
    public DbSet<Patron> Patrons { get; set; }
    public DbSet<Copy> Copies { get; set; }

    public LibraryContext(DbContextOptions options) : base(options) { }
  }
}