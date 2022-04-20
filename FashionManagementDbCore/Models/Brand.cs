using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FashionManagementDbCore.Models
{
    public class Brand
    {

        [Key]

        public int BrandId { get; set; }

        [Display(Name = "Brand Name")]
        [Required(ErrorMessage = "Please enter the name of the Brand")]
        public string BrandName { get; set; }

        [Required(ErrorMessage = "Please enter the targeted market (Children/Adults)")]
        public string Market { get; set; }

        [Required(ErrorMessage = "Enter the supplier id")]
        [Display(Name = "Supplier Id")]
        public int Supplier { get; set; }

        [Display(Name = "Number of Products")]
        [Required(ErrorMessage = "Enter the number of products")]
        [Range(1, 900, ErrorMessage = "The number of products is out of range")]
        public int NoOfProducts { get; set; }

    }
}
