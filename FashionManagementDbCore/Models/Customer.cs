using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FashionManagementDbCore.Models
{
    public class Customer
    {

        [Key]

        [Display(Name = "Customer Id")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please Enter Your FullName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Your FullName")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter your Age")]
        [Range(5, 90, ErrorMessage = "Age must be within 9 and 90")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please enter the id of your product")]
        public int ProductId { get; set; }


    }
}


