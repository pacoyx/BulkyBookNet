using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [DisplayName("Display order XXX")]
        [Range(1, 1000, ErrorMessage = "El numero debe estar entre 1 y 1000 por favor.")]
        public int DisplayOrder { get; set; }
        public DateTime createDateTime { get; set; } = DateTime.Now;

    }
}
