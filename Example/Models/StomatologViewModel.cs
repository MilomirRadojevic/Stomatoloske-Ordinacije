using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class StomatologViewModel
    {

        [Display(Name = "Ime: ")]
        public string Ime { get; set; }

        [Display(Name = "Prezime: ")]
        public string Prezime { get; set; }

        [Display(Name = "JMBG: ")]
        public string JMBG { get; set; }

        [Display(Name = "ID člana komore: ")]
        public string IDClanaKomore { get; set; }

        private StomatologContext context = new StomatologContext();

        public IEnumerable<Stomatolog> ListaStomatologa
        {
            get;
            set;
        }

        public StomatologViewModel()
        {
            ListaStomatologa = context.Stomatolozi.ToList();
            Ime = "";
            Prezime = "";
            JMBG = "";
            IDClanaKomore = "";
        }




        public void RefreshList()
        {
            ListaStomatologa = (from m in context.Stomatolozi
                                where (m.Ime == Ime) ||
                                  (m.Prezime == Prezime) ||
                                  (m.JMBG == JMBG) ||
                                  (m.IDClanaKomore == IDClanaKomore)
                                select m).ToList();
        }

    }
}