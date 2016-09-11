using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class IzborGradaViewModel
    {
        StomatologContext stomatolog = new StomatologContext();

        [Display(Name = "Grad: ")]
        public string Grad { get; set; }

        [Display(Name = "Naziv: ")]

        public string Naziv { get; set; }

        [Display(Name = "Adresa: ")]

        public string Adresa { get; set; }
        public int MaticniBrojFirme { get; set; }

        public IEnumerable<Ordinacija> ListaOrdinacija
        {
            get;
            set;
        }

        public IzborGradaViewModel()
        {
            ListaOrdinacija = stomatolog.Ordinacije.ToList();
            Naziv = "";
            Adresa = "";
            Grad = "";
            MaticniBrojFirme = 0;
        }



        public void RefreshList()
        {
            if (Grad == "Ostali gradovi")
                ListaOrdinacija = (from m in stomatolog.Ordinacije
                                   where (m.Grad != "Beograd") &&
                                        (m.Grad != "Novi Sad") &&
                                        (m.Grad != "Kragujevac") &&
                                        (m.Grad != "Niš")
                                   select m).ToList();
            else if (Grad == "Svi gradovi")
                ListaOrdinacija = (from m in stomatolog.Ordinacije
                                   select m).ToList();
            else
                ListaOrdinacija = (from m in stomatolog.Ordinacije
                                   where (m.Grad == Grad)
                                   select m).ToList();


       }

    }
}