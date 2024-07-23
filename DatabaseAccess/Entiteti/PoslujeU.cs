using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entiteti
{
    public class PoslujeU
    {
        public virtual int Id { get; protected set; }

        public virtual Internacionalna AgencijaPoslujeU { get; set; }
        public virtual string NazivZemlje { get; set; }
    }
}
