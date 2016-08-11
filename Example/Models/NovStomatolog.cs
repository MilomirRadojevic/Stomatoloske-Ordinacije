using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class NovStomatolog
    {
        [Required]
        [Display(Name = "ID člana komore:")]
        public string IDClanaKomore { get; set; }

        [Required]
        [Display(Name = "Matični broj firme stomatologa:")]
        public int MaticniBrojFirmeStomatologa { get; set; }

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
        [Display(Name = "Završeni fakultet:")]
        public string ZavrseniFakultet { get; set; }

        [Required]
        [Display(Name = "Specijalizacija:")]
        public string Specijalizacija { get; set; }

        [Required]
        [Display(Name = "Sertifikat:")]
        public string Sertifikat { get; set; }

        [Required]
        [Display(Name = "Broj telefona:")]
        public string BrojTelefona { get; set; }

        [Required]
        [Display(Name = "Mail:")]
        public string Mail { get; set; }

    }



}