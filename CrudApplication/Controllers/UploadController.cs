using CrudApplication.Data_Context;
using CrudApplication.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using System;
using CrudApplication.Migrations;
using CrudApplication.Models;
using Image = CrudApplication.Models.Image;

namespace CrudApplication.Controllers
{
    public class UploadController : Controller
    {
        private ApplicationContext _context;
        private IHostingEnvironment environment;

        public UploadController(ApplicationContext context ,IHostingEnvironment environment) 
        {
            _context = context;
            this.environment = environment;
        }
        [HttpGet]
        public IActionResult UploadImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UploadImage(ImageCreateModel model)
        {
            if (ModelState.IsValid) 
            {
                var path = environment.WebRootPath;
                var filePath = "Content/Image" + model.ImagePath.FileName;
                var fullPath=Path.Combine(path, filePath);
                UploadFile(model.ImagePath, fullPath);
                var data = new Image()
                {
                    Name = model.Name,
                    ImagePath = filePath
                };
                _context.Add(data);
                _context.SaveChanges(); 
                return RedirectToAction("Index");   
            }
            return View();
        }
        public void UploadFile(IFormFile file,string path)
        {
            FileStream stream= new FileStream(path,FileMode.Create);
            file.CopyTo(stream);
        }
        public IActionResult Index()
        {
            var data=_context.Images.ToList();
            return View(data);
        }
    }
}
