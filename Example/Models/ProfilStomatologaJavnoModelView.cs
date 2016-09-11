using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class ProfilStomatologaJavnoModelView
    {
        StomatologContext stomatolog = new StomatologContext();

        public string IDClanaKomore { get; set; }

        [Display(Name = "Ime: ")]
        public virtual string Ime
        {
            get
            {
                return stomatolog.Stomatolozi.Where(m => m.IDClanaKomore == IDClanaKomore).Select(m => m.Ime).First();
            }
        }

        [Display(Name = "Prezime: ")]
        public virtual string Prezime 
        {
            get
            {
                return stomatolog.Stomatolozi.Where(m => m.IDClanaKomore == IDClanaKomore).Select(m => m.Prezime).First();
            }
        }

        [Display(Name = "Završeni fakultet: ")]
        public virtual string ZavrseniFakultet
        {
            get
            {
                return stomatolog.Stomatolozi.Where(m => m.IDClanaKomore == IDClanaKomore).Select(m => m.ZavrseniFakultet).First();
            }
        }

        [Display(Name = "Specijalizacija: ")]
        public virtual string Specijalizacija
        {
            get
            {
                return stomatolog.Stomatolozi.Where(m => m.IDClanaKomore == IDClanaKomore).Select(m => m.Specijalizacija).First();
            }
        }

        [Display(Name = "Sertfikati i seminari: ")]
        public virtual string Sertifikat
        {
            get
            {
                return stomatolog.Stomatolozi.Where(m => m.IDClanaKomore == IDClanaKomore).Select(m => m.Sertifikat).First();
            }
        }

        [Display(Name = "Kontakt telefon: ")]
        public virtual string BrojTelefona 
        {
            get
            {
                string telefon = stomatolog.Stomatolozi.Where(m => m.IDClanaKomore == IDClanaKomore).Select(m => m.BrojTelefona).First();
                if (telefon == "")
                    return OrdinacijaZaposlenog.KontaktTelefon;
                else
                    return telefon;
            }
        }

        [Display(Name = "Mail: ")]
        public virtual string Mail 
        {
            get
            {
                return stomatolog.Stomatolozi.Where(m => m.IDClanaKomore == IDClanaKomore).Select(m => m.Mail).First();
            }
        }

        [Display(Name = "Ordinacija: ")]
        public virtual string OrdinacijaZaposlenogInfo
        {
            get
            {
                Ordinacija o = stomatolog.Stomatolozi.Where(m => m.IDClanaKomore == IDClanaKomore).Select(m => m.OrdinacijaZaposlenog).First(); 
                return o.Naziv + " ( " + o.Adresa + ", " + o.Grad + " ) ";
            }

        }

        public virtual Ordinacija OrdinacijaZaposlenog 
        {
            get
            {
                return stomatolog.Stomatolozi.Where(m => m.IDClanaKomore == IDClanaKomore).Select(m => m.OrdinacijaZaposlenog).First();
            }
        }
    }
}