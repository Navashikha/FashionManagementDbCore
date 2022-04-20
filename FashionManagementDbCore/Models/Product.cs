using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FashionManagementDbCore.Models
{
    public class Product
    {

        [Key]

        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter the name of the Product")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please enter the brand id")]
        [Display(Name = "Brand Id")]
        public int Brand { get; set; }

        [Required(ErrorMessage = "Please indicate the type of clothing: Partywear/Casual/Traditional")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Enter the name of color")]
        public string Color { get; set; }

    }
}

