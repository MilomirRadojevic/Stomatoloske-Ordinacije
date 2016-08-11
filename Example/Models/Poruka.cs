using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class Poruka
    {
        [Key]
        public virtual int IDPoruke { get; set; }

        public virtual string StomatologPrimalacIDClanaKomore { get; set; }
        public virtual string StomatologSaljeIDClanaKomore { get; set; }

        public virtual DateTime DatumVreme { get; set; }
        public virtual Stomatolog Primalac { get; set; }
        public virtual Stomatolog Salje { get; set; }
        public virtual string Tekst { get; set; }
        public virtual bool Procitana { get; set; }

        public virtual ICollection<OdgovorNaPoruku> OdgovoriNaPoruke { get; set; }


    }
}