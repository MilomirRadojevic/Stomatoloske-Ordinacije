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
    }
}