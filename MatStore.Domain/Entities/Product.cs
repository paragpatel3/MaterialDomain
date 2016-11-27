using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MatStore.Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)] //render as hidden formelements
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a price above 0")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please specify a category")]
        public string Category { get; set; }

        public string Image { get; set; }
    }
}
