using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class ObavljeniPregled
    {

        StomatologContext context = new StomatologContext();

        public int IDPosete { get; set; }

        public string IDStomatologa { get; set; }
        public int IDPacijenta { get; set; }

        [Display(Name = "Ime pacijenta:")]
        public string ImePacijenta { get; set; }

        [Display(Name = "Prezime pacijenta:")]
        public string PrezimePacijenta { get; set; }


        [Display(Name = "JMBG:")]
        public string JMBG { get; set; }

        [Required]
        [Display(Name = "Datum i vreme: ")]

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

        [Display(Name = "Jedinica gore levo: ")]
        public string JedinicaGoreLevo { get; set; }

        [Display(Name = "Dvojka gore levo: ")]
        public string DvojkaGoreLevo { get; set; }

        [Display(Name = "Trojka gore levo: ")]
        public string TrojkaGoreLevo { get; set; }

        [Display(Name = "Četvorka gore levo: ")]
        public string CetvorkaGoreLevo { get; set; }

        [Display(Name = "Petica gore levo: ")]
        public string PeticaGoreLevo { get; set; }        
        
        [Display(Name = "Šestica gore levo: ")]
        public string SesticaGoreLevo { get; set; }

        [Display(Name = "Sedmica gore levo: ")]
        public string SedmicaGoreLevo { get; set; }

        [Display(Name = "Osmica gore levo: ")]
        public string OsmicaGoreLevo { get; set; }




        [Display(Name = "Jedinica gore desno: ")]
        public string JedinicaGoreDesno { get; set; }

        [Display(Name = "Dvojka gore desno: ")]
        public string DvojkaGoreDesno { get; set; }


        [Display(Name = "Trojka gore desno: ")]
        public  string TrojkaGoreDesno { get; set; }

        [Display(Name = "Četvorka gore desno: ")]
        public  string CetvorkaGoreDesno { get; set; }

        [Display(Name = "Petica gore desno: ")]
        public  string PeticaGoreDesno { get; set; }

        [Display(Name = "Šestica gore desno: ")]
        public  string SesticaGoreDesno { get; set; }

        [Display(Name = "Sedmica gore desno: ")]
        public  string SedmicaGoreDesno { get; set; }

        [Display(Name = "Osmica gore desno: ")]
        public  string OsmicaGoreDesno { get; set; }



        [Display(Name = "Jedinica dole desno: ")]
        public  string JedinicaDoleDesno { get; set; }

        [Display(Name = "Dvojka dole desno: ")]
        public  string DvojkaDoleDesno { get; set; }

        [Display(Name = "Trojka dole desno: ")]
        public  string TrojkaDoleDesno { get; set; }

        [Display(Name = "Četvorka dole desno: ")]
        public  string CetvorkaDoleDesno { get; set; }

        [Display(Name = "Petica dole desno: ")]
        public  string PeticaDoleDesno { get; set; }

        [Display(Name = "Šestica dole desno: ")]
        public  string SesticaDoleDesno { get; set; }

        [Display(Name = "Sedmica dole desno: ")]
        public  string SedmicaDoleDesno { get; set; }


        [Display(Name = "Osmica dole desno: ")]
        public  string OsmicaDoleDesno { get; set; }


        [Display(Name = "Jedinica dole levo: ")]
        public  string JedinicaDoleLevo { get; set; }

        [Display(Name = "Dvojka dole levo: ")]
        public  string DvojkaDoleLevo { get; set; }

        [Display(Name = "Trojka dole levo: ")]
        public  string TrojkaDoleLevo { get; set; }

        [Display(Name = "Četvorka dole levo: ")]
        public string CetvorkaDoleLevo { get; set; }

        [Display(Name = "Petica dole levo: ")]
        public  string PeticaDoleLevo { get; set; }

        [Display(Name = "Šestica dole levo: ")]
        public  string SesticaDoleLevo { get; set; }

        [Display(Name = "Sedmica dole levo: ")]
        public  string SedmicaDoleLevo { get; set; }

        [Display(Name = "Osmica dole levo: ")]
        public string OsmicaDoleLevo { get; set; }
        




    }
}