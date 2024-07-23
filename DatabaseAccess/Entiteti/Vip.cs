using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entiteti
{
    public class Vip:Osoba
    {
        public virtual string Zanimanje { get; set; }
        public virtual IList<PojavljujeSeNa> VipNaRevijama { get; set; }

        public Vip()
        {
            VipNaRevijama = new List<PojavljujeSeNa>();
        }
    }
}
