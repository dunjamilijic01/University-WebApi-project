using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entiteti
{
    public class ModnaRevija
    {
        public virtual int RbrRevije { get;  set; }
        public virtual string Naziv { get; set; }
        public virtual string MestoOdrzavanja { get; set; }
        public virtual DateTime? DatumVreme { get; set; }
        public virtual char? PrvaZajRevija { get; set; }
        public virtual IList<PojavljujeSeNa> VipNaReviji { get; set; }
        public virtual IList<Organizuje> OrganizovanaOdStrane { get; set; }
        public virtual IList<UcestvujeNa> UcesniciRevije { get; set; }
       
        public ModnaRevija()
        {
            VipNaReviji = new List<PojavljujeSeNa>();
            OrganizovanaOdStrane = new List<Organizuje>();
            UcesniciRevije = new List<UcestvujeNa>();
        }
    }
}
