using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class Pacijent
    {
        [Key]
        public virtual int IDKartona { get; set; }

        public virtual string StomatologIDClanaKomore { get; set; }

        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string JMBG { get; set; }
        public virtual Stomatolog IzabraniStomatolog { get; set; }
        public virtual uint GodinaRodjenja { get; set; }
        public virtual string KontaktTelefon { get; set; }
        public virtual string ImeRoditelja { get; set; }
        public virtual string Napomena { get; set; }
        public virtual string Pol { get; set; }
        public virtual ICollection<ObavljenaPoseta> ObavljenePosete { get; set; }
        public virtual ICollection<ZakazanaPoseta> ZakazanePosete { get; set; }

    }
}