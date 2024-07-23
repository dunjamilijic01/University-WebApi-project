using FluentNHibernate.Mapping;
using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Mapiranja
{
    public class UcestvujeNaMapiranja : ClassMap<UcestvujeNa>
    {
        public UcestvujeNaMapiranja()
        {
            Table("UCESTVUJE_NA");
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            References(x => x.OsobaUcestvujeNa).Column("OSOBA_ID").LazyLoad();
            References(x => x.UcestvujeNaRevija).Column("REVIJA_RBR").LazyLoad() ;

            Map(x => x.SpecijalniGost, "SPECIJALNI_GOST");

        }
    }
}
