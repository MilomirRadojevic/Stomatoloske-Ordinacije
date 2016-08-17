using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class IzmeniKartonViewModel
    {
        StomatologContext context = new StomatologContext();

        public int IDKartona { get; set; }

        [Required]
        public string StomatologIDClanaKomore
        {
            get;
            set;
        }

        [Required]
        public string Ime
        {
            get;
            set;
        }


        [Required]
        public string Prezime
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

        [Required]
        public int GodinaRodjenja
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
        public string ImeRoditelja
        {
            get;
            set;
        }

        [Required]
        public string Napomena
        {
            get;
            set;
        }

        [Required]
        public string Pol
        {
            get;
            set;
        }

        public void loadData()
        {
            Pacijent pacijent = (from m in context.Pacijenti
                                     where m.IDKartona == IDKartona
                                     select m).First();
            StomatologIDClanaKomore = pacijent.StomatologIDClanaKomore;
            Ime = pacijent.Ime;
            Prezime = pacijent.Prezime;
            JMBG = pacijent.JMBG;
            GodinaRodjenja = pacijent.GodinaRodjenja;
            KontaktTelefon = pacijent.KontaktTelefon;
            ImeRoditelja = pacijent.ImeRoditelja;
            Napomena = pacijent.Napomena;
            Pol = pacijent.Pol;
        }

        public void editKarton()
        {
            Pacijent pacijent = (from m in context.Pacijenti
                                 where m.IDKartona == IDKartona
                                 select m).First();
            pacijent.StomatologIDClanaKomore = StomatologIDClanaKomore;
            pacijent.Ime = Ime;
            pacijent.Prezime = Prezime;
            pacijent.JMBG = JMBG;
            pacijent.GodinaRodjenja = GodinaRodjenja;
            pacijent.KontaktTelefon = KontaktTelefon;
            pacijent.ImeRoditelja = ImeRoditelja;
            pacijent.Napomena = Napomena;
            pacijent.Pol = Pol;

            context.SaveChanges();
        }
    }


}


