using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Library.Controllers
{
  [Authorize]
  public class BooksController : Controller
  {
    private readonly LibraryContext _db;
    private readonly UserManager<LibrarianUser> _userManager;
    public BooksController(UserManager<LibrarianUser> userManager, LibraryContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public ActionResult Index(string searchQuery =null)
    {
      if (searchQuery == null)
      {
        var model = _db.Books.ToList();
        return View(model);
      }
      else{ 
        var model = _db.Books.Where(book => book.BookName.ToLower().Contains(searchQuery.ToLower())).ToList();
        return View(model);
      }
    }
    
    public ActionResult Edit(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(books => books.BookId == id);
      ViewBag.AuthorId = new SelectList(_db.Authors, "AuthorId", "AuthorName");
      return View(thisBook);
    } 

    [HttpPost]
    public ActionResult Edit(Book book, int AuthorId)
    {
      if(AuthorId !=0)  
      {
        _db.AuthorBook.Add(new AuthorBook() {AuthorId = AuthorId, BookId = book.BookId});
      } 
        _db.Entry(book).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    public ActionResult Create()
    {
      ViewBag.AuthorId = new SelectList(_db.Authors, "AuthorId", "AuthorName");
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Book book, int AuthorId)
  {
    var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    var currentUser = await _userManager.FindByIdAsync(userId);
    book.User = currentUser;
    _db.Books.Add(book);
    if (AuthorId != 0)
    {
        _db.AuthorBook.Add(new AuthorBook() { AuthorId = AuthorId, BookId = book.BookId });
    }
    _db.SaveChanges();
    return RedirectToAction("Index");
}

    public ActionResult Details(int id)
    {
      var thisBook = _db.Books
        .Include(book => book.Authors)// join enitities of authorbook.
        .ThenInclude(join => join.Author)
        .FirstOrDefault(book => book.BookId == id);
      return View(thisBook);
    }

    public ActionResult AddAuthor(int id)
    {
    var thisBook = _db.Books.FirstOrDefault(books => books.BookId == id);
    ViewBag.AuthorId = new SelectList(_db.Authors, "AuthorId", "AuthorName");
    return View(thisBook);
    }

    [HttpPost]
    public ActionResult AddAuthor(Book book, int AuthorId)
    {
      if (AuthorId != 0)
        {
        _db.AuthorBook.Add(new AuthorBook() { AuthorId = AuthorId, BookId = book.BookId });
        }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(books => books.BookId == id);
      return View(thisBook);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(books => books.BookId == id);
      _db.Books.Remove(thisBook);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult DeleteAuthor(int joinId)
    {
      var joinEntry = _db.AuthorBook.FirstOrDefault(entry => entry.AuthorBookId == joinId);
      _db.AuthorBook.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult MarkComplete(Book book)
    {
      _db.Entry(book).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index", new { id = book.BookId});
    }
  }
}