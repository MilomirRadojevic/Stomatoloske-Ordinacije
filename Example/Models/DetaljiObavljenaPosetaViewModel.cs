using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class DetaljiObavljenaPosetaViewModel
    {
        StomatologContext context = new StomatologContext();

        public int IDPosete { get; set; }

        public string ImePacijenta
        {
            get
            {
                return (from t in context.Pacijenti where t.IDKartona == (from p in context.ObavljenePosete where p.IDPosete == IDPosete select p.PacijentIDKartona).FirstOrDefault() select t.Ime).First();

            }
        }

        public string PrezimePacijenta
        {
            get
            {
                return (from t in context.Pacijenti where t.IDKartona == (from p in context.ObavljenePosete where p.IDPosete == IDPosete select p.PacijentIDKartona).FirstOrDefault() select t.Prezime).First();

            }
        }

        public string Datum
        {
            get
            {
                ObavljenaPoseta o = (from m in context.ObavljenePosete
                                    where m.IDPosete == IDPosete
                                    select m).First();

                return o.DatumVreme.Day.ToString() + "." + o.DatumVreme.Month.ToString() + "." + o.DatumVreme.Year.ToString() + ".";
            }
        }


        public string Vreme
        {
            get
            {
                ObavljenaPoseta o = (from m in context.ObavljenePosete
                                     where m.IDPosete == IDPosete
                                    select m).First();

                return o.DatumVreme.Hour.ToString() + ":" + o.DatumVreme.Minute.ToString();
            }
        }

        public string OpisIntervencije
        {
            get
            {
                return context.ObavljenePosete.Where(m => m.IDPosete.CompareTo(IDPosete) == 0).Select(m => m.OpisIntervencije).First();

            }
        }

        public string Terapija
        {
            get
            {
                return context.ObavljenePosete.Where(m => m.IDPosete.CompareTo(IDPosete) == 0).Select(m => m.Terapija).First();

            }
        }
    }
}