﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class NovaZakazanaPosetaBezKartona
    {
        [Display(Name = "ID stomatologa: ")]
        public string StomatologIDClanaKomore { get; set; }

        [Required]
        [Display(Name = "Datum i vreme: ")]
        public int Dan { get; set; }

        [Required]
        public int Mesec { get; set; }

        [Required]
        public int Godina { get; set; }

        [Required]
        public int Sat { get; set; }

        [Required]
        public int Minut { get; set; }

        [Required]
        [Display(Name = "Ime pacijenta: ")]
        public string ImePacijenta { get; set; }

        [Required]
        [Display(Name = "Prezime pacijenta: ")]
        public string PrezimePacijenta { get; set; }

        [Required]
        [Display(Name = "Napomena: ")]
        public string Napomena { get; set; }
    }
}