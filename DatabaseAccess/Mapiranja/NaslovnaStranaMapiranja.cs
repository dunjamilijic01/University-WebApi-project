using FluentNHibernate.Mapping;
using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Mapiranja
{
    public class NaslovnaStranaMapiranja :ClassMap<NaslovnaStrana>
    {
        public NaslovnaStranaMapiranja()
        {
            Table("NASLOVNA_STRANA");
            Id(x => x.Id).GeneratedBy.TriggerIdentity();

            References(x => x.ModelNaNaslovnojStrani).Column("PROFESIONALNI_MODEL_ID").LazyLoad();
            Map(x => x.NazivCasopisa, "NAZIV_CASOPISA");
        }
    }
}
