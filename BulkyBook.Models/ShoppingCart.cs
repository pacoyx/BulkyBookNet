using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        public int ArticuloId { get; set; }


        [ForeignKey("ArticuloId")]
        [ValidateNever]
        public Articulo Product { get; set; }
                
        [Range(1, 1000, ErrorMessage = "Por favor ingrese un valor entre 1 y 1000")]
        public int Count { get; set; }


        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public AplicationUser ApplicationUser { get; set; }

    }
}
