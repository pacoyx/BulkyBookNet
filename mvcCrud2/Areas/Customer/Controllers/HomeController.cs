using BulkyBook.DattaAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

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

        public IActionResult Details(int productId)
        {
            ShoppingCart cartObj = new()
            {
                Count = 1,
                ArticuloId = productId,
                Product = _unitWork.Articulo.GetFirstOrDefault(u => u.Id == productId, includeProperties: "Category,CoverType")
            };

            return View(cartObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            shoppingCart.ApplicationUserId = claim.Value;


            ShoppingCart cartFromDb = _unitWork.ShoppingCart.GetFirstOrDefault(u=>u.ApplicationUserId == claim.Value && u.ArticuloId == shoppingCart.ArticuloId );

            if (cartFromDb == null)
            {
                _unitWork.ShoppingCart.Add(shoppingCart);
            }
            else
            {
                _unitWork.ShoppingCart.IncrementCount(cartFromDb, shoppingCart.Count);
            }

            
            _unitWork.Save();

            return RedirectToAction(nameof(Index));
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