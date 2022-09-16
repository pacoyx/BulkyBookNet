using BulkyBook.Models;

namespace mvcCrud2.Areas.Customer.Controllers
{
    public class ShoppingCartVM
    {
        public IEnumerable<ShoppingCart> ListCart { get; set; }
    }
}