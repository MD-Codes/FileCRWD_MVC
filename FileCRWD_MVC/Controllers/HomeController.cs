using FileCRWD_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace FileCRWD_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private FileHelper _fileHelper;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _fileHelper = new FileHelper();
        }

        public IActionResult Index()
        {
            
            ViewBag.Data = _fileHelper.ListOfFiles();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult DeleteFile(string id)
        {
            _fileHelper.DeleteFileName(id);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult CreateFile(string FileName) 
        {
            _fileHelper.CreateFile(FileName);
            return RedirectToAction("index");
        }
        public IActionResult OpenFile(string id)
        {
            ViewBag.FileName = id;
            ViewBag.FileContent = _fileHelper.OpenFile(id);

            return View("OpenFile");
        }
        [HttpPost]
        public IActionResult SaveFile(string content, string name)
        {
            _fileHelper.SaveFile(content, name);
            return RedirectToAction("Index");
        }
    }
}
