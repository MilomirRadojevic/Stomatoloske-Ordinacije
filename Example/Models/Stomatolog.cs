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

        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string JMBG { get; set; }
        public virtual string ZavrseniFakultet { get; set; }

    }
}