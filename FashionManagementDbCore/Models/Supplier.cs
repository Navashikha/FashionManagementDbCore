using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FashionManagementDbCore.Models
{
    public class Supplier
    {

        [Key]

        public int SupplierId { get; set; }

        [Display(Name = "Supplier Name")]
        [Required(ErrorMessage = "Please enter the name of the Supplier")]
        public string SupplierName { get; set; }

        [Required(ErrorMessage = "Location id is required")]
        public int Location { get; set; }

        [Required(ErrorMessage = "Enter the number of inventory")]
        [Range(5, 500, ErrorMessage = "The inventory items must be between 5 and 500")]
        public int Inventory { get; set; }

        [Required(ErrorMessage = "Please indicate delivered or pending")]
        public string Status { get; set; }

    }
}
