using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class ZakazanaPoseta
    {
        [Key]
        public virtual int IDZakazanePosete { get; set; }

        public virtual int StomatologIDClanaKomore { get; set; }

        public virtual Stomatolog Zakazao { get; set; }
        public virtual DateTime DatumVreme { get; set; }
        public virtual string ImePacijenta { get; set; }
        public virtual string PrezimePacijenta { get; set; }
        public virtual Pacijent ZakazanPacijent { get; set; }
        public virtual string Napomena { get; set; }

    }
}