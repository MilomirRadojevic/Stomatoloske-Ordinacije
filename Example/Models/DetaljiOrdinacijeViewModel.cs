
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class DetaljiOrdinacijeViewModel
    {
        private StomatologContext context = new StomatologContext();

        public int MaticniBrojFirme { get; set; }

        public string Naziv
        {
            get
            {
                return context.Ordinacije.Where(m => m.MaticniBrojFirme == MaticniBrojFirme).Select(m => m.Naziv).First();
            }

        }

        public string Grad
        {
            get
            {
                return context.Ordinacije.Where(m => m.MaticniBrojFirme == MaticniBrojFirme).Select(m => m.Grad).First();
            }

        }

        public string Adresa
        {
            get
            {
                return context.Ordinacije.Where(m => m.MaticniBrojFirme == MaticniBrojFirme).Select(m => m.Adresa).First();
            }
        }

        public int PIB
        {
            get
            {
                return context.Ordinacije.Where(m => m.MaticniBrojFirme == MaticniBrojFirme).Select(m => m.PIB).First();
            }
        }

        public string ImeVlasnika
        {
            get
            {
                return context.Ordinacije.Where(m => m.MaticniBrojFirme == MaticniBrojFirme).Select(m => m.ImeVlasnika).First();
            }
        }

        public string PrezimeVlasnika
        {
            get
            {
                return context.Ordinacije.Where(m => m.MaticniBrojFirme == MaticniBrojFirme).Select(m => m.PrezimeVlasnika).First();
            }
        }


        public string JMBG
        {
            get
            {
                return context.Ordinacije.Where(m => m.MaticniBrojFirme == MaticniBrojFirme).Select(m => m.JMBG).First();
            }
        }
    }
}