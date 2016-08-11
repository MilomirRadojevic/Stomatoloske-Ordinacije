using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class NoviKarton
    {
        [Required]
        [Display(Name = "StomatologIDClanaKomore:")]
        public string StomatologIDClanaKomore { get; set; }

        [Required]
        [Display(Name = "Ime:")]
        public string Ime { get; set; }

        [Required]
        [Display(Name = "Prezime:")]
        public string Prezime { get; set; }

        [Required]
        [Display(Name = "JMBG:")]
        public string JMBG { get; set; }

        [Required]
        [Display(Name = "Godina rodjenja:")]
        public uint GodinaRodjenja { get; set; }

        [Required]
        [Display(Name = "Kontakt telefon:")]
        public string KontaktTelefon { get; set; }

        [Required]
        [Display(Name = "Ime roditelja:")]
        public string ImeRoditelja { get; set; }

        [Required]
        [Display(Name = "Napomena:")]
        public string Napomena { get; set; }

        [Required]
        [Display(Name = "Pol:")]
        public string Pol { get; set; }
    }
}