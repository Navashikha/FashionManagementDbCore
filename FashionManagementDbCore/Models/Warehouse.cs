using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FashionManagementDbCore.Models
{
    public class Warehouse
    {

        [Key]

        public int WarehouseId { get; set; }

        [Display(Name = "Warehouse Name")]
        [Required(ErrorMessage = "Please enter the name of the warehouse")]
        public string WarehouseName { get; set; }

        [Required(ErrorMessage = "Location name is required")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Enter the number of items")]
        [Range(5, 500, ErrorMessage = "The no. of items must be within 5 and 500")]
        public int ShippedItems { get; set; }

        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "Enter the phone number")]
        /* [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\\(?(\[0-9\]{3})\\)?\[-.●\]?(\[0-9\]{3})\[-.●\]?(\[0-9\]{4})$", 
        ErrorMessage = "The Phone no. is invalid")] */
        public int Phone { get; set; }

    }
}
