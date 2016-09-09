using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class Poruka
    {
        [Key]
        public virtual int IDPoruke { get; set; }

        public virtual string StomatologPrimalacIDClanaKomore { get; set; }
        public virtual string StomatologSaljeIDClanaKomore { get; set; }

        public virtual DateTime DatumVreme { get; set; }
        public virtual Stomatolog Primalac { get; set; }
        public virtual Stomatolog Salje { get; set; }
        public virtual string Tekst { get; set; }
        public virtual bool Procitana { get; set; }

        public virtual ICollection<OdgovorNaPoruku> OdgovoriNaPoruke { get; set; }
        StomatologContext context = new StomatologContext();

        // override object.Equals
        public override bool Equals(Object obj)
        {


            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            //throw new NotImplementedException();
            return this.StomatologSaljeIDClanaKomore.Equals(((Poruka)obj).StomatologSaljeIDClanaKomore);
        }


        public void sacuvajPoruku()
        {
            DatumVreme = DateTime.Now;
            Procitana = false;
            context.Poruke.Add(this);
            context.SaveChanges();
        }
    }
}