using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoqueWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}