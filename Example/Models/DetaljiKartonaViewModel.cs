
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class DetaljiKartonaViewModel
    {
        private StomatologContext context = new StomatologContext();

        public int IDKartona { get; set; }

        public string StomatologIDClanaKomore
        {
            get
            {
                return context.Pacijenti.Where(m => m.IDKartona == IDKartona).Select(m => m.StomatologIDClanaKomore).First();
            }

        }

        public string Ime
        {
            get
            {
                return context.Pacijenti.Where(m => m.IDKartona == IDKartona).Select(m => m.Ime).First();
            }

        }

        public string Prezime
        {
            get
            {
                return context.Pacijenti.Where(m => m.IDKartona == IDKartona).Select(m => m.Prezime).First();
            }
        }

        public string JMBG
        {
            get
            {
                return context.Pacijenti.Where(m => m.IDKartona == IDKartona).Select(m => m.JMBG).First();
            }
        }

        public int GodinaRodjenja
        {
            get
            {
                return context.Pacijenti.Where(m => m.IDKartona == IDKartona).Select(m => m.GodinaRodjenja).First();
            }
        }

        public string KontaktTelefon
        {
            get
            {
                return context.Pacijenti.Where(m => m.IDKartona == IDKartona).Select(m => m.KontaktTelefon).First();
            }
        }

        public string ImeRoditelja
        {
            get
            {
                return context.Pacijenti.Where(m => m.IDKartona == IDKartona).Select(m => m.ImeRoditelja).First();
            }
        }

        public string Napomena
        {
            get
            {
                return context.Pacijenti.Where(m => m.IDKartona == IDKartona).Select(m => m.Napomena).First();
            }
        }

        public string Pol
        {
            get
            {
                return context.Pacijenti.Where(m => m.IDKartona == IDKartona).Select(m => m.Pol).First();
            }
        }
    }
}