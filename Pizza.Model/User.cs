using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pizza.Model
{
    /// <summary>
    /// User and his properties 
    /// </summary>
    public class User : Entity
    {
        public virtual ICollection<Order> Orders { set; get; }
        
        [Required(ErrorMessage = "How can we call you?" )]
        [StringLength(30, ErrorMessage = "May we use any shorter last name, please?")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "If you feel it is important, leave your last name", 
            AllowEmptyStrings = true)]
        [StringLength(50, ErrorMessage = "May we use any shorter last name, please?")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "How can we call you with regards to delivery of your order?", 
            AllowEmptyStrings = true)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "We can also email you, please leave your email",
            AllowEmptyStrings = true)]
        [Email]
        public string Email { get; set; }

        public Address Address { get; set; }
    }
}