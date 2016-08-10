using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class ObavljenaPoseta
    {
        [Key]
        public virtual int IDPosete { get; set; }
        public virtual int StomatologIDClanaKomore { get; set; }
        public virtual int PacijentIDKartona { get; set; }


        public virtual Pacijent PregledaniPacijent { get; set; }
        public virtual Stomatolog IzabraniStomatolog { get; set; }
        public virtual DateTime DatumVreme { get; set; }
        public virtual Pregled ObavljeniPregled { get; set; }
        public virtual string OpisIntervencije { get; set; }
        public virtual string Terapija { get; set; }
    }
}