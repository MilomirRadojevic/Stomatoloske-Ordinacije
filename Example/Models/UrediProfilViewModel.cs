using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class UrediProfilViewModel
    {
        StomatologContext context = new StomatologContext();

        public string IDClanaKomore { get; set; }

        [Display(Name = "Ime: ")]
        public string Ime { get; set; }

        [Display(Name = "Prezime: ")]
        public string Prezime { get; set; }

        [Display(Name = "Završeni fakultet: ")]
        public string ZavrseniFakultet { get; set; }

        [Display(Name = "Specijalizacija: ")]
        public string Specijalizacija { get; set; }

        [Display(Name = "Sertifikati i seminari: ")]
        public string Sertifikat { get; set; }

        [Display(Name = "Broj telefona: ")]
        public string BrojTelefona { get; set; }

        [Display(Name = "Mail: ")]
        public string Mail { get; set; }

        public void UcitajImeIPrezime()
        {
            Stomatolog stomatolog = (from m in context.Stomatolozi
                                     where m.IDClanaKomore == IDClanaKomore
                                     select m).First();


            Ime = stomatolog.Ime;
            Prezime = stomatolog.Prezime;
            ZavrseniFakultet = stomatolog.ZavrseniFakultet;
            Specijalizacija = stomatolog.Specijalizacija;
            Sertifikat = stomatolog.Sertifikat;
            BrojTelefona = stomatolog.BrojTelefona;
            Mail = stomatolog.Mail;
        }

        public void IzmeniProfil()
        {
            Stomatolog stomatolog = (from m in context.Stomatolozi
                                     where m.IDClanaKomore == IDClanaKomore
                                     select m).First();


            stomatolog.Ime = Ime;
            stomatolog.Prezime = Prezime;
            stomatolog.ZavrseniFakultet = ZavrseniFakultet;
            stomatolog.Specijalizacija = Specijalizacija;
            stomatolog.Sertifikat = Sertifikat;
            stomatolog.BrojTelefona = BrojTelefona;
            stomatolog.Mail = Mail;

            context.SaveChanges();
        }
    }
}