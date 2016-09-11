using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class DetaljiZakazanaPosetaViewModel
    {
        StomatologContext context = new StomatologContext();

        public int IDZakazanePosete { get; set; }

        public string ImePacijenta
        {
            get
            {
                return context.ZakazanePosete.Where(m => m.IDZakazanePosete.CompareTo(IDZakazanePosete) == 0).Select(m => m.ImePacijenta).First();

            }
        }

        public string PrezimePacijenta
        {
            get
            {
                return context.ZakazanePosete.Where(m => m.IDZakazanePosete.CompareTo(IDZakazanePosete) == 0).Select(m => m.PrezimePacijenta).First();

            }
        }

        public string Napomena
        {
            get
            {
                return context.ZakazanePosete.Where(m => m.IDZakazanePosete.CompareTo(IDZakazanePosete) == 0).Select(m => m.Napomena).First();

            }
        }

        public string Datum
        {
            get
            {
                ZakazanaPoseta z = (from m in context.ZakazanePosete
                        where m.IDZakazanePosete == IDZakazanePosete
                        select m).First();

                return z.DatumVreme.Day.ToString() + "." + z.DatumVreme.Month.ToString() + "." + z.DatumVreme.Year.ToString() + ".";
            }
        }


        public string Vreme
        {
            get
            {
                ZakazanaPoseta z = (from m in context.ZakazanePosete
                        where m.IDZakazanePosete == IDZakazanePosete
                        select m).First();

                return z.DatumVreme.Hour.ToString() + ":" + z.DatumVreme.Minute.ToString();
            }
        }
    }
}