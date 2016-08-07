using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class Ordinacija
    {
        [Key]
        public virtual int MaticniBrojFirme { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string Grad { get; set; }
        public virtual string Adresa { get; set; }
        public virtual ICollection<string> Kontakt_telefon { get; set; }
        public virtual int PIB { get; set; }

        public virtual string ImeVlasnika { get; set; }
        public virtual string PrezimeVlasnika { get; set; }
        public virtual string JMBG { get; set; }

        public virtual ICollection<Stomatolog> Zaposleni { get; set; }
    }
}