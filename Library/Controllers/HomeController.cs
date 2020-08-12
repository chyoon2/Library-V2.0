using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Index(string searchOption, string searchString)
    {
      if (searchOption == "authors")
      {
        return RedirectToAction("Index", "Authors", new {searchQuery = searchString});
      }
      else
      {
        return RedirectToAction("Index", "Books", new {searchQuery = searchString});
      }  
    }  
  }
}