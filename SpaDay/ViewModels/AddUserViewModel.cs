using System.ComponentModel.DataAnnotations;

namespace SpaDay.ViewModels
{
    public class AddUserViewModel
    {
        // we are going to use data annotations to setup some requirements to set
        // the values of these properties
        // in other words, we won't be able to successfully create a valid instance of 
        // AddUserViewModel unless we satisfy these requirements
        [Required(ErrorMessage = "Username is required")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Username must be between 5 and 15 characters long")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 20 characters long")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Please verify your password!")]
        public string VerifyPassword { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }

        //this kind of constructor is provided by default, so no need to write it
        //public AddUserViewModel() { }
    }
}
