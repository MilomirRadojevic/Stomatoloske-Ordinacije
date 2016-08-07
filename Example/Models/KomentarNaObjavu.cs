using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class KomentarNaObjavu
    {
        [Key]
        public virtual int IDKomentara { get; set; }
        public virtual int ObjavaIDObjave { get; set; }

        public virtual Objava OriginalnaObjava { get; set; }
        public virtual DateTime DatumVreme { get; set; }
        public virtual string Tekst { get; set; }
    }
}