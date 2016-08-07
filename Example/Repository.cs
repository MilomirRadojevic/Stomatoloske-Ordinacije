using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Example.Models;

namespace Example
{
    public class Repository
    {
        public List<Stomatolog> vratiStomatologe()
        {
            StomatologContext context = new StomatologContext();
            return context.Stomatolozi.ToList();
        }

        public List<Ordinacija> vratiOrdinacije()
        {
            StomatologContext context = new StomatologContext();
            return context.Ordinacije.ToList();
        }

        public List<Pacijent> vratiPacijente()
        {
            StomatologContext context = new StomatologContext();
            return context.Pacijenti.ToList();
        }

        public List<Objava> vratiObjave()
        {
            StomatologContext context = new StomatologContext();
            return context.Objave.ToList();
        }

        public List<KomentarNaObjavu> vratiKomentareNaObjave()
        {
            StomatologContext context = new StomatologContext();
            return context.KomentariNaObjave.ToList();
        }

        public List<Poruka> vratiPoruke()
        {
            StomatologContext context = new StomatologContext();
            return context.Poruke.ToList();
        }

        public List<OdgovorNaPoruku> vratiOdgovoreNaPoruke()
        {
            StomatologContext context = new StomatologContext();
            return context.OdgovoriNaPoruke.ToList();
        }

        public List<ZakazanaPoseta> vratiZakazanePosete()
        {
            StomatologContext context = new StomatologContext();
            return context.ZakazanePosete.ToList();
        }

        public List<ObavljenaPoseta> vratiObavljenePosete()
        {
            StomatologContext context = new StomatologContext();
            return context.ObavljenePosete.ToList();
        }

        public List<Pregled> vratiPreglede()
        {
            StomatologContext context = new StomatologContext();
            return context.Pregledi.ToList();
        }
    }
}