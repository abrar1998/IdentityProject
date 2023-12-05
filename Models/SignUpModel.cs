using System.ComponentModel.DataAnnotations;

namespace FullIdentity_Project8._0.Models
{
    public class SignUpModel
    {
        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress(ErrorMessage = "Enter Valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm your Password")]
        [Compare("Password", ErrorMessage = "Password Doesn,t Match")]
        public string ConfirmPassword { get; set; }

        public Role Role { get; set; }
    }

    public enum Role
    {
        Admin,
        Teachers,
        Students,
    }
}
