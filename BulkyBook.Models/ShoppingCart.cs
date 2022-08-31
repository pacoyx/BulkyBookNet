using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models
{
    public class ShoppingCart
    {
        public Articulo Product { get; set; }

        [Range(1, 1000, ErrorMessage = "Por favor ingrese un valor entre 1 y 1000")]
        public int Count { get; set; }
    }
}
