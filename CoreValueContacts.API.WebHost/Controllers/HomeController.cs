using System.Web.Mvc;

namespace CoreValueContacts.API.WebHost.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}