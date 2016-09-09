using System.ComponentModel.DataAnnotations;

namespace Example.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Trenutna lozinka")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "'{0}' mora biti dugačka bar '{2}' karaktera.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova lozinka")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrdite novu lozinku")]
        [Compare("NewPassword", ErrorMessage = "Lozinke se ne poklapaju.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Zapamti me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        public class Item
        {
            public int ID { get; set; }
            public string Name { get; set; }

        }

        [Required]
        [Display(Name = "Maticni broj firme stomatologa")]
        public int MaticniBrojFirmeStomatologa { get; set; }

        [Required]
        [Display(Name = "Ime")]
        public string Ime { get; set; }


        [Required]
        [Display(Name = "Prezime")]
        public string Prezime { get; set; }

        [Required]
        [Display(Name = "JMBG")]
        public string JMBG { get; set; }

        [Required]
        [Display(Name = "Zavrseni fakultet")]
        public string ZavrseniFakultet { get; set; }

        [Required]
        [Display(Name = "Specijalizacija")]
        public string Specijalizacija { get; set; }

        [Required]
        [Display(Name = "Sertifikat")]
        public string Sertifikat { get; set; }

        [Required]
        [Display(Name = "Broj telefona")]
        public string BrojTelefona { get; set; }

        [Required]
        [Display(Name = "Mail")]
        public string Mail { get; set; }
    }

}
