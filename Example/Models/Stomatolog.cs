using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class Stomatolog
    {
        [Key]
        public virtual string IDClanaKomore { get; set; }

        public virtual int OrdinacijaMaticniBrojFirme { get; set; }

        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string JMBG { get; set; }
        public virtual string ZavrseniFakultet { get; set; }
        public virtual ICollection<string> Specijalizacije { get; set; }
        public virtual ICollection<string> Sertifikati { get; set; }
        public virtual string BrojTelefona { get; set; }
        public virtual string Mail { get; set; }
        public virtual Ordinacija OrdinacijaZaposlenog { get; set; }
        public virtual ICollection<Pacijent> Pacijenti { get; set; }
        public virtual ICollection<ObavljenaPoseta> ObavljenePosete { get; set; }
        public virtual ICollection<ZakazanaPoseta> ZakazanePosete { get; set; }
        public virtual ICollection<Poruka> Primljene { get; set; }
        public virtual ICollection<Poruka> Poslate { get; set; }
        public virtual ICollection<Objava> Objave { get; set; }
        public virtual ICollection<KomentarNaObjavu> KomentariNaObjave { get; set; }
        public virtual ICollection<OdgovorNaPoruku> OdgovoriNaPorukePrimljeno { get; set; }

        public virtual ICollection<OdgovorNaPoruku> OdgovoriNaPorukePoslato { get; set; }

    }
}