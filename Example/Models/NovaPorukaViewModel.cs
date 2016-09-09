using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class NovaPorukaViewModel
    {
        private StomatologContext context = new StomatologContext();

        [Required]
        [Display(Name = "Primalac: ")]
        public string PrimalacIDClanaKomore { get; set; }

        public class Stavka
        {
            public string IDClanaKomore { get; set; }
            public string ImeIPrezime { get; set; }

        }

        public List<Stavka> Primaoci
        {
            get
            {
                return (from s in context.Stomatolozi
                        select new Stavka()
                        {
                            IDClanaKomore = s.IDClanaKomore,
                            ImeIPrezime = s.Ime + " " + s.Prezime
                        }).ToList();
            }
        }

        [Required]
        [Display(Name = "Tekst: ")]
        public string TekstPoruke
        {
            set;
            get;
        }

        public void sacuvajPoruku(string PosiljalacID)
        {
            Poruka poruka = new Poruka()
            {
                StomatologPrimalacIDClanaKomore = this.PrimalacIDClanaKomore,
                StomatologSaljeIDClanaKomore = PosiljalacID,
                Tekst = this.TekstPoruke,
                DatumVreme = DateTime.Now,
                Procitana = false
            };

            context.Poruke.Add(poruka);
            context.SaveChanges();
        }
    }

}
