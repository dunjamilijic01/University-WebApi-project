using FluentNHibernate.Mapping;
using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Mapiranja
{
    public class ModnaAgencijaMapiranja :ClassMap<ModnaAgencija>
    {
        public ModnaAgencijaMapiranja()
        {
            Table("MODNA_AGENCIJA");
            DiscriminateSubClassesOnColumn("TIP");
            Id(x => x.PIB, "PIB").GeneratedBy.Assigned();

            Map(x => x.Naziv, "NAZIV");
            Map(x => x.Sediste, "SEDISTE");
            Map(x => x.DatumOsnivanja, "DATUM_OSNIVANJA");
            //Map(x => x.Tip, "TIP");

            HasMany(x => x.ProfesionalniModeli).KeyColumn("MODNA_AGENCIJA_PIB").LazyLoad().Cascade.All().Inverse();
           

        }
    }
    class DomacaMapiranja:SubclassMap<Domaca>
    {
        public DomacaMapiranja()
        {
            DiscriminatorValue("DOMACA");
        }
    }

    class InternacionalnaMapiranja:SubclassMap<Internacionalna>
    {
        public InternacionalnaMapiranja()
        {
            DiscriminatorValue("INTERNACIONALNA");
            HasMany(x => x.AgencijaPoslujeU).KeyColumn("MODNA_AGENCIJA_PIB").LazyLoad().Cascade.All().Inverse();
        }
    }
}
