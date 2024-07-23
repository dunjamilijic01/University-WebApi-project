using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entiteti
{
    public class NaslovnaStrana
    {
        public virtual int Id { get; protected set; }

        public virtual ProfesionalniModel ModelNaNaslovnojStrani { get; set; }
        public virtual string NazivCasopisa { get; set; }

    }
}
