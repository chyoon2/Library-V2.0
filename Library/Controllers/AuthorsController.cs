using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Security.Claims;
using Library.Models;
using System.Linq;
using System;


namespace Library.Controllers
{
  [Authorize]
  public class AuthorsController : Controller
  {
    private readonly LibraryContext _db;
    private readonly UserManager<LibrarianUser> _userManager;

    public AuthorsController(UserManager<LibrarianUser> userManager, LibraryContext db)
    {
      _userManager = userManager;
      _db = db;
    }
    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userAuthors = _db.Authors.Where(entry => entry.User.Id == currentUser.Id).ToList();
      return View(userAuthors);
    }

    public ActionResult Create()
    {
      ViewBag.BookId = new SelectList(_db.Books, "BookId", "BookName");
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Author author, int BookId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      author.User = currentUser;
      _db.Authors.Add(author);
      if (BookId != 0)
      {
        _db.AuthorBook.Add(new AuthorBook() { BookId = BookId, AuthorId = author.AuthorId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisAuthor = _db.Authors
        .Include(author => author.Books)
        .ThenInclude(join => join.Book)
        .FirstOrDefault(author => author.AuthorId == id);
      return View(thisAuthor);
    }
  }
}