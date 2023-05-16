using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreShoppingCart.Models
{
    [Table("TblLogin")]
    public class Login
    {
        public int Id { get; set; }
        [MinLength(3,ErrorMessage ="Min 3 char Req"),MaxLength(50)]
        [Display(Name ="User Name")]
        public string Username { get; set; }
        [MinLength(3, ErrorMessage = "Min 3 char Req"), MaxLength(50)]
        [DataType(DataType.Password)]


        public string Password { get; set; }
        [MinLength(3, ErrorMessage = "Min 3 char Req"), MaxLength(50)]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password Not Matched")]
        [Display(Name ="Confirm Password")]
        public string CPassword { get; set; }

        [MinLength(3, ErrorMessage = "Min 3 char Req"), MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [MinLength(11, ErrorMessage = "Min 11 char Req"), MaxLength(20)]
        public string Phone { get; set; }
        [MinLength(10, ErrorMessage = "Min 3 char Req"), MaxLength(250)]
        [Display(Name ="Home Address")]
        public string HAddress { get; set; }  
    }
}
