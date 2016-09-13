using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class NovaObavljenaPoseta
    {
    
        [Display(Name = "ID stomatologa: ")]
        public string StomatologIDClanaKomore { get; set; }

        [Required]
        [Display(Name = "ID pacijenta: ")]
        public int PacijentIDKartona { get; set; }

        [Display(Name = "Ime pacijenta:")]
        public string ImePacijenta { get; set; }

        [Display(Name = "Prezime pacijenta:")]
        public string PrezimePacijenta { get; set; }


        [Display(Name = "JMBG:")]
        public string JMBG { get; set; }


        [Required]
        [Display(Name = "Datum i vreme: ")]
        public int Dan { get; set; }

        [Required]
        public int Mesec { get; set; }

        [Required]
        public int Godina { get; set; }

        [Required]
        public int Sat { get; set; }

        [Required]
        public int Minut { get; set; }

        [Required]
        [Display(Name = "Opis intervencije: ")]
        public string OpisIntervencije { get; set; }

        
        
        [Display(Name = "Terapija: ")]
        public string Terapija { get; set; }
    }
}