using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class IzmeniStomatologaViewModel
    {
        StomatologContext context = new StomatologContext();

        public string IDClanaKomore { get; set; }

        [Required]
        public string Ime
        {
            get;
            set;
        }

        [Required]
        public string Prezime
        {
            get;
            set;
        }

        [Required]
        public string JMBG
        {
            get;
            set;
        }

        [Required]
        public string ZavrseniFakultet
        {
            get;
            set;
        }

        [Required]
        public string Specijalizacija
        {
            get;
            set;
        }

        [Required]
        public string Sertifikat
        {
            get;
            set;
        }

        [Required]
        public string BrojTelefona
        {
            get;
            set;
        }

        [Required]
        public string Mail
        {
            get;
            set;
        }

        public void loadData()
        {
            Stomatolog s = (from m in context.Stomatolozi
                            where m.IDClanaKomore == IDClanaKomore
                            select m).First();

            Ime = s.Ime;
            Prezime = s.Prezime;
            JMBG = s.JMBG;
            ZavrseniFakultet = s.ZavrseniFakultet;
            Specijalizacija = s.Specijalizacija;
            Sertifikat = s.Sertifikat;
            BrojTelefona = s.BrojTelefona;
            Mail = s.Mail;
        }

        public void editStomatologa()
        {
            Stomatolog s = (from m in context.Stomatolozi
                            where m.IDClanaKomore == IDClanaKomore
                            select m).First();


            s.Ime = Ime;
            s.Prezime = Prezime;
            s.JMBG = JMBG;
            s.ZavrseniFakultet = ZavrseniFakultet;
            s.Specijalizacija = Specijalizacija;
            s.Sertifikat = Sertifikat;
            s.BrojTelefona = BrojTelefona;
            s.Mail = Mail;

            context.SaveChanges();
        }




    }

}