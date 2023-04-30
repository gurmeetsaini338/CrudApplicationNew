using CrudApplication.Data_Context;
using CrudApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudApplication.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationContext _context;
        public EmployeesController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result = _context.EmpModels.ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(EmpModel emp)
        {
            if(ModelState.IsValid) 
            {
                var empModel = new EmpModel()
                {
                    Name=emp.Name,
                    City=emp.City,  
                    State=emp.State,
                    Salary=emp.Salary
                };
                _context.EmpModels.Add(empModel);
                _context.SaveChanges();
                TempData["error"] = "Record Saved!";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["message"] = "Empty field Cen't Submit";   
                return View(emp);
            }
            return View();
        }
        [HttpGet]
        public IActionResult EditEmployee(int id)
        {
            var emp = _context.EmpModels.SingleOrDefault(e => e.Id == id);
            var result = new EmpModel()
            {
                Name = emp.Name,
                City = emp.City,
                State = emp.State,
                Salary = emp.Salary
            };
             return View(result);
        }
        [HttpPost]  
        public IActionResult EditEmployee(EmpModel model)
        {
            var emp = new EmpModel()
            {
                Id = model.Id,
                Name = model.Name,
                City = model.City,
                State = model.State,
                Salary = model.Salary
            };
            _context.EmpModels.Update(emp);
            _context.SaveChanges();
            TempData["error"] = "Record Updated";
            return RedirectToAction("Index");
        }
        public IActionResult DeleteEmployee(int id)
        {
            var emp = _context.EmpModels.SingleOrDefault(e => e.Id == id);
            _context.EmpModels.Remove(emp);
            _context.SaveChanges();
            TempData["error"] = "Record Deleted";
            return RedirectToAction("Index");
        }
    }
}
