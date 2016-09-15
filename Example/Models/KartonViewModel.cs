using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class KartonViewModel
    {
        
        StomatologContext context = new StomatologContext();

        [Display(Name = "Ime: ")]
        public string Ime { get; set; }

        [Display(Name = "Prezime: ")]
        public string Prezime { get; set; }

        [Display(Name = "JMBG: ")]
        public string JMBG { get; set; }

        [Display(Name = "ID člana: ")]
        public string IDStomatologa { get; set; }

        public IEnumerable<Pacijent> ListaKartona
        {
            get;
            set;
        }


        public void RefreshList()
        {
            ListaKartona = (from m in context.Pacijenti
                            where (((m.Ime == Ime) ||
                               (m.Prezime == Prezime) ||
                               (m.JMBG == JMBG)) && (m.StomatologIDClanaKomore == IDStomatologa)) 
                            select m).ToList();
        }
    }
}