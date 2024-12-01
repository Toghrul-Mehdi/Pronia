using System.ComponentModel.DataAnnotations;

namespace Pronia.ViewModel
{
    public class CategoryUpdateVM
    {
        [MaxLength(32, ErrorMessage = "Title length must be less than 32"), Required(ErrorMessage = "Basliq yazmaq vacibdir")]
        public string CategoryName { get; set; }
    }
}
