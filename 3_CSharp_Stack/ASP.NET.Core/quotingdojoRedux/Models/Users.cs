using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace quotingdojoRedux.Models
{
    // public abstract class BaseEntity {}
    public class User : BaseEntity
        {
            [Key]
            public string id { get; set; }
            [Required]
            [MinLength(2)]
            public string FirstName { get; set; }
            [Required]
            [MinLength(2)]
            public string LastName { get; set; }
            [Required]
            [EmailAddress]
            public string Email { get; set; }
            [Required]
            public string Password { get; set; }
            [Required]
            [Compare("Password")]
            public string Confirm_pw { get; set; }

            public string first_name { get; set; }
            public string last_name { get; set; }
            public ICollection<QuoteItem> quotes { get; set; }
        }

    public class ReturnUser : BaseEntity
        {
            [Key]
            public int id { get; set; }
            
            [Required]
            [EmailAddress]
            public string Email { get; set; }
            [Required]
            public string Password { get; set; }
        }
}