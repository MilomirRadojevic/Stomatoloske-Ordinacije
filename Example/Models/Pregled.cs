using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class Pregled
    {
        [Key]
        public virtual int IDPregleda { get; set; }
        public virtual ObavljenaPoseta Poseta { get; set; }

        public virtual int ObavljenaPosetaIDPosete { get; set; }

        public virtual string JedinicaGoreLevo { get; set; }
        public virtual string DvojkaGoreLevo { get; set; }
        public virtual string TrojkaGoreLevo { get; set; }
        public virtual string CetvorkaGoreLevo { get; set; }
        public virtual string PeticaGoreLevo { get; set; }
        public virtual string SesticaGoreLevo { get; set; }
        public virtual string SedmicaGoreLevo { get; set; }
        public virtual string OsmicaGoreLevo { get; set; }

        public virtual string JedinicaGoreDesno { get; set; }
        public virtual string DvojkaGoreDesno { get; set; }
        public virtual string TrojkaGoreDesno { get; set; }
        public virtual string CetvorkaGoreDesno { get; set; }
        public virtual string PeticaGoreDesno { get; set; }
        public virtual string SesticaGoreDesno { get; set; }
        public virtual string SedmicaGoreDesno { get; set; }
        public virtual string OsmicaGoreDesno { get; set; }

        public virtual string JedinicaDoleDesno { get; set; }
        public virtual string DvojkaDoleDesno { get; set; }
        public virtual string TrojkaDoleDesno { get; set; }
        public virtual string CetvorkaDoleDesno { get; set; }
        public virtual string PeticaDoleDesno { get; set; }
        public virtual string SesticaDoleDesno { get; set; }
        public virtual string SedmicaDoleDesno { get; set; }
        public virtual string OsmicaDoleDesno { get; set; }

        public virtual string JedinicaDoleLevo { get; set; }
        public virtual string DvojkaDoleLevo { get; set; }
        public virtual string TrojkaDoleLevo { get; set; }
        public virtual string CetvorkaDoleLevo { get; set; }
        public virtual string PeticaDoleLevo { get; set; }
        public virtual string SesticaDoleLevo { get; set; }
        public virtual string SedmicaDoleLevo { get; set; }
        public virtual string OsmicaDoleLevo { get; set; }

    }
}