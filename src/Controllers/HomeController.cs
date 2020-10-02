using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Queries;

namespace TodoApp.Controllers
{
	public class HomeController : Controller
    {
        public IActionResult Index(IndexModelQuery query)
        {
            return RedirectToAction("Index", "Tasks");
        }
   }
}