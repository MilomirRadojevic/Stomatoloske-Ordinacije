using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class IzmeniZakazanuPosetuViewModel
    {
        StomatologContext context = new StomatologContext();

        public int IDZakazanePosete { get; set; }

        [Required]
        [Display(Name = "Napomena: ")]
        public string Napomena
        {
            get;
            set;
        }

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

        public void loadData()
        {
            ZakazanaPoseta z = (from m in context.ZakazanePosete
                            where m.IDZakazanePosete == IDZakazanePosete
                            select m).First();

            Napomena = z.Napomena;
            Dan = z.DatumVreme.Day;
            Mesec = z.DatumVreme.Month;
            Godina = z.DatumVreme.Year;
            Sat = z.DatumVreme.Hour;
            Minut = z.DatumVreme.Minute;
        }

        public void editZakazanuPosetu()
        {
            ZakazanaPoseta z = (from m in context.ZakazanePosete
                                where m.IDZakazanePosete == IDZakazanePosete
                                select m).First();

            z.Napomena = Napomena;
            z.DatumVreme = new DateTime(Godina, Mesec, Dan, Sat, Minut, 0);

            context.SaveChanges();
        }




    }

}