using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class ObavljenaPosetaViewModel
    {

        [Display(Name = "Dan1:")]
        public int Dan1 { get; set; }

        [Display(Name = "Mesec1:")]
        public int Mesec1 { get; set; }

        [Display(Name = "Godina1:")]
        public int Godina1 { get; set; }

        [Display(Name = "Dan2:")]
        public int Dan2 { get; set; }

        [Display(Name = "Mesec2:")]
        public int Mesec2 { get; set; }

        [Display(Name = "Godina2:")]
        public int Godina2 { get; set; }

        public StomatologContext context = new StomatologContext();

        public string IDStomatologa { get; set; }


        public IEnumerable<ObavljenaPoseta> ListaObavljenihPoseta
        {
            get;
            set;
        }


        public void RefreshList()
        {
            DateTime dt1 = new DateTime(Godina1, Mesec1, Dan1);
            DateTime dt2 = new DateTime(Godina2, Mesec2, Dan2);
            ListaObavljenihPoseta = (from m in context.ObavljenePosete
                                     where (m.StomatologIDClanaKomore == IDStomatologa) &&
                                       (m.DatumVreme > dt1) &&
                                       (m.DatumVreme < dt2)
                                     select m).ToList().OrderByDescending(m => m.DatumVreme);
        }

    }
}