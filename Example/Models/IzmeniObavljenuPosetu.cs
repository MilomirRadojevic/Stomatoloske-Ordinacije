using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class IzmeniObavljenuPosetuViewModel
    {
        StomatologContext context = new StomatologContext();

        public int IDPosete { get; set; }

        [Required]
        public string OpisIntervencije
        {
            get;
            set;
        }

        [Required]
        public string Terapija
        {
            get;
            set;
        }

        [Required]
        public int Dan
        {
            get;
            set;
        }

        [Required]
        public int Mesec
        {
            get;
            set;
        }

        [Required]
        public int Godina
        {
            get;
            set;
        }

        [Required]
        public int Sat
        {
            get;
            set;
        }

        [Required]
        public int Minut
        {
            get;
            set;
        }

        public void loadData()
        {
            ObavljenaPoseta o = (from m in context.ObavljenePosete
                                 where m.IDPosete == IDPosete
                                 select m).First();

            OpisIntervencije = o.OpisIntervencije;
            Terapija = o.Terapija;
            Dan = o.DatumVreme.Day;
            Mesec = o.DatumVreme.Month;
            Godina = o.DatumVreme.Year;
            Sat = o.DatumVreme.Hour;
            Minut = o.DatumVreme.Minute;
        }

        public void editObavljenuPosetu()
        {
            ObavljenaPoseta o = (from m in context.ObavljenePosete
                                 where m.IDPosete == IDPosete
                                 select m).First();

            o.OpisIntervencije = OpisIntervencije;
            o.Terapija = Terapija;
            o.DatumVreme = new DateTime(Godina, Mesec, Dan, Sat, Minut, 0);

            context.SaveChanges();
        }




    }

}