using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class ObjavaViewModel
    {
        private StomatologContext context = new StomatologContext();

        [Display(Name = "ID objave: ")]
        public virtual int IDObjave { get; set; }

        [Display(Name = "ID člana komore: ")]
        public virtual string StomatologIDClanaKomore
        {
            get
            {
                return context.Objave.Where(m => m.IDObjave == IDObjave).Select(m => m.StomatologIDClanaKomore).First();
            }
        }

        public virtual Stomatolog Objavio
        {
            get
            {
                return context.Objave.Where(m => m.IDObjave == IDObjave).Select(m => m.Objavio).First();
            }
        }

        public virtual DateTime DatumVreme
        {
            get
            {
                return context.Objave.Where(m => m.IDObjave == IDObjave).Select(m => m.DatumVreme).First();
            }
        }

        [Display(Name = "Vrsta: ")]
        public virtual string Vrsta
        {
            get
            {
                return context.Objave.Where(m => m.IDObjave == IDObjave).Select(m => m.Vrsta).First();
            }
        }

        [Display(Name = "Tekst objave: ")]
        public virtual string Tekst
        {
            get
            {
                return context.Objave.Where(m => m.IDObjave == IDObjave).Select(m => m.Tekst).First();
            }
        }

        public virtual ICollection<KomentarNaObjavu> KomentariNaObjavu
        {
            get
            {
                List<KomentarNaObjavu> lista = context.Objave.Where(m => m.IDObjave == IDObjave).Select(m => m.KomentariNaObjavu).First().ToList();
                return lista.OrderBy(m => m.DatumVreme).ToList();
            }
        }
    }
}