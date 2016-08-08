using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class NovaOrdinacija
    {
        [Required]
        [Display(Name = "Naziv:")]
        public string Naziv { get; set; }

        [Required]
        [Display(Name = "PIB:")]
        public int PIB { get; set; }

        [Required]
        [Display(Name = "Maticni broj firme:")]
        public int MaticniBrojFirme { get; set; }

        [Required]
        [Display(Name = "Adresa:")]
        public string Adresa { get; set; }

        [Required]
        [Display(Name = "Grad:")]
        public string Grad { get; set; }

        [Required]
        [Display(Name = "Kontakt telefon:")]
        public string KontaktTelefon { get; set; }

        [Required]
        [Display(Name = "Ime vlasnika:")]
        public string ImeVlasnika { get; set; }

        [Required]
        [Display(Name = "Prezime vlasnika:")]
        public string PrezimeVlasnika { get; set; }

        [Required]
        [Display(Name = "JMBG vlasnika:")]
        public string JMBGVlasnika { get; set; }
    }
}