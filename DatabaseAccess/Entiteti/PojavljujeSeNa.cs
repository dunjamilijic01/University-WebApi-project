using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entiteti
{
    public class PojavljujeSeNa
    {
        public virtual int Id { get; set; }

        public virtual Vip VipPojavljujeSeNa { get; set; }
        public virtual ModnaRevija PojavljujuSeNaRevija { get; set; }
    }
}
