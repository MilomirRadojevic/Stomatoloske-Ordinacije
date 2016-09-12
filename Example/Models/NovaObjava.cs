using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class NovaObjava
    {
        [Display(Name = "Tekst nove objave: ")]
        public string Tekst { get; set; }

        [Display(Name = "Vrsta: ")]
        public string Vrsta { get; set; }
    }
}