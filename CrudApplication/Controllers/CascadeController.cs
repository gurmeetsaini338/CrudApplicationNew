using CrudApplication.Data_Context;
using Microsoft.AspNetCore.Mvc;

namespace CrudApplication.Controllers
{
    public class CascadeController : Controller
    {
        private ApplicationContext _context;

        public CascadeController(ApplicationContext context) 
        { 
            _context= context;
        }
        public JsonResult Country()
        {
            var cnt=_context.Countrys.ToList();
            return new JsonResult(cnt);
        }
        public JsonResult State(int id)
        {
            var st = _context.States.Where(e=>e.Country.Id==id).ToList();
            return new JsonResult(st);
        }
        public JsonResult City(int id)
        {
            var ct = _context.Cityes.Where(e=>e.State.Id==id).ToList();
            return new JsonResult(ct);
        }
        public ActionResult CascadeDropdown() 
        {
          return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
