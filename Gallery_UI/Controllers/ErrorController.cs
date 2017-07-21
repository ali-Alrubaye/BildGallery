using System.Web.Mvc;

namespace Gallery_UI.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Error()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult InternalError()
        {
            return View();
        }
    }
}