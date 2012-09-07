using System.Web.Mvc;
using WinDbgDemo.Models;

namespace WinDbgDemo.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            // Best practice: controllers should be as thin as possible.
            // Move ALL your logic to the ViewModel or whatever provides its data.
            return View(new DemoViewModel());

            // In a more complex scenario you might supply an ID to the constructor to get a specific object:
            // // GET: /Home/(id)
            // public ActionResult Index(int id)
            // {
            //     return View(new DemoViewModel(id));
            // }
        }

        //
        // POST: /Save/
        [HttpPost]
        public ActionResult Save(DemoViewModel viewModel)
        {
            // POST-save-redirect-GET pattern.
            // Not a best practice but leads to cleaner controllers.
            // Also cleaner UX: no form resubmission warnings.
            // The model binder already populated the DemoViewModel for us, which did the "save" (it saved the favourite colours to the static variable).

            // We might do some extra work in a more complex secenario.
            // eg. viewModel.SaveToId(Session["id"])
            return RedirectToAction("Index");
        }
    }
}
