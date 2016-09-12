using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class SveObjaveViewModel
    {

        private StomatologContext stomatolog = new StomatologContext();

        public ICollection<Objava> ListaObjava
        {
            get
            {
                return stomatolog.Objave.ToList();
            }
        }

    }
}