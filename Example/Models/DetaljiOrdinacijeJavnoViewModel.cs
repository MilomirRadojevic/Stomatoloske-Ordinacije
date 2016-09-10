using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class DetaljiOrdinacijeJavnoViewModel
    {
        StomatologContext stomatolog = new StomatologContext();

        [Display(Name = "Grad: ")]
        public string Grad
        {
            get
            {
                return stomatolog.Ordinacije.Where(m => m.MaticniBrojFirme == MaticniBrojFirme).Select(m => m.Grad).First();
            }
        }

        [Display(Name = "Naziv: ")]
        public string Naziv
        {
            get
            {
                return stomatolog.Ordinacije.Where(m => m.MaticniBrojFirme == MaticniBrojFirme).Select(m => m.Naziv).First();
            }
        }

        [Display(Name = "Adresa: ")]
        public string Adresa
        {
            get
            {
                return stomatolog.Ordinacije.Where(m => m.MaticniBrojFirme == MaticniBrojFirme).Select(m => m.Adresa).First();
            }
        }

        [Display(Name = "Kontakt telefon: ")]
        public string KontaktTelefon
        {
            get
            {
                return stomatolog.Ordinacije.Where(m => m.MaticniBrojFirme == MaticniBrojFirme).Select(m => m.KontaktTelefon).First();
            }
        }

        public int MaticniBrojFirme { get; set; }

        public virtual ICollection<Stomatolog> Zaposleni
        {
            get
            {
                return stomatolog.Ordinacije.Where(m => m.MaticniBrojFirme == MaticniBrojFirme).Select(m => m.Zaposleni).First();
            }
        }
    }
}