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

            ListaPoruka = (from p in context.Poruke
                           where p.StomatologPrimalacIDClanaKomore == KorisnikID
                           orderby p.DatumVreme descending
                           select p).ToList();
            ListaPoruka = ListaPoruka.GroupBy(e => e.StomatologSaljeIDClanaKomore).Select(e => e.First()).ToList();

        }

        public List<Poruka> ListaPoruka
        {
            get;
            set;
        }
    }

}
