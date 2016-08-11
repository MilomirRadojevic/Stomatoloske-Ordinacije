using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class Objava
    {
        [Key]
        public virtual int IDObjave { get; set; }

        public virtual string StomatologIDClanaKomore { get; set; }

        public virtual Stomatolog Objavio { get; set; }
        public virtual DateTime DatumVreme { get; set; }
        public virtual string Vrsta { get; set; }
        public virtual string Tekst { get; set; }
        public virtual ICollection<KomentarNaObjavu> KomentariNaObjavu { get; set; }
    }
}