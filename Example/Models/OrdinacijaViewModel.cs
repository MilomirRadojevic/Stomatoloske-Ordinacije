using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class OrdinacijaViewModel
    {
        [Display(Name = "Naziv:")]
        public string Naziv { get; set; }

        [Display(Name = "Maticni broj firme:")]
        public int? MaticniBrojFirme { get; set; }

        [Display(Name = "PIB:")]
        public int? PIB { get; set; }

        [Display(Name = "JMBG vlasnika:")]
        public string JMBGVlasnika { get; set; }

        private StomatologContext context = new StomatologContext();

        public IEnumerable<Ordinacija> ListaOrdinacija
        {
            get;
            set;
        }

        public OrdinacijaViewModel()
        {
            ListaOrdinacija = context.Ordinacije.ToList();
            Naziv = "";
            JMBGVlasnika = "";
        }




        public void RefreshList()
        {
            ListaOrdinacija = (from m in context.Ordinacije
                               where (m.PIB == PIB) ||
                                 (m.MaticniBrojFirme == MaticniBrojFirme) ||
                                 (m.Naziv == Naziv) ||
                                 (m.JMBG == JMBGVlasnika)
                               select m).ToList();
        }
    }
}