﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class ZakazanaPosetaViewModel
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

        private StomatologContext context = new StomatologContext();

        public IEnumerable<ZakazanaPoseta> ListaZakazanihPoseta
        {
            get;
            set;
        }

        public ZakazanaPosetaViewModel()
        {
            ListaZakazanihPoseta = context.ZakazanePosete.ToList();
            DateTime dt = DateTime.Now;
            Dan1 = dt.Day;
            Mesec1 = dt.Month;
            Godina1 = dt.Year;
            dt = dt.AddDays(1);
            Dan2 = dt.Day;
            Mesec2 = dt.Month;
            Godina2 = dt.Year;
        }




        public void RefreshList()
        {
            DateTime dt1 = new DateTime(Godina1, Mesec1, Dan1);
            DateTime dt2 = new DateTime(Godina2, Mesec2, Dan2);
            ListaZakazanihPoseta = (from m in context.ZakazanePosete
                                    where (m.StomatologIDClanaKomore == Username.Name) &&
                                      (m.DatumVreme > dt1) &&
                                      (m.DatumVreme < dt2)
                                    select m).ToList();
        }

    }
}