using System.ComponentModel.DataAnnotations;

namespace Example.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Korisničko ime: ")]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Trenutna lozinka: ")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "'{0}' mora biti dugačka bar '{2}' karaktera.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova lozinka: ")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrdite novu lozinku: ")]
        [Compare("NewPassword", ErrorMessage = "Lozinke se ne poklapaju.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Korisničko ime: ")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka: ")]
        public string Password { get; set; }

        [Display(Name = "Zapamti me? ")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "ID člana komore: ")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Lozinka mora biti bar dužine {2} .", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka: ")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrdi lozinku: ")]
        [Compare("Password", ErrorMessage = "Lozinka i potvrda lozinke moraju biti iste! ")]
        public string ConfirmPassword { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        public class Item
        {
            public int ID { get; set; }
            public string Name { get; set; }

        }

        [Required]
        [Display(Name = "Matični broj firme stomatologa: ")]
        public int MaticniBrojFirmeStomatologa { get; set; }

        [Required]
        [Display(Name = "Ime: ")]
        public string Ime { get; set; }


        [Required]
        [Display(Name = "Prezime: ")]
        public string Prezime { get; set; }

        [Required]
        [Display(Name = "JMBG: ")]
        public string JMBG { get; set; }

        [Required]
        [Display(Name = "Završeni fakultet: ")]
        public string ZavrseniFakultet { get; set; }

        [Required]
        [Display(Name = "Specijalizacija: ")]
        public string Specijalizacija { get; set; }

        [Required]
        [Display(Name = "Sertifikati i seminari: ")]
        public string Sertifikat { get; set; }

        [Required]
        [Display(Name = "Broj telefona: ")]
        public string BrojTelefona { get; set; }

        [Required]
        [Display(Name = "Mail: ")]
        public string Mail { get; set; }
    }

}
