using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class OdgovorNaPoruku
    {
        [Key]
        public virtual int IDOdgovora { get; set; }

        public virtual int PorukaIDPoruke { get; set; }
        public virtual int StomatologPrimalacIDClanaKomore { get; set; }
        public virtual int StomatologSaljeIDClanaKomore { get; set; }


        public virtual Poruka OriginalnaPoruka { get; set; }
        public virtual DateTime DatumVreme { get; set; }
        public virtual string Tekst { get; set; }
        public virtual Stomatolog Primalac { get; set; }
        public virtual Stomatolog Salje { get; set; }
        public virtual bool Procitana { get; set; }
    }
}