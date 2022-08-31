using BulkyBook.DattaAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace mvcCrud2.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitWork)
        {
            _logger = logger;
            _unitWork = unitWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Articulo> prouctList = _unitWork.Articulo.GetAll(includeProperties: "Category,CoverType");
            return View(prouctList);
        }

        public IActionResult Details(int id)
        {
            ShoppingCart cartObj = new()
            {
                Count = 1,
                Product = _unitWork.Articulo.GetFirstOrDefault(u => u.Id == id, includeProperties: "Category,CoverType")
            };

            return View(cartObj);
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
    }
}