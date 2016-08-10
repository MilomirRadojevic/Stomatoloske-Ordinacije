using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class KartonViewModel
    {
        [Display(Name = "Ime:")]
        public string Ime { get; set; }

        [Display(Name = "Prezime:")]
        public string Prezime { get; set; }

        [Display(Name = "JMBG:")]
        public string JMBG { get; set; }

        public IEnumerable<Pacijent> ListaKartona
        {
            get;
            set;
        }

        public KartonViewModel()
        {
            ListaKartona = context.Pacijenti.ToList();
            Ime = "";
            Prezime = "";
            JMBG = "";
        }

        StomatologContext context = new StomatologContext();

        public void RefreshList()
        {
            ListaKartona = (from m in context.Pacijenti
                            where (m.StomatologIDClanaKomore == 1)/*!!!*/&&
                               ((m.Ime == Ime) ||
                               (m.Prezime == Prezime) ||
                               (m.JMBG == JMBG))
                            select m).ToList();
        }
    }
}