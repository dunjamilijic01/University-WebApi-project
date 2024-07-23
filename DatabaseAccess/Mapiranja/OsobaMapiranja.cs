using FluentNHibernate.Mapping;
using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Mapiranja
{
    public class OsobaMapiranja : ClassMap<Osoba>
    {
        public OsobaMapiranja()
        {
            Table("OSOBA");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Mbr, "MBR");
            Map(x => x.Ime, "IME");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.DatRodjenja, "DATUM_RODJENJA");
            Map(x => x.Pol, "POL");

            HasMany(x => x.UcestvujeNaReviji).KeyColumn("OSOBA_ID").LazyLoad().Cascade.All().Inverse();
        }
    }
}
