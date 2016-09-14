using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class ListaPorukaViewModel
    {
        private StomatologContext context = new StomatologContext();



        public void azurirajListuPoruka(string KorisnikID)
        {
          
            ListaPoruka1 = (from p in context.Poruke
                           where (p.StomatologPrimalacIDClanaKomore == KorisnikID)
                           orderby p.DatumVreme descending
                           select p).ToList();
            ListaPoruka1= ListaPoruka1.GroupBy(e => e.StomatologSaljeIDClanaKomore).Select(e => e.First()).ToList();
            
            ListaPoruka2 = (from p in context.Poruke
                            where (p.StomatologSaljeIDClanaKomore == KorisnikID)
                            orderby p.DatumVreme descending
                            select p).ToList();
            ListaPoruka2 = ListaPoruka2.GroupBy(e => e.StomatologPrimalacIDClanaKomore).Select(e => e.First()).ToList();
            ListaPoruka = ListaPoruka1.Concat(ListaPoruka2).ToList();
        
        }

        public List<Poruka> ListaPoruka1
        {
            get;
            set;
        }

        public List<Poruka> ListaPoruka2
        {
            get;
            set;
        }

        public List<Poruka> ListaPoruka
        { 
            get; set; }

        }

}
