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
  public class CopiesController : Controller
  {
    private readonly LibraryContext _db;
    private readonly UserManager<LibrarianUser> _userManager;

    public CopiesController(UserManager<LibrarianUser> userManager, LibraryContext db)
    {
      _userManager = userManager;
      _db = db;
    }
  
  public ActionResult Index(string searchString = null)
  {
    if (searchString == null)
    {
      ViewBag.Dumb = _db.Books.ToList();
      return View();
    }
    else 
    {
      ViewBag.Dumb = _db.Books.Where(book => book.BookName.ToLower().Contains(searchString)).ToList();
      return View();
    }
  }
     public ActionResult Create(int id)
    {
      ViewBag.BookDetails = _db.Books.FirstOrDefault(book => book.BookId == id);
      return View();
    }

    // [HttpPost]
    // public ActionResult Create()
    // {
    //   // _db.Copy.Add(student);
    //   return view();
    // }

    //
  }
}