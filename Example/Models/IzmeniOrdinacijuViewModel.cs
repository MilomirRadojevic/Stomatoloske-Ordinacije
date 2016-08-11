using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class IzmeniOrdinacijuViewModel
    {
        StomatologContext context = new StomatologContext();

        public int MaticniBrojFirme { get; set; }

        [Required]
        public string Naziv
        {
            get;
            set;
        }

        [Required]
        public string Grad
        {
            get;
            set;
        }


        [Required]
        public string Adresa
        {
            get;
            set;
        }

        [Required]
        public string KontaktTelefon
        {
            get;
            set;
        }

        [Required]
        public int PIB
        {
            get;
            set;
        }

        [Required]
        public string ImeVlasnika
        {
            get;
            set;
        }

        [Required]
        public string PrezimeVlasnika
        {
            get;
            set;
        }

        [Required]
        public string JMBG
        {
            get;
            set;
        }

        public void loadData()
        {
            Ordinacija ordinacija = (from m in context.Ordinacije
                                     where m.MaticniBrojFirme == MaticniBrojFirme
                                     select m).First();

            Naziv = ordinacija.Naziv;
            Grad = ordinacija.Grad;
            Adresa = ordinacija.Adresa;
            KontaktTelefon = ordinacija.KontaktTelefon;
            PIB = ordinacija.PIB;
            ImeVlasnika = ordinacija.ImeVlasnika;
            PrezimeVlasnika = ordinacija.PrezimeVlasnika;
            JMBG = ordinacija.JMBG;
        }

        public void editOrdinacija()
        {
            Ordinacija ordinacija = (from m in context.Ordinacije
                                     where m.MaticniBrojFirme == MaticniBrojFirme
                                     select m).First();

            ordinacija.Naziv = Naziv;
            ordinacija.Grad = Grad;
            ordinacija.Adresa = Adresa;
            ordinacija.KontaktTelefon = KontaktTelefon;
            ordinacija.PIB = PIB;
            ordinacija.ImeVlasnika = ImeVlasnika;
            ordinacija.PrezimeVlasnika = PrezimeVlasnika;
            ordinacija.JMBG = JMBG;

            context.SaveChanges();
        }
    }


}


