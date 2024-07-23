using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entiteti
{
    public class UcestvujeNa
    {
        public virtual int Id { get; set; }

        public virtual Osoba OsobaUcestvujeNa { get; set; }
        public virtual ModnaRevija UcestvujeNaRevija { get; set; }
        public virtual char SpecijalniGost { get; set; }
    }
}
