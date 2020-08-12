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

    [HttpPost]
    public ActionResult Create(int BookId, int Copies)
    {
      for (int i=0; i< Copies; i++)
      {
        Copy newCopy = new Copy();
        newCopy.BookId = BookId;
        _db.Copies.Add(newCopy);
        _db.SaveChanges();
      }
      return RedirectToAction("Details", "Books", new {id = BookId});
    }

    [HttpPost]
    public ActionResult IsCheckedOut(Copy copy)
    { 
      // var something = _db.Copies.FirstOrDefault(copy => copy.CopyId = Id);
      // something.Checkout = false;
      // _db.Entry(something).State = EntityState.Modified;
      // _db.SaveChanges();
      // return RedirectToAction("Index");
      //this.Copies.CheckOut =
      //false is lowercase
      //return RedirectToAction("Details", "Books", new {id = BookId});

      _db.Entry(copy).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index", new { id = item.ItemId});

     
    }
  }
}
  // @using(Html.BeginForm("MarkComplete", "Items"))
  //   {
  //     @Html.HiddenFor(model => model.ItemId)
  //     @Html.HiddenFor(model => model.Description)
  //     <p>Complete:</p>@Html.CheckBoxFor(model => model.Complete)
  //     <input type="submit" value="Save" />
  //   } 