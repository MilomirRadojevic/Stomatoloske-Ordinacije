using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class DetaljiStomatologViewModel
    {
        StomatologContext context = new StomatologContext();

        public int IDClanaKomore { get; set; }

        public string Ime
        {
            get
            {
                return context.Stomatolozi.Where(m => m.IDClanaKomore.CompareTo(IDClanaKomore) == 0).Select(m => m.Ime).First();

            }
        }

        public string Prezime
        {
            get
            {
                return context.Stomatolozi.Where(m => m.IDClanaKomore.CompareTo(IDClanaKomore) == 0).Select(m => m.Prezime).First();

            }
        }

        public string JMBG
        {
            get
            {
                return context.Stomatolozi.Where(m => m.IDClanaKomore.CompareTo(IDClanaKomore) == 0).Select(m => m.JMBG).First();

            }
        }


        public string ZavrseniFakultet
        {
            get
            {
                return context.Stomatolozi.Where(m => m.IDClanaKomore.CompareTo(IDClanaKomore) == 0).Select(m => m.ZavrseniFakultet).First();

            }
        }


        public string Specijalizacija
        {
            get
            {
                return context.Stomatolozi.Where(m => m.IDClanaKomore.CompareTo(IDClanaKomore) == 0).Select(m => m.Specijalizacija).First();

            }
        }

        public string Sertifikat
        {
            get
            {
                return context.Stomatolozi.Where(m => m.IDClanaKomore.CompareTo(IDClanaKomore) == 0).Select(m => m.Sertifikat).First();

            }
        }

        public string BrojTelefona
        {
            get
            {
                return context.Stomatolozi.Where(m => m.IDClanaKomore.CompareTo(IDClanaKomore) == 0).Select(m => m.BrojTelefona).First();

            }
        }

        public string Mail
        {
            get
            {
                return context.Stomatolozi.Where(m => m.IDClanaKomore.CompareTo(IDClanaKomore) == 0).Select(m => m.Mail).First();

            }
        }

    }
}