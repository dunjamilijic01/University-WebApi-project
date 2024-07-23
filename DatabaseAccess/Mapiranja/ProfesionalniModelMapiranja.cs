using FluentNHibernate.Mapping;
using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Mapiranja
{
    public class ProfesionalniModelMapiranja : SubclassMap<ProfesionalniModel>
    {
        public ProfesionalniModelMapiranja()
        {
            Table("PROFESIONALNI_MODEL");
            KeyColumn("ID");
            Map(x => x.Visina, "VISINA");
            Map(x => x.Tezina, "TEZINA");
            Map(x => x.BojaOciju, "BOJA_OCIJU");
            Map(x => x.BojaKose, "BOJA_KOSE");
            Map(x => x.KonfekcijskiBroj, "KONFEKCIJSKI_BROJ");

            References(x => x.Agencija).Column("MODNA_AGENCIJA_PIB").LazyLoad();
            HasMany(x => x.NaslovneStrane).KeyColumn("PROFESIONALNI_MODEL_ID").LazyLoad().Cascade.All().Inverse();
        }
    }
}
