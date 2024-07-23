using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entiteti
{
    public class Osoba
    {
        public virtual int Id { get; protected set; }
        public virtual string Mbr { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual DateTime? DatRodjenja { get; set; }
        public virtual char Pol { get; set; }
        public virtual IList<UcestvujeNa> UcestvujeNaReviji { get; set; }
       public Osoba()
        {
            UcestvujeNaReviji = new List<UcestvujeNa>();
        }

    }
}
