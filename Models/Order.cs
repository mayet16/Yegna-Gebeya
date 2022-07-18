using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YegnaGebiyaSystem.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
       // public List<OrderDetails> OrderLines { get; set; }

        public Product Products { get; set; }
        public string Username { get; set; }

        //[Required(ErrorMessage = "First Name is required")]
        //[DisplayName("First Name")]
        //[StringLength(160)]
        //public string FirstName { get; set; }

        //[Required(ErrorMessage = "Last Name is required")]
        //[DisplayName("Last Name")]
        //[StringLength(160)]
        //public string LastName { get; set; }

        //[Required(ErrorMessage = "Address is required")]
        //[StringLength(70)]
        //public string Address { get; set; }

        //[Required(ErrorMessage = "City is required")]
        //[StringLength(40)]
        //public string City { get; set; }

        //[Required(ErrorMessage = "State is required")]
        //[StringLength(40)]
        //public string State { get; set; }

        //[DisplayName("Postal Code")]
        //[StringLength(10)]
        //public string PostalCode { get; set; }

        //[Required(ErrorMessage = "Country is required")]
        //[StringLength(40)]
        //public string Country { get; set; }

        //[StringLength(24)]
        //public string Phone { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [DisplayName("Email Address")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm Password")]
        //[Compare("Password", ErrorMessage = " password and Confirmation Password no not match")]
        //public string ConfirmPassword { get; set; }
        [Required]
        public double OrderTotal { get; set; }
        [Required]
        public DateTime Orderplaced { get; set; }

        [ScaffoldColumn(false)]
        public string PaymentTransactionId { get; set; }

        [ScaffoldColumn(false)]
        public bool HasBeenShipped { get; set; }

    }
}
