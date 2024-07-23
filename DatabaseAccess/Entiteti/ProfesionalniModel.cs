using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entiteti
{
    public class ProfesionalniModel :Osoba
    {
        public virtual double Visina { get; set; }
        public virtual double Tezina { get; set; }
        public virtual string BojaOciju { get; set; }
        public virtual string BojaKose { get; set; }
        public virtual string KonfekcijskiBroj { get; set; }
        public virtual ModnaAgencija Agencija { get; set; }
        public virtual IList<NaslovnaStrana> NaslovneStrane { get; set; }
        public ProfesionalniModel()
        {
            NaslovneStrane = new List<NaslovnaStrana>();
        }
    }
}
