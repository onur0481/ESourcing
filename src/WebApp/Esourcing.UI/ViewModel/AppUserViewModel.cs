using System.ComponentModel.DataAnnotations;

namespace Esourcing.UI.ViewModel
{
    public class AppUserViewModel
    {
        [Required(ErrorMessage ="UserName is required")]
        [Display(Name ="User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Firs name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

       
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Buyer is required")]
        [Display(Name = "IsBuyer")]
        public bool IsBuyer { get; set; }

        [Required(ErrorMessage = "Saller is required")]
        [Display(Name = "IsSaller")]
        public bool IsSaller { get; set; }

        public int UserSelectTypeID { get; set; }
    }
}
