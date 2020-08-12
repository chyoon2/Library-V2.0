using System.Collections.Generic;

namespace Library.Models
{
  public class Book
  {
    public Book()
    {
      this.Authors = new HashSet<AuthorBook>();
      this.Copies = new HashSet<Copy>();//new is it Copy or Checkouts
    }
    public int BookId {get; set;}
    public string BookName {get; set;}
    public virtual LibrarianUser User { get; set; } 
    
    public ICollection<AuthorBook> Authors { get;}
    public virtual ICollection<Copy> Copies { get; } 
  }
}