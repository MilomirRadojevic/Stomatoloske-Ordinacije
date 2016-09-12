using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class NoviKomentar
    {
        public int IDObjave { get; set; }

        [Display(Name = "Tekst komentara: ")]
        public string Tekst { get; set; }
    }
}