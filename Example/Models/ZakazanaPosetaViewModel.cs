using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class ZakazanaPosetaViewModel
    {

        [Display(Name = "Od dana: ")]
        public int Dan1 { get; set; }

        [Display(Name = "Od meseca: ")]
        public int Mesec1 { get; set; }

        [Display(Name = "Od godine: ")]
        public int Godina1 { get; set; }

        [Display(Name = "Do dana: ")]
        public int Dan2 { get; set; }

        [Display(Name = "Do meseca: ")]
        public int Mesec2 { get; set; }

        [Display(Name = "Do godine: ")]
        public int Godina2 { get; set; }

        private StomatologContext context = new StomatologContext();

        public IEnumerable<ZakazanaPoseta> ListaZakazanihPoseta
        {
            get;
            set;
        }

        public string IDStomatologa { get; set; }



        public void RefreshList()
        {
            DateTime dt1 = new DateTime(Godina1, Mesec1, Dan1);
            DateTime dt2 = new DateTime(Godina2, Mesec2, Dan2);
            ListaZakazanihPoseta = (from m in context.ZakazanePosete
                                where (m.StomatologIDClanaKomore == IDStomatologa) &&
                                  (m.DatumVreme > dt1) &&
                                  (m.DatumVreme < dt2)
                                select m).ToList();
        }

    }
}